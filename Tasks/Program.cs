namespace AllTasks
{
    public class Program
    {

        public static async Task ProcessDataAsync()
        {
            Task task1 = Task.Run(() =>                                     //Aufgabe 1 wird gestartet
            {
                Console.WriteLine("Task 1 läuft");
                Task.Delay(5000).Wait();          //1000ms = 1 sek
                Console.WriteLine("Task 1 erledigt");
            });


            Task task2 = Task.Run(() =>                                     //Aufgabe 2 wird gestartet
            {
                Console.WriteLine("Task 2 läuft");
                Task.Delay(1000).Wait();
                Console.WriteLine("Task 2 erledigt");

            });

            await Task.WhenAll(task1, task2);             //gibt erst eine Rückgabe wenn alle Tasks erledigt sind
        }



        public static async Task Main(string[] args)      //muss zum Task gemacht werden weil
                                                          //async und await nur bei Task existieren
        {
            await ProcessDataAsync();
        }
    }
}