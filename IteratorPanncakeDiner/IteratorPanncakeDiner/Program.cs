using IteratorPancakeDiner;
using System.Collections;
using System;


namespace IteratorPancakeDiner
{
    //Dieses interface stellt die Deklarationen für die konkreten Methoden bereit
    public interface Iterator
    {
        bool hasNext();
        MenuItem next();
    }
    //------------------------------------------------------
    //Die grundlegende Struktur der Einträge als Objekt
    public class MenuItem
    {
        public string name;
        public string description;
        public bool vegetarian;
        public double price;

        public MenuItem(string name, string description, bool vegetarian, double price)
        {
            this.name = name;
            this.description = description;
            this.vegetarian = vegetarian;
            this.price = price;
        }
    }
    //--------------------------------------------------------

    //Klasse für eine konkrete Collection, die iteriert werden soll.
    public class DinerMenu
    {
        const int MAX_ITEMS = 6;
        int numberOfItems = 0;
        MenuItem[] menuItems;

        //Default Konstruktor
        public DinerMenu()
        {
            menuItems = new MenuItem[MAX_ITEMS];
            AddItem("Vegetarisches Sandwich", "(Falscher) Schinken mit Salat und Tomate auf Volkornbrot", true, 2.99);
            AddItem("Schinkensandwich", "Schinken mit Salat und Tomate auf Volkornbrot", false, 2.99);
            AddItem("Tagessuppe", "Tagessuppe mit Kartoffelsalat als Beilage", false, 3.29);
            AddItem("HotDog", "HotDog mit Sauerkraut, Soße, Zwiebeln und Käse", false, 3.05);
        }

        public void AddItem(string name, string description, bool vegetarian, double price)
        {
            if (numberOfItems >= MAX_ITEMS)
            {
                Console.WriteLine("Speisekarte ist voll. Kann keine weiteren Gerichte hinzufügen.");
            }
            else
            {
                MenuItem newItem = new MenuItem(name, description, vegetarian, price);
                menuItems[numberOfItems] = newItem;
                numberOfItems++;
            }
        }

        public Iterator CreateIterator()
        {
            return new DinerMenuIterator(menuItems); //Custom Iterator extra für die passende Collection
        }
    }


    //Klasse für das Pfannkuchenhaus Menü ,also eine weitere konkrete Collection, die iteriert werden soll. Diesmal eine ArrayList.
    public class PancakeHouseMenu
    {
        ArrayList menuItems = new ArrayList();

        public PancakeHouseMenu()
        {
            AddItem("Kürbispfannkuchen", "Pfannkuchen mit Kürbis und Ahornsirup", true, 3.99);
            AddItem("Blaubeerpfannkuchen", "Pfannkuchen mit frischen Blaubeeren", true, 4.49);
        }

        public void AddItem(string name, string description, bool vegetarian, double price)
        {
            MenuItem item = new MenuItem(name, description, vegetarian, price);
            menuItems.Add(item);
        }

        public Iterator CreateIterator()
        {
            return new PancakeHouseIterator(menuItems);
        }
    }

    //Weitere Collection zum Iterieren, diesmal ein dict.
    public class CafeMenu
    {
        Dictionary<string, MenuItem> menuItems = new Dictionary<string, MenuItem>();

        public CafeMenu()
        {
            AddItem("Veggie Burger und Fritten", "Veggieburger auf einem ganzen Weizenbrötchen, Salat Tomaten und Pommes Frites", true, 3.99);
            AddItem("Tagessuppe", "Ein Teller Suppe des Tages mit Beilagensalat", false, 3.69);
            AddItem("Burrito", "Ein grßer Burrito mit ganzen Pintobohnen, Salsa und Guacamole", true, 4.29);
        }

        public void AddItem(string name, string description, bool vegetarian, double price)
        {
            MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
            menuItems.Add(name, menuItem); //Achtung, hier wird vom MenuItem Datentyp ins dictionary übertragen.
        }

