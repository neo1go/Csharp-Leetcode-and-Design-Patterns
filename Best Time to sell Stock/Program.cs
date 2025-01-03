
//Greedy Approach bei dem der Maximal-Wert ermitellt werden muß.
// Es wird immer i mit dem buyPrice verglichen wobei buyPrice immer um 1 weitergesetzt wird.
//Es wird auch mit 1 angefangen beim Iterieren da 0 als erster Wert gilt und dann später erhöht wird nach einem
//kompletten Durchlauf.

public class Program
{
    
    static int maxProfit(int[] prices)
    {
        //dynamic programming 
        int buyPrice = prices[0]; //fängt mit erstem Wert im Array an

        int profit = 0; //Gewinnwert, der später mit Math.Max ermittelt wird.

        for (int i = 1; i < prices.Length; i++)
        {

            if (prices[i] < buyPrice)// hier wird der niedrigste Kaufwert ermittelt im Array im Vergleich zum ersten
                                      //Wert im Array der als Anfangskaufpreis gilt
            {
                buyPrice = prices[i];
            }
            else
            {
                //wird ausgeführt, wenn kein neuer niedrigster Preis besteht, also die maximale Gewinnspanne - WICHTIG
                int currentProfit = prices[i] - buyPrice;
                profit = Math.Max(profit, currentProfit);

            }
        }
        Console.WriteLine("Der maximale Profit liegt bei " + profit);
        return profit;

    }
    public static void Main(string[] args)
    {
        int[] prices = [10, 5, 16, 5, 6, 47, 8];
        maxProfit(prices);

        //bying at lowest price, selling at highest price

        /*
         * Brute force Method
        int[] stockItems = [10, 7, 11, 11, 3, 9, 5];


        int maxValue = 0;


        for (int i = 0; i < stockItems.Length - 1; i++)
        {

            for (int j = i + 1; j < stockItems.Length; j++)//j=i+1 sehr wichtig, da sonst wieder von vorne verglichen wird
            {

                if ((stockItems[j] > stockItems[i]))
                {
                    maxValue = Math.Max(maxValue, (stockItems[j] - stockItems[i]));

                }

            }

        }


        Console.WriteLine("Der maximale Gewinn ist " + maxValue + " hoch");

        */

    }

}

