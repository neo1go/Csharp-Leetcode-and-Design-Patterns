//Builder Design Pattern das oft verwendet wird, wenn die Objekte komplex gestaltet werden müssen,
//aber immutable (unveränderbar) sein sollen. z.B.
//Konfigurationsobjekte,Datenbankverbindungen oder API-Anfragen (HTTP-Requests)

namespace BuilderPattern
{

    public class HttpRequest
    {
        //Properties 
        public string Url { get; }
        public string Method { get; }
        public Dictionary<string, string> Headers { get; } //Key und Value (HashMap)
        public string Body { get; }

        //Konstruktor der privat ist, um sicherzustellen dass nur der Builder diese Klasse instanziieren kann. 
        private HttpRequest(string url, string method, Dictionary<string, string> headers, string body)
        {
            Url = url;
            Method = method;
            Headers = headers;
            Body = body;
        }

        //Der Builder kann als innere Klasse oder seperate Klasse verwendet werden
        //Die Methoden werden je nach Erfordernis an das zu erzeugende Objekt angehangen.
        public class Builder
        {
            private string? _url;
            private string _method = "GET"; //Standardmethode
            private Dictionary<string, string> _headers = new Dictionary<string, string>();
            private string _body = string.Empty;
            

            //WICHTIG, dies ist die Hauptunterscheidung für das Builder Pattern -
            //Die einzelnen Methoden, die mittels Method_Chaining aneinander gereiht werden können. 
            public Builder SetUrl(string url) //setzt die URL und gibt ein Builder Objekt zurück
            {
                _url = url;
                return this;
            }

            public Builder SetMethod(string method) //Setter für die Methode
            {
                _method = method;
                return this;
            }

            public Builder AddHeader(string key, string value)//Setter für den Header
            {
                _headers.Add(key, value);
                return this;
            }

            public Builder SetBody(string body)//Setter für den Body
            {
                _body = body;
                return this;
            }

            public HttpRequest BuildObject()  //Baut das HttpRequest-Objekt
            {
                if (string.IsNullOrEmpty(_url))
                {
                    throw new InvalidOperationException("URL darf nicht null oder leer sein");
                }
                return new HttpRequest(_url, _method, new Dictionary<string, string>(_headers), _body);
            }
        }
    }

    //Im director sieht man die Flexibilität, da auf das Objekt unterschiedliche Methoden angewandt werden können
    //die wie in diesem Fall auch noch durch die unterschiedlichen Methoden direkt aufgerufen werden können.
    public class HttpRequestDirector
    {
        private readonly HttpRequest.Builder _builder;

        //Konstruktor
        public HttpRequestDirector(HttpRequest.Builder builder)
        {
            _builder = builder;
        }

        //Baut eine POST-Anfrage mit JSON-Daten
        //WICHTIG - Beim return kommt das Method-Chaining zum Einsatz
        public HttpRequest BuildPostRequest(string url, string jsonBody)
        {
            return _builder    //hier werden die erforderlichen Methoden in gewünschter Form angehangen an das Objekt
                .SetUrl(url)
                .SetMethod("POST")
                .AddHeader("Content-Type", "application/json")
                .SetBody(jsonBody)
                .BuildObject();
        }

        //Baut eine GET-Anfrage mit Token 
        public HttpRequest BuildGetRequestWithAuth(string url, string token)
        {
            return _builder
                .SetUrl(url)
                .SetMethod("GET")
                .AddHeader("Authorization", $"Bearer {token}")
                .BuildObject();
        }
    }
    public class Program
    {

        public static void Main(string[] args)
        {
            var builderObject = new HttpRequest.Builder(); //Erstellung des builder Objektes
            var directorObject = new HttpRequestDirector(builderObject); //builder Objekt wird an director übergeben

            //Beispiel für eine POST-Anfrage, die im director vorhanden ist
            var postRequest = directorObject.BuildPostRequest("https://api.example.com/data", "{ \"name\": \"John\" }");

            //Beispiel für eine GET-Anfrage mit Authentifizierung, die im director vorhanden ist
            var getRequest = directorObject.BuildGetRequestWithAuth("https://api.example.com/user", "myToken123");

            PrintHttpRequest(postRequest);
            PrintHttpRequest(getRequest);

        }

        private static void PrintHttpRequest(HttpRequest request)
        {
            Console.WriteLine($"Method: {request.Method}");
            Console.WriteLine($"URL: {request.Url}");

            //Hier wird Join genutzt, um die Key Value Paare des dictionaries in ein string Format zu bringen
            //in dem jeder Header als key/value dargestellt wird
            //Der Select wird verwendet, um über die header zu iterieren und sie als Key:Value Paare zu formatieren,
            //andernfalls würde der header als System.Collection.Generic.KeyValuePair dargestellt.
            //Durch den Select kann man z.B. noch andere Zeichen, Präfixe oder Suffixe hinzufügen
            Console.WriteLine($"Headers: {string.Join(",", request.Headers.Select(h => $"{h.Key}: {h.Value}"))}"); 
            Console.WriteLine($"Body: {request.Body}");
            Console.WriteLine();
        }
    }
}
