using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataBindingToButtons
{
    public class RelayCommand : ICommand       //mit dieser Klasse werden die Button-Aktionen bearbeitet falls sie möglich sind.
    {
        //Felder
        private readonly Predicate<object> _canExexute;
        private readonly Action<object> _execute;

        public event EventHandler? CanExecuteChanged  //Dieser Handler reagiert immer dann, wenn eine der unteren Methoden ausgeführt wird.
        {
            add => CommandManager.RequerySuggested += value; //registriert den Eventhandler der immer CanExecute() erneut aufruft(Requery)
            remove => CommandManager.RequerySuggested -= value;
        } //mit remove werden EventHandler nach der Nutzung entfernt, um Speicherlecks oder unnötige Aktualisierungen zu vermeiden.
          //In diesem Fall wird er niemals removed weil nur ein EventHandler registriert wurde
          //und dieser während der gesamten Lauftzeit aktiviert bleibt.

        public RelayCommand(Predicate<object> canExecute, Action<object> execute )
        {
            _canExexute=canExecute;
            _execute = execute;
        }
        public bool CanExecute(object? parameter)
        {
           return _canExexute(parameter); //Diese Methode eintscheidet, ob überhaupt execute ausgeführt werden kann.
        }

        public void Execute(object? parameter) //Ausführung des Buttonpress
        {
            _execute(parameter);
        }
    }
}
