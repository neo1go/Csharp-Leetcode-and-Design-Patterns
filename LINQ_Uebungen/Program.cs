class Program
{
    static void Main(string[] args)
    {
        string[] names = { "Gordon", "Peter", "Kevin", "Frank", "Uli" };


        //mehr wie SQL
        var linqTest = from name in names
                       where name.Contains('l')
                       select name;


        //mehr wie Lambda/delegates
        var linqTest2 = names.Where(name => name.Contains('r'));


        foreach (string name in linqTest)
        {
            Console.WriteLine(name + " ist ein Name mit l");
        }



        foreach (string name in linqTest2)
        {
            Console.WriteLine(name + " ist ein Name mit r");
        }

        Console.ReadKey();


    }


}
