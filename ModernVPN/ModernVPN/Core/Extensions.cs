
using System.Windows;

namespace ModernVPN.Core
{

    //Dependency Properties
    internal class Extensions
    {
        public static readonly DependencyProperty Icon =
            DependencyProperty.RegisterAttached("Icon", typeof(string),typeof(Extensions), new PropertyMetadata(default(string)));

        //Funktion zum Setten des Icons
        public static void SetIcon(UIElement element,string value)
        {
            element.SetValue(Icon, value);
        }


        //Funktion zum Getten
        public static string GetIcon(UIElement element) 
        {
            return (string)element.GetValue(Icon);
        }
    }
}
