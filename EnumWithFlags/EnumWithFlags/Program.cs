namespace EnumWithFlags
{
    public class Program
    {
        [Flags]  //Hiermit wird markiert, das dass binär System genutzt wird.
        public enum UserPermissions
        {
            None = 0,            //Die Zahlen sind gleich dem binär System. 1= 0001, 2=0010,4=0100,8=1000;
            Read = 1,            //Kombination mit allen außer null ist natürlich 1111.
            Write = 2,
            Execute = 4,
            Admin = 8
        }


        public static void Main()
        {
            // UserPermissions permissions = UserPermissions.Read | UserPermissions.Write;
             UserPermissions permissions = (UserPermissions)3;   //Dies erzeugt 1+2, also Read und Write;
            

            //UserPermissions permissions = (UserPermissions)9;    // Dies erzeugt 1+8,also Read und Admin;
            //UserPermissions permissions = (UserPermissions)7;    // Dies erzeugt 1+2+4,also Read,Write und Execute;
            //UserPermissions permissions = (UserPermissions)15;    // Dies erzeugt 1+2+4+8,also Read,Write,Execute und Admin;


            Console.WriteLine($"Berechtigungen: {permissions}");


            if ((permissions & UserPermissions.Read) == UserPermissions.Read)  //Hier muss immer die aktuell gesetzte Variable mit
                                                                               //dem Enum verglichen werden, ob in der Variable
                                                                               //,wie in diesem Fall, Read enthalten ist.
            {     //Dabei muss permissions verwendet werden,weil permissions wie eine Gesamtmenge behandelt wird und z.B. Read eine
                  // Teilmenge des gesamten Enums ist. Wenn also in permissions Read enthalten ist und UserPermissions.Read dies enthält,
                  // wird dies mit UserPermission.Read verglichen. Hier geht es um bitweise Vergleiche und weniger um den logischen Teil.

                // WICHTIG WICHTIG WICHTIG WICHTIG WICHTIG WICHTIG
                // if(permissions & UserPermissions.Read)==UserPermissions.Read          permissions ist z.B. 0011.
                //
                // Das steht oben in der if Bedingung:    0011 & 0001 =0001
                

                Console.WriteLine("Lesezugriff ist gewährt.");
            }

            if ((permissions & UserPermissions.Execute) == UserPermissions.Execute)
            {
                Console.WriteLine("Ausführungszugriff ist gewährt.");
            }
            else
            {
                Console.WriteLine("Kein Ausführungszugriff.");
            }


            //Dies sind Möglichkeiten, mittels OR neue Flags hinzuzufügen.
            // permissions |= UserPermissions.Execute;
            //permissions |= (UserPermissions)4;



            Console.WriteLine($"Neue Berechtigungen: {permissions}");  

        }

    }











}