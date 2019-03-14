namespace Ultramarine.Generators.Task.Library.Contracts
{
    public abstract class CompositeTask : Task
    {
        protected CompositeTask() : this(null)
        {
        }

        protected CompositeTask(string name) : base(name)
        {
        }

        protected override object Run()
        {
            throw new System.NotImplementedException();
        }
    }
}
