using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Windows;


namespace WeatherProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {//key default =    52e6346375ddba6e3b00bcc797a5d906
        //  newKey =    187ac4baf0f7101880050532cf4dbe78
        private const string ApiKey = "52e6346375ddba6e3b00bcc797a5d906";

        private const string geoDataURL = "http://api.openweathermap.org/geo/1.0/direct";

        private const string ApiUrl = "http://api.openweathermap.org/data/2.5/weather";

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void Bt_Input_City_Click(object sender, RoutedEventArgs e)
        {
            string city = input_city.Text; //Textbox input_city

            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Bitte geben Sie einen Ort ein.");
                return;
            }
            try
            {
                //Hier wird aus der Ortsangabe eine Koordinate(lan/lon) von der Webseitendatenbank zurückgegeben.
                string geoURL = $"{geoDataURL}?q={city}&limit=5&appid={ApiKey}";
                using (HttpClient client = new())
                {
                    string geoResponse = await client.GetStringAsync(geoURL);
                    JArray geoArray = JArray.Parse(geoResponse);  //JArray von Newtonsoft

                    if (geoArray.Count > 0)
                    {
                        JObject firstResult = (JObject)geoArray[0];//JObject auch von Newtonsoft
                        string lat = firstResult["lat"]?.ToString() ?? "52,5170365";//Koordinaten Berlin
                        string lon = firstResult["lon"]?.ToString() ?? "13,3888599";//Koordinaten Berlin
                        string country = firstResult["country"]?.ToString() ?? "Land ist nicht verfügbar";
                        string state = firstResult["state"]?.ToString() ?? "Bundesland ist nicht verfügbar";
                        if (!string.IsNullOrEmpty(lat) && !string.IsNullOrEmpty(lon))
                        {
                            System.Diagnostics.Debug.WriteLine($"latitude = {lat}");
                            System.Diagnostics.Debug.WriteLine($"longitude = {lon}");

                            //Zweite Abfrage mit den lat und lon Daten, die vorher umgewandelt wurden.
                            string url = $"{ApiUrl}?lat={lat}&lon={lon}&appid={ApiKey}&units=metric&lang=de";


                            string response = await client.GetStringAsync(url);
                            JObject weatherData = JObject.Parse(response);    


                            //hier werden definierte Teile des JsonObjekts von der Http Abfrage
                            //als String jeweils in eine lokale Variable gespeichert. 
                            string cityName = weatherData["name"]?.ToString() ?? " Ort ist unbekannt";
                            string temperature = weatherData["main"]?["temp"]?.ToString() ?? "Nicht verfügbar";
                            string humidity = weatherData["main"]?["humidity"]?.ToString() ?? "Nicht verfügbar";
                            string weather = weatherData["weather"]?[0]?["description"]?.ToString() ?? "Keine Wetterangabe";

                            display_City.Text = $"{cityName}";  //Einfügen in die XAML-Variablen zur Darstellung
                            display_Temperature.Text = $"{temperature} °C";
                            display_Humidity.Text = $"{humidity} %";
                            display_Country.Text = $"{country}";
                            display_State.Text = $"{state}";
                            display_Weather.Text = $"{weather}";
                        }
                        else
                        {
                            MessageBox.Show("Fehler bei der Koordinatenextraktion. Überprüfen Sie die Geocoding-Daten.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Keine Ergebnisse gefunden. Überprüfen Sie den Stadtnamen.");
                    }

                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Fehler bei der HTTP-Anfrage: {ex.Message}");
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Fehler beim Verarbeiten der JSON Daten: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Allgemeiner Fehler: {ex.Message}");
            }

        }
    }
}