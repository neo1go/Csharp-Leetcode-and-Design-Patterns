using System.Configuration;

namespace WPFConfigUebung
{
    internal class UISettings : ConfigurationSection
    {
        //Hier müssen die Eigenschaften der Custom-Section definiert werden
        //Die Configuration Eigenschaften werden hier in den eckigen Klammern definiert

        [ConfigurationProperty("language", DefaultValue = "English")]
        public string Language
        {
            get { return (string)this["language"]; }
            set { this["language"] = value; }
        }

        [ConfigurationProperty("theme", DefaultValue = "Light")]
        public string Theme
        {
            get { return (string)this["theme"]; }
            set { this["theme"] = value; }
        }

        [ConfigurationProperty("currency", DefaultValue = "$")]
        public string Currency
        {
            get { return (string)this["currency"]; }
            set { this["currency"] = value; }
        }

        //Der IntegerValidator dient als Begrenzung für den jeweiligen Wert.
        //In der View muß dann  ValidatesOnExceptions=True hinter dem Binding eingefügt werden. 

        [ConfigurationProperty("fontsize", DefaultValue = 8)]
        [IntegerValidator(MinValue = 5, MaxValue = 100)]
        public int FontSize
        {
            get { return (int)this["fontsize"]; }
            set { this["fontsize"] = value; }
        }
    }
}
