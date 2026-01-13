using System;
using System.Collections.Generic;
using System.Linq;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tasks.Library.Contracts
{
    public abstract class CompositeTask : Task
    {
        private readonly List<Task> _executedTasks;

        protected CompositeTask() : this(null)
        {
        }

        protected CompositeTask(string name) : base(name)
        {
            Tasks = new TaskCollection(this);
            _executedTasks = new List<Task>();
        }

        protected override object OnExecute()
        {
            foreach (var task in Tasks)
            {
                if (string.IsNullOrWhiteSpace(task.ConnectedWith))
                {
                    if (task.Input == null)
                        task.Input = Input;
                }
                else
                {
                    var connectedTask = _executedTasks.FirstOrDefault(t => t.Name == task.ConnectedWith);
                    if (connectedTask == null)
                        throw new ArgumentException($"Connected task {task.ConnectedWith} doesn't exist");
                    task.Input = connectedTask.Output;
                }

                task.Execute();
                _executedTasks.Add(task);
            }

            if (Output == null)
            {
                var lastTask = _executedTasks.LastOrDefault();
                if (lastTask != null)
                    Output = lastTask.Output;
            }

            return Output;
        }

        public TaskCollection Tasks { get; set; }

        public override void SetExecutionContext(IProjectModel executionContext)
        {
            base.SetExecutionContext(executionContext);
            foreach (var task in Tasks)
            {
                task.SetExecutionContext(executionContext);
            }
        }

        public override void SetLogger(ILogger logger)
        {
            base.SetLogger(logger);
            foreach (var task in Tasks)
            {
                task.SetLogger(logger);
            }
        }
    }
}
