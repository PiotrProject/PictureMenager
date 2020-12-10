using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoResizer.ViewModels.Commands
{
    public class Command : ICommand
    {
        readonly Action _execute;
        
        public Command(Action execute )
        {
            this._execute = execute;
        }

        public event EventHandler CanExecuteChanged;        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
