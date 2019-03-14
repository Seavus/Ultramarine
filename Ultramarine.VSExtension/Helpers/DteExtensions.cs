using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;
using System;

namespace Ultramarine.VSExtension.Helpers
{
    public partial class DteExtensions
    {
        #region Ctor
        private static readonly Lazy<DteExtensions> _instance = new Lazy<DteExtensions>(() => new DteExtensions());
        public static DteExtensions Instance { get { return _instance.Value; } }

        private DteExtensions()
        {

        }
        #endregion

        
    }
}
