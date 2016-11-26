﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tradic.Commands
{
    class Command : ICommand
    {
        public Command(Action<object> action)
        {
            ExecuteDelegate = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
        public Action<object> ExecuteDelegate { get; set; }

        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null) ExecuteDelegate(parameter);
        }
    }   
}