        public Dictionary<string, MenuItem> GetMenuItems()
        {
            return menuItems;
        }

        public Iterator CreateIterator()
        {
            return new CafeMenuIterator(menuItems);
        }
    }


    //----------------------------------------------------------------------

    // Iterator speziell für DinerMenu Klasse und Array Iteration
    public class DinerMenuIterator : Iterator
    {
        MenuItem[] items;  //dieser Iterator wird für eine Array-Iteration genutzt im Gegensatz zu pancake mit ArrayList
        int position = 0;

        public DinerMenuIterator(MenuItem[] items)
        {
            this.items = items;
        }

        public bool hasNext()
        {
            return position < items.Length && items[position] != null;
        }

        public MenuItem next()
        {
            MenuItem menuItem = items[position];
            position++;
            return menuItem;
        }
    }

    //PancakeHouse Iterator, speziell für  ArrayList Collections
    public class PancakeHouseIterator : Iterator
    {
        ArrayList items;  //hier wird der Iterator für eine ArrayList Collection erstellt
        int position = 0;

        public PancakeHouseIterator(ArrayList items)
        {
            this.items = items;
        }

        public bool hasNext()
        {
            return position < items.Count;
        }

        public MenuItem next()
        {
            MenuItem item = (MenuItem)items[position];
            position++;
            return item;
        }
    }

    public class CafeMenuIterator : Iterator
    {
        List<MenuItem> items;
        int position = 0;

        public CafeMenuIterator(Dictionary<string, MenuItem> items)
        {
            this.items = new List<MenuItem>(items.Values);
        }
        public bool hasNext()
        {
            return position < items.Count;
        }

        public MenuItem next()
        {
            if (!hasNext())
            {
                throw new InvalidOperationException("Kein weiteres Element vorhanden.");
            }
            return (MenuItem)items[position++];
        }
    }

    //---------------------------------------------------------------------------------------------------

    //Hier werden eigentlich beide Collections instanziiert und man erhält dann mittels waitress-Objekt und PrintMenu() den Zugriff darauf.
    public class Waitress
    {
        PancakeHouseMenu pancakeHouseMenu;
        DinerMenu dinerMenu;
        CafeMenu cafeMenu;
        public Waitress(PancakeHouseMenu pancakeHouseMenu, DinerMenu dinerMenu, CafeMenu cafeMenu)
        {
            this.pancakeHouseMenu = pancakeHouseMenu;
            this.dinerMenu = dinerMenu;
            this.cafeMenu = cafeMenu;
        }

        public void PrintMenu()
        {
            Console.WriteLine("SPEISEKARTE\n----\nFRÜHSTÜCK");
            PrintMenuInternal(pancakeHouseMenu.CreateIterator());
            Console.WriteLine("\nMITTAGESSEN");
            PrintMenuInternal(dinerMenu.CreateIterator());
            Console.WriteLine("\nCafe");
            PrintMenuInternal(cafeMenu.CreateIterator());
        }

        public void PrintMenuInternal(Iterator iterator)
        {
            while (iterator.hasNext())
            {
                MenuItem item = iterator.next();
                Console.WriteLine($"{item.name}, {item.price:0.00} €");
                Console.WriteLine($"  ({item.description})");
                Console.WriteLine($"  {(item.vegetarian ? "[Vegetarisch]" : "[nicht vegan]")}");
            }
        }
    }
}


public class MenuTestDrive
{
    public static void Main(string[] args)
    {
        //dies dient nur der korrekten Darstellung der Geldwerte in der Konsole.
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //---------------------------------------------------------------------


        PancakeHouseMenu pan = new PancakeHouseMenu();
        DinerMenu men = new DinerMenu();
        CafeMenu caf = new CafeMenu();
        Waitress waitress = new Waitress(pan, men,caf);  

        waitress.PrintMenu();
    }
}