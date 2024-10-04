
using Newtonsoft.Json.Linq;
namespace NUnitTestsWeatherApp

{
    public class Tests
    {
        private string result;  //muﬂ als Feld der Klasse erstellt werden vor dem Setup

        private string _responseContent;
        private readonly HttpClient _httpClient = new();
        //hier sind in der requestURL alle Werte hardcoded
        //Dies ist keine Best practice. Man sollte diese Http Abfragen mocken um nicht den Liveserver zu belasten
        private readonly string _requestURL = "http://api.openweathermap.org/geo/1.0/direct?q=Berlin&limit=5&appid=52e6346375ddba6e3b00bcc797a5d906";

        [SetUp]
        public async Task Setup()
        {
            result = "notNull";

            var response = await _httpClient.GetAsync(_requestURL);
            response.EnsureSuccessStatusCode(); //ob Statuscode ok ist (200)

            _responseContent = await response.Content.ReadAsStringAsync();

            


        }

        [Test]
        public void Test_StringIsNotNull()
        {

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Test_WeatherApp_Response_Content_Not_Null()
        {
            Assert.That(_responseContent, Is.Not.Null);
        }

        [Test]
        public async Task Test_WeatherApp_Response_Content_is_Like_Berlin()
        {

            JArray json =JArray.Parse(_responseContent);

            bool containsText = json.ToString().Contains("Berlin", StringComparison.OrdinalIgnoreCase);

            Assert.That(containsText,Is.True, "Der String ist nicht vorhanden");
        }
    }
}