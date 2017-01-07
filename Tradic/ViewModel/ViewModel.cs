using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradic.ViewModel
{
    public abstract class ViewModel
    {
        public ViewModel()
        {
            Initialize();
        }
        protected virtual void Initialize()
        {
            InitializeCommands();
            InitializeProperties();
        }
        protected abstract void InitializeCommands();
        protected abstract void InitializeProperties();
    }
}
