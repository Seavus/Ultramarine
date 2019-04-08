using System.Collections;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(ITask))]
    public class Iterator: CompositeTask
    {
        protected override object OnExecute()
        {
            if(Input is IEnumerable)
            {
                var inputList = Input as IList;

                if (inputList == null || inputList.Count == 0)
                {
                    Logger.Warn($"Iterator '{Name}' input is an empty collection. Check the connected tasks.");
                }

                var output = new List<object>();
                foreach (var inputElement in Input as IEnumerable)
                {
                    PopulateTasksInput(inputElement);

                    base.OnExecute();

                    var lastTask = Tasks.LastOrDefault();
                    if (lastTask == null)
                        return Input;

                    output.Add(lastTask.Output);
                }
                return output;
            }
            return Input;
        }

        private void PopulateTasksInput(object input)
        {
            foreach (var task in Tasks.Where(task => task.ConnectedWith == null))
            {
                task.Input = input;
            }
        }
    }

}
