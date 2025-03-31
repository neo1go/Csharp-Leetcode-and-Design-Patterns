using System;
namespace ValidSquare367 {

    //Leetcode 367
    //Es soll ohne sqrt Funktion herausgefunden werden, ob von einer Zahl die Wurzel gezogen werden kann.
    //Bei der ersten Variante wird mittels binary search der Mittelpunkt des binary search quadriert,
    //bis der Wert getroffen wird falls die Zahl eine echte Quadratzahl ist. Es wird immer jede Zahl
    // überprüft.
    //Bei der 2ten Variante wird immer auf den ungeraden Zahlen iteriert,da diese 
    public class Program
    {

        public bool ValidSquare(int num)
        {
            /*  // Klassische Variante
            bool result=false;

            int[] nums = new int[num];
            for (int i = 0; i < num; i++)
            {
                nums[i] = i + 1;
            }

            int left = nums[0];      //linker Pointer
            int m = nums.Length/2;  //Mittelpunkt
            int right = nums.Length; //recher Pointer
            //läuft nur durch die Länge der Nummernrange
            for(int i = 0; i<nums.Length;i++)
            {
                while( left<= right){
                //trifft genau
                 if(nums[m]*nums[m]==num){
                     return true;
                 }
                //Quadrierung ist kleiner als Zahl
                 else if(nums[m]*nums[m]<num)
                 {             
                    left=m+1;  
                 }
                //ist größer als Zahl
                else
                {             
                    right=m-1;
                }
                    m=(left+right)/2;
                }
            }     
            return result;
            */
            //Neue Variante 
            //Sequenzlösung da jede Quadratwurzel minus vorherige Quadratwurzel die nächste 
            //ungerade Zahl der Sequenz ergibt 1,4,9,16,25,36,49
            int oddNumber = 1;
            int sum = 1;
            while (sum <= num)//nur solange bis Zahl erreicht wurde
            {
                if (sum == num)
                {
                    return true;
                }
                oddNumber += 2;//also wird sum zu 3,5,7,9 usw.
              

                //Der Trick ist, das jede Quadrahtzahl minus der vorherigen Quadrahtzahl eine ungerade Zahl
                //einer aufsteigenden Sequenz ergibt.
                //2^0=0 2^1=1 2^2=4 2^3=8 2^4=16 normale Quadratzahlen
                //1-0=1, Quadrat 4-1=3, Quadrat 9-4=5, Quadrat 16-9=7, Quadrat 25-16=9, also Quadratwurzel minus vorherige Quadratwurzel
                //ergibt immer die nächste ungerade Zahl: 1,3,5,7,9,11,13,15,17,19 usw
                sum += oddNumber; //wenn die sum genau auf num trifft, ist es eine Quadratzahl
            }
            return false;
        }


        public static void Main(string[] args)
        {
            Program program = new Program();
            int num = 16;
            bool result = program.ValidSquare(num);
            Console.WriteLine(result);
        }
    }



}