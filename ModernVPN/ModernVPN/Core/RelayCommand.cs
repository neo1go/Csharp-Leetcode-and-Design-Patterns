
using System.Windows.Input;

namespace ModernVPN.Core
{
    internal class RelayCommand : ICommand
    {
        //Felder 
        private Action<object> execute;
        private Func<object,bool> canExecute;

        //erkennt ob eine Handlung durchgeführt wirdo der durchgeführt werden kann
        public event EventHandler CanExecuteChanged
        {
            add {CommandManager.RequerySuggested += value; }
            remove {CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute=execute;
            this.canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
           return this.canExecute == null || this.canExecute(parameter);
        }


        //Falls bool true, wird ausgeführt
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
