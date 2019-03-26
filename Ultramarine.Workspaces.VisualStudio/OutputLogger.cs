using EnvDTE;
using System;

namespace Ultramarine.Workspaces.VisualStudio
{
    public class OutputLogger : ILogger
    {
        public OutputLogger()
        {
            var outputWindowPane = GetOutputWindow();
            outputWindowPane.Clear();
        }

        public const string LoggerPaneName = "Ultramarine - Log";

        public void Info(string messageFormat, params string[] parameters)
        {
            var message = string.Format(messageFormat, parameters);
            var outputWindowPane = GetOutputWindow();
            outputWindowPane.OutputString($"{DateTime.Now.ToString("T")}\n{message}\n");
        }

        public void Warn(string messageFormat, params string[] parameters)
        {
            var message = string.Format(messageFormat, parameters);
            var outputWindowPane = GetOutputWindow();
            outputWindowPane.OutputString($"{DateTime.Now.ToString("T")}\nWARNING: { message}\n");
            
        }

        private OutputWindowPane GetOutputWindow()
        {
            Window window = Dte.Instance.Host.Windows.Item(Constants.vsWindowKindOutput);
            OutputWindow outputWindow = (OutputWindow)window.Object;
            OutputWindowPane outputWindowPane;
            try
            {
                outputWindowPane = outputWindow.OutputWindowPanes.Item(LoggerPaneName);
            }
            catch (ArgumentException ex)
            {
                outputWindowPane = outputWindow.OutputWindowPanes.Add(LoggerPaneName);
            }
            return outputWindowPane;
        }
    }
}
