namespace Ultramarine.Workspaces.VisualStudio.T4
{
    public class TransformationError
    {
        public string Message { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }

        public bool IsWarning { get; set; }

        public TransformationError(string message, int line, int column, bool isWarning)
        {
            Message = message;
            Line = line;
            Column = column;
            IsWarning = isWarning;
        }
    }
}
