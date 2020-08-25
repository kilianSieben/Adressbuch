using System;
using System.Windows.Input;
using AddressBook.Events;

namespace AddressBook.Utilities {
    public class RelayCommand : ICommand {
        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;

        private event EventHandler CanExecuteChangedInternal;

        public RelayCommand(Action<object> execute)
            : this(execute, null) {
            this.execute = execute;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute) {
            if (execute == null) {
                throw new ArgumentNullException("execute");
            }
            this.execute = execute;
            this.canExecute = canExecute;
        }
        // Ensures WPF commanding infrastructure asks all RelayCommand objects whether their
        // associated views should be enabled whenever a command is invoked 
        public event EventHandler CanExecuteChanged {
            add {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }
            remove {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        public bool CanExecute(object parameter) {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter) {
            execute(parameter);
        }

        public void RaiseCanExecuteChanged() {
            CanExecuteChangedInternal.Raise(this);
        }
    }
}
