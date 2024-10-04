namespace Leetcode
{
    class MinimumJumps
    {


        static int MinJump(int[] nums)
        {
            int totalJumps = 0;
            int destination = nums.Length - 1; //Ziel ist letzter Eintrag des Arrays
            int coverage = 1; //Bereich, in dem gesprungen werden kann. Bspl 4 - bedeutet coverage 1,2,3,4
            int lastJumpIndex = 0;    //dient der Markierung im Array für maximale Weite


            //nur ein Eintrag, somit keine Sprünge möglich
            if (nums.Length <= 1)
            {
                Console.WriteLine("Keine Sprünge möglich:");
                return 0;
            }


            for (int i = 0; i < nums.Length; i++)
            {
                coverage = Math.Max(coverage, i + nums[i]); //hier wird die maximale Sprungweite ermittelt

                if (i == lastJumpIndex)                             //wenn Marker mit Sprungweite übereinstimmt
                {
                    lastJumpIndex = coverage;
                    totalJumps++;

                    if (coverage >= destination) //wenn der letzte Arrayeintrag erreicht werden kann
                    {
                        Console.WriteLine("Anzahl der minimalen Sprünge durch das Array: " + totalJumps);
                        return totalJumps;
                    }
                }
            }
            Console.WriteLine("Anzahl der minimalen Sprünge durch das Array: " + totalJumps);
            return totalJumps;
        }
        public static void Main(string[] args)
        {
            int[] nums = { 6, 4, 1, 2, 3, 1, 1, 2 };


            MinJump(nums);



        }


    }
}

