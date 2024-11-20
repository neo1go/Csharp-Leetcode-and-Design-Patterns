using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ValueConverterUebung.Converters
{
    public class BoolToStringConverter : IValueConverter
    {

        //Der BooltoStringConverter wird nur einmal instanziiert,
        //somit kann man diesen bool als flag nutzen. Sie steht nur einmal auf false
        //und wird beim ersten Benutzen der Checkbox auf true gesetzt.
        //Dieser bool dient alleine der leeren Instanziierung der Textbox, in der später "Yes" oder "No" steht.
        private bool _isInitialized = false;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Durch dieses If Statement wird der Wert nicht intialisiert und erst nach dem ersten Anklicken gesetzt.
            if (!_isInitialized)
            {
                _isInitialized = true;
                return string.Empty; //Bricht hier nur einmal ab , da danach auf true gesetzt wurde.
            }

            var answerBool = (bool?)value;
            
            if (answerBool == true) 
            {
                return "Yes";
            }
            else
            {
                return "No";
            }         
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            

            var answerString = (string)value;

            //if (string.IsNullOrEmpty(answerString))
            //{
            //    return false;
            //}

            if (answerString.Equals("yes",StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else 
            {
                return false;
            }

        }
    }
}
