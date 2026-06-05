namespace FizzBuzz
{
    public class Program
    {

        //Meine Variante
        public static void FizzBuzz()
        {
            string fizz = "Fizz";
            string buzz = "Buzz";
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine($"{i} {fizz} {buzz}");
                    continue;  //springt komplett heraus aus dem Schritt um doppelte Werte zu vermeiden.
                }
                if (i % 3 == 0)
                {
                    Console.WriteLine($"{i} {fizz}");
                }
                if (i % 5 == 0)
                {
                    Console.WriteLine($"{i} {buzz}");
                }
            }
        }

        //Switchcase Variante mit bool-Abgleich
        public static void FizzBuzzII()
        {
            for (int i = 1; i <= 100; i++)
            {
                switch ((i % 3 == 0, i % 5 == 0))
                {
                    case (true, true):
                        Console.WriteLine("FizzBuzz");
                        break;
                    case (true, false):
                        Console.WriteLine("Fizz");
                        break;
                    case (false, true):
                        Console.WriteLine("Buzz");
                        break;
                    default:
                        Console.WriteLine(i);
                        break;
                }
            }
        }

        //Konkatenierung der Strings
        public static void FizzBuzzIII()
        {
            for (int i = 1; i <= 100; i++)
            {
                string result = "";
                if (i % 3 == 0) result += "Fizz";
                if (i % 5 == 0) result += "Buzz";

                Console.WriteLine(string.IsNullOrEmpty(result) ? i.ToString() : result);
         // Wenn Wert von result leer oder null ist (isNullOrEmpty), dann  wird i.ToString() eingesetzt, ansonsten der result-Wert,
         // der dann  u.U. auch konkateniert werden kann.
            }
        }

        public static void FizzBuzzIV()
        {
            var fizzBuzz = Enumerable.Range(1, 100) //hier wird eine iterierbare Variable erstellt mit der Range von 1 bis 100
                .Select(i => (i % 3 == 0, i % 5 == 0) switch  //dies ist ein Tupel. Es wird zwischen den beiden bools geswitched
                {
                    (true, true) => "FizzBuzz",  //es können auch beide Zustände abgebildet werden.
                    (true, false) => "Fizz",
                    (false, true) => "Buzz",
                    _ => i.ToString()
                });
            foreach (var item in fizzBuzz)
            {
                Console.WriteLine(item);
            }
        }

        //Rekursiv
        public static void FizzBuzzRecursive(int n, int limit)
        {
            if (n > limit) return;        //bricht Rekursion ab

            if (n % 3 == 0 && n % 5 == 0) Console.WriteLine("FizzBuzz");
            else if (n % 3 == 0) Console.WriteLine("Fizz");
            else if (n % 5 == 0) Console.WriteLine("Buzz");
            else Console.WriteLine(n);

            FizzBuzzRecursive(n + 1, limit);  //hier das gleiche wie i++,nur eben rekursiv
        }

        //Mit einer HashMap(Key,Value)
        public static void FizzBuzzByDict()
        {
            var rules = new Dictionary<Func<int, bool>, string> //bei func wird ein int eingefügt und ein bool returned
                                                                // Der Key ist die func<> und die Value ist der string.
            {
                { x => x % 3 == 0 && x % 5 == 0, "FizzBuzz" }, //muss hier zuerst stehen wegen dem FirstOrDefault
                { x => x % 3 == 0, "Fizz" },
                { x => x % 5 == 0, "Buzz" }  //Key ist der bool und value ist der string.
            };

            for (int i = 1; i <= 100; i++)
            {
                var output = rules.FirstOrDefault(r => r.Key(i)).Value ?? i.ToString();// ?? ist ein Null-Koaleszenz Operator
                                             //Wenn linke Seite true ist, wird diese ausgegeben, sonst die rechte Seite,
                                             //d.h. wenn links null ist, wird die rechte Seite ausgeführt.
                Console.WriteLine(output);   //FirstOrDefault gibt immer den ersten Wert zurück.
            }
        }

        //Mehrere tenäre Operatoren ineinander verschachtelt
        public static void TenaryFizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
                Console.WriteLine(i % 3 == 0 ? (i % 5 == 0 ? "FizzBuzz" : "Fizz") : (i % 5 == 0 ? "Buzz" : i.ToString()));
        }


        public static async Task FizzBuzzAsync(int limit)
        {
            for (int i = 1; i <= limit; i++)
            {
                int current = i;    //muss umgewandelt werden mit lokaler Kopie, da evtl. die asynchrone
                                    //Verarbeitung den Iterator i weiterlaufen lässt, während noch verarbeitet wird.
                await Task.Run(() =>
                {
                    if (current % 3 == 0 && current % 5 == 0) Console.WriteLine("FizzBuzz");
                    else if (current % 3 == 0) Console.WriteLine("Fizz");
                    else if (current % 5 == 0) Console.WriteLine("Buzz");
                    else Console.WriteLine(current);
                });
            }
        }



        public static async Task Main()
                {
                    //FizzBuzz();
                    //FizzBuzzII();
                    //FizzBuzzIII();
                    //FizzBuzzIV();
                    //FizzBuzzRecursive(1, 100);
                    //FizzBuzzByDict();
                    //TenaryFizzBuzz();
                
                    await FizzBuzzAsync(100);
                    
                }  
    }


   
}
