using Microsoft.Win32.SafeHandles;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static int[] sortedSquares(int[] nums)
    {
        int[] result = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            //hier wird quadriert
            nums[i] = nums[i] * nums[i];
        }
        //Definition der 2 Pointer, die aufeinander zulaufen
        int head = 0;
        int tail = nums.Length - 1;

     //da der größte Wert entweder nur an [0] oder [ArrayEnde] sein kann, wird der neue Array von hinten beschrieben 
        for (int pos = nums.Length - 1; pos >= 0; pos--)
        {
     //hiermit wird immer der größte Wert eingetragen während der Array von hinten nach vorne befüllt wird
            if (nums[head] > nums[tail])
            {
                result[pos] = nums[head];
               // Console.WriteLine(result[pos]);
                head++;
            }
            else
            {
                result[pos] = nums[tail];
               // Console.WriteLine(result[pos]);
                tail--;
            }
        }
        for (int i = 0; i <= result.Length - 1; i++)
        { 
                Console.Write(result[i]+" ");
               
        }
        return result;    



    }

    public static void Main(string[] args)
    {

        //Bedingung: Array ist sorted asc.    In diesem Beispiel ist -25*-25=625 größer als 16*16=256
        int[] nums = [-25, -11, -10, -3, 4, 5, 7, 12, 16];


        Console.WriteLine("Für jeden Eintrag im sortierten Array ");
        foreach (int i in nums) 
        {
            Console.Write(i+" ");
        }

        Console.WriteLine("\n\n");
        
        Console.WriteLine("ergibt sich quadriert die Reihenfolge ");
        sortedSquares(nums);
       
        Console.ReadKey();
    }


}
