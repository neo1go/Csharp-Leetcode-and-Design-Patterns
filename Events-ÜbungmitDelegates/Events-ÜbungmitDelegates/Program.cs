public class Program
{
    //Events

    // sollen veraltet sein und machen die Testbarkeit schwerer. Außerdem werden Objekte, die immer noch von einem
    //  Eventhandler abonniert sind, nicht vom Garbage-Collector freigegeben und können so Speicherlecks erzeugen.
    // Die Events werden von IObservable<T> und IObserver<T> abgelöst (IDisposeable für Subscribe).


    public static void Main()
    {
        var data = new WeatherData();


        //Subscriber erstellen mit den Eigenschaften, in diesem Fall "Name"
        var schmitt = new Meterologe("Schmitt");
        var jones = new Meterologe("Jones");

        //Subscriber werden mittels "Subscribe" als Abonnenten hinzugefügt
        schmitt.Subscribe(data);
        jones.Subscribe(data);

        //Werte zum Auslösen des Events
        data.WindSpeed = 81;
        data.Temperature = 46;
        //data.WindSpeed = 75;
        //data.Temperature = 25;

    }
}

public class WeatherData
{
    //Delegaten für die Events
    public delegate void WindSpeedExceededEventHandler(object sender, WindSpeedExceededEventArgs e);
    public delegate void TemperatureExceededEventHandler(object sender, TemperatureExceededEventArgs e);


    //Dies sind die Events auf die sich die Abonnenten subscriben
    public event WindSpeedExceededEventHandler? WindSpeedExceeded;
    public event TemperatureExceededEventHandler? TemperatureExceeded;

    //Felder
    private float temperature;
    public float windSpeed;

    //Konstruktor für Temperatur
    public float Temperature
    {
        get { return temperature; }
        set
        {
            temperature = value;
            if (temperature > 45)
            {
                OnTemperatureExceeded();
            }
        }
    }

    //Konstruktor für Windgeschwindigkeit
    public float WindSpeed
    {
        get
        {
            return windSpeed;
        }
        set
        {
            windSpeed = value;
            if (windSpeed > 80)
            {
                OnWindSpeedExceeded();
            }

        }
    }



    //Mit diesen Methoden werden die Events aktiviert mittels Invoke falls die Events nicht null sind
    public virtual void OnTemperatureExceeded()
    {
        TemperatureExceeded?.Invoke(this, new TemperatureExceededEventArgs(temperature));
    }
    public virtual void OnWindSpeedExceeded()
    {
        WindSpeedExceeded?.Invoke(this, new WindSpeedExceededEventArgs(windSpeed));
    }


}


//Argumente für die beiden Events in Klassen definiert
public class TemperatureExceededEventArgs : EventArgs
{
    public double Temperature { get; }

    public TemperatureExceededEventArgs(double temperature)
    {
        Temperature = temperature;
    }
}


public class WindSpeedExceededEventArgs : EventArgs
{
    public double WindSpeed { get; }

    public WindSpeedExceededEventArgs(double windSpeed)
    {
        WindSpeed = windSpeed;
    }
}


//Subscriber Klassen

public class Meterologe
{

    private string name;

    public Meterologe(string name)
    {
      this.name = name;
        
    }

    //Der Abonnent kan mit dieser Methode subscriben. Die auszuführenden Methoden werden zu dem Event geaddet
    public void Subscribe(WeatherData weatherData)
    {
        weatherData.TemperatureExceeded += OnTemperatureExceeded;
        weatherData.WindSpeedExceeded += OnWindSpeedExceeded;
    }

    //Dies sind die beiden Methoden die hinzugefügt werden
    private void OnTemperatureExceeded(object sender, TemperatureExceededEventArgs e)
    {
        Console.WriteLine($"Meterologe {name}: Achtung Temperatur überschreitet 45°");
    }

    private void OnWindSpeedExceeded(object sender, WindSpeedExceededEventArgs e)
    {
        Console.WriteLine($"Meterologe {name}: Achtung Windgeschwindigkeit überschreitet 80 km/h");
    }

}

