using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.Core
{
    internal class RelayCommand : ICommand
    {
        private Action<object>? _execute;
        private Func<object, bool>? _canExecute;

        public event EventHandler? CanExecuteChanged;

        public event EventHandler CanExecuteChangedEventHandler
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute != null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            if (parameter == null)
                return;

            _execute?.Invoke(parameter);
        }
    }
}
