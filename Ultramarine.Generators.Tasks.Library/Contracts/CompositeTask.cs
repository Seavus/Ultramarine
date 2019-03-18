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
    }
}
