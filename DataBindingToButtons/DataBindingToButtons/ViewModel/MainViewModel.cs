using DataBindingToButtons.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;


namespace DataBindingToButtons.ViewModel
{
    public class MainViewModel
    {
        //Properties
       public List<string>? Letters { get; set; }

        public ICommand? MoveNextCommand { get; set; } //Diese beiden Kommandos werden den Buttons zugeordnet
        public ICommand? MovePreviousCommand { get; set; }

        public ICollectionView View { get; set; } //Dies wird genutzt, um aus der oberen normalen Letters-List eine Collection zu machen,
                                                  //der man dann weitere Logik hinzufügen kann wie z.B. sorting,filtering oder Navigation. 
        public MainViewModel()
        {
            Letters = new List<string>() {"A","B","C","D","E" }; //Instanziierung

            View = CollectionViewSource.GetDefaultView(Letters); //DefaultView wird als ICollection dargestellt.


            MoveNextCommand = new RelayCommand(CanMoveNext, MoveNext);

            MovePreviousCommand = new RelayCommand(CanMovePrevious, MovePrevious);
        }

        private void MovePrevious(object obj)
        {
            View.MoveCurrentToPrevious();
        }

        private bool CanMovePrevious(object obj)
        {
            return View.CurrentPosition >0 ; //also auf 1 ist der Button noch aktiv
        }

        private void MoveNext(object obj)
        {
            View.MoveCurrentToNext();   //Iteriert einen Schritt weiter
        }

        private bool CanMoveNext(object obj)
        {
          return  View.CurrentPosition < Letters.Count - 1;  //returned true, solange die aktuelle Position noch
                                                             //innerhalb der List(und somit der collection) ist.
        }
    }
}
