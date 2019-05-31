namespace Ultramarine.Generators.Tasks.Library.Contracts
{
    public class Variable
    {
        public Variable()
        {

        }

        public Variable(string key, object value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public object Value { get; set; }
    }
}
