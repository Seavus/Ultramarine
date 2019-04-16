using Microsoft.VisualStudio.TextTemplating.VSHost;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ultramarine.Workspaces.VisualStudio.T4
{
    public class TransformationLogger : ITextTemplatingCallback
    {
        public TransformationLogger()
        {
            Errors = new List<TransformationError>();
        }
        public List<TransformationError> Errors { get; set; }
        public bool HasErrors { get { return Errors.Any(m => !m.IsWarning); } }
        public bool HasMessages { get { return Errors.Count > 0; } }
        public Encoding Encoding { get; set; }
        public string Extension { get; set; }
        public void ErrorCallback(bool warning, string message, int line, int column)
        {
            Errors.Add(new TransformationError(message, line, column, warning));
        }

        public void SetFileExtension(string extension)
        {
            Extension = extension;
        }

        public void SetOutputEncoding(Encoding encoding, bool fromOutputDirective)
        {
            Encoding = encoding;
        }
    }
}
