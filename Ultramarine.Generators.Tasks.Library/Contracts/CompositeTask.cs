using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tasks.Library.Contracts
{
    public abstract class CompositeTask : Task
    {
        protected CompositeTask() : this(null)
        {
        }

        protected CompositeTask(string name) : base(name)
        {
            Tasks = new TaskCollection(this);
        }

        protected override object Run()
        {
            throw new System.NotImplementedException();
        }

        public TaskCollection Tasks { get; set; }

        public override void SetExecutionContext(IProjectModel executionContext)
        {
            base.SetExecutionContext(executionContext);
            foreach(var task in Tasks)
            {
                task.SetExecutionContext(executionContext);
            }
        }
    }
}
