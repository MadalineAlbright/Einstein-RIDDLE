using System;
using System.Collections.Generic;


/*GROUP MEMBERS
 * 1.Betty Kutto - 114436
 * 2.Einstein - 112302
 * 3.Madaline Albright - 106392
 * 4.Agnes Anindo - 111840
 */


namespace Einstein_s_Riddle

{
    //Declaration
    public enum Nationality { Englishman = 1, Swede, Dane, Norwegian, German }
    public enum Color { Blue = 1, Red, Green, white, yellow }
    public enum Drinks { Coffee = 1, Tea, Milk, Beer, Water }
    public enum Cigar_Brand { PallMall = 1, Dunhill, Blend, BlueMaster, Prince }
    public enum Pet { Dogs = 1, Cats, Birds, Horse, Fish }
    class Program
    {
        static void Main(string[] args)

        {
            DateTime begin = DateTime.Now;//Calculates how many milliseconds are required to run from begin to end
            string positions = "12345";// 1. There are 5 houses
            string[] combs = Combinations(positions);   //Define positions and calculate possible combinations 
            int solutions = 0;

            for (int nat = 0; nat < combs.Length; nat++) 
            {
                if (Check_Requirement(10, combs[nat]))
                { 
                for (int colr = 0; colr < combs.Length; colr++)
                {
                        if ((Check_Requirement(2, combs[nat], combs[colr]) == true) &&
                           (Check_Requirement(6, combs[nat], combs[colr]) == true)&&
                           (Check_Requirement(15, combs[nat], combs[colr]) == true))
                        {
                            for (int dri = 0; dri < combs.Length; dri++)
                            {
                                if ((Check_Requirement(4, combs[nat], combs[colr], combs[dri]) == true) &&
                                    (Check_Requirement(5, combs[nat], combs[colr], combs[dri]) == true) &&
                                    (Check_Requirement(9, combs[nat], combs[colr], combs[dri]) == true)&&
                                    (Check_Requirement(16, combs[nat], combs[colr], combs[dri]) == true))

                                {
                                    for (int cgr = 0; cgr < combs.Length; cgr++)
                                    {
                                        if ((Check_Requirement(8, combs[nat], combs[colr], combs[dri], combs[cgr]) == true)&&
                                           (Check_Requirement(13, combs[nat], combs[colr], combs[dri], combs[cgr]) == true)&&
                                           (Check_Requirement(14, combs[nat], combs[colr], combs[dri], combs[cgr]) == true))
                                            {


                                            for (int pet = 0; pet < combs.Length; pet++)
                                            {
                                                if ((Check_Requirement(3, combs[nat], combs[colr], combs[dri], combs[cgr], combs[pet]) == true) &&
                                                    (Check_Requirement(7, combs[nat], combs[colr], combs[dri], combs[cgr], combs[pet]) == true)&&
                                                    (Check_Requirement(11, combs[nat], combs[colr], combs[dri], combs[cgr], combs[pet]) == true)&&
                                                    (Check_Requirement(12, combs[nat], combs[colr], combs[dri], combs[cgr], combs[pet]) == true))
                                                {
                                                    solutions = solutions + 1;
                                                    Display_Results(solutions, combs[nat], combs[colr], combs[dri], combs[cgr], combs[pet]);
                                                }

                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            DateTime end = DateTime.Now;
            double diff = (end - begin).TotalMilliseconds;
            Console.WriteLine("Solved in" + diff.ToString() + "millisecond");
            Console.ReadKey();
        }

        /* we will use indexOf to search within the colors and find the position of the red one and use it to read the nationality link using the substring.
           We will match it with the nationality we are looking for which is the Englishman
           We will convert the normal value to a string to simplify the search
           indexOf() method search for the substring in string and returns the position of the first occurrence of a specified substring
        */
        public static bool Check_Requirement(int number,string nat, string colr = "", string dri = "", string cgr = "", string pet = "")
        {
            switch(number)
            {
                case 2://The Englishman(Brit) lives in the red house
                   
                  if (nat.Substring(colr.IndexOf(((int)Color.Red).ToString()), 1 ) == ((int)Nationality.Englishman).ToString())
                    {
                        return true;
                    }

                        break;
               
                case 3://The Swede owns the dog
                    if (nat.Substring(pet.IndexOf(((int)Pet.Dogs).ToString()), 1) == ((int)Nationality.Swede).ToString())
                    {
                        return true;
                    }

                    break;

                case 4://The Green house owner drinks coffee
                    if (dri.Substring(colr.IndexOf(((int)Color.Green).ToString()), 1) == ((int)Drinks.Coffee).ToString())
                    {
                        return true;
                    }

                    break;

                case 5://The Dane drinks tea
                    if (dri.Substring(nat.IndexOf(((int)Nationality.Dane).ToString()), 1) == ((int)Drinks.Tea).ToString())
                    {
                        return true;
                    }

                    break;

                case 6://The green house is to the left of the white house
                    if(colr.IndexOf(((int)Color.Green). ToString()) - colr.IndexOf(((int)Color.white).ToString()) == 1)//Calculate the difference between the two positions, if result is 1 then the requirement is matched.
                    {
                        return true;
                    }
                    break;

                case 7://the person who smokes Pall Mall rears birds
                    if (cgr.Substring(pet.IndexOf(((int)Pet.Birds).ToString()), 1) == ((int)Cigar_Brand.PallMall).ToString())
                    {
                        return true;
                    }
                    break;

                case 8://The owner of the yellow house smokes Dunhill
                    if (cgr.Substring(colr.IndexOf(((int)Color.yellow).ToString()), 1) == ((int)Cigar_Brand.Dunhill).ToString())
                    {
                        return true;
                    }
                    break;

                case 9://The man living in the center house drinks milk
                    if (dri.Substring(2,1) == ((int)Drinks.Milk).ToString())
                    {
                        return true;
                    }
                    break;
                case 10://The Norwegian lives in the first house

                    if (nat.Substring(0, 1) == ((int)Nationality.Norwegian).ToString())
                    {
                        return true;
                    }
                    break;

                case 11: //the man who smokes blends lives next to the one who keeps cats
                    if(Math.Abs(cgr.IndexOf(((int)Cigar_Brand.Blend).ToString()) - pet.IndexOf(((int)Pet.Cats).ToString())) == 1)//Calculates the absolute values of te positions
                    {
                        return true;
                    }
                    break;

                case 12: //the man who keeps horses lives next to the man who smokes Dunhill
                    if (Math.Abs(pet.IndexOf(((int)Pet.Horse).ToString()) - cgr.IndexOf(((int)Cigar_Brand.Dunhill).ToString())) == 1)
                    {
                        return true;
                    }
                    break;

                case 13: //the owner who smokes BlueMaster drinks beer
                    if (cgr.Substring(dri.IndexOf(((int)Drinks.Beer).ToString()), 1) == ((int)Cigar_Brand.BlueMaster).ToString())
                    {
                        return true;
                    }
                    break;

                case 14: //the German smokes Prince
                    if (cgr.Substring(nat.IndexOf(((int)Nationality.German).ToString()), 1) == ((int)Cigar_Brand.Prince).ToString())
                    {
                        return true;
                    }
                    break;

                case 15: //the Norwegian lives next to the blue house
                    if (Math.Abs(colr.IndexOf(((int)Color.Blue).ToString()) - nat.IndexOf(((int)Nationality.Norwegian).ToString())) == 1)
                    {
                        return true;
                    }
                    break;

                case 16: //the man who smokes blends has a neighbor who drinks water
                    if (Math.Abs(dri.IndexOf(((int)Drinks.Water).ToString()) - cgr.IndexOf(((int)Cigar_Brand.Blend).ToString())) == 1)
                    {
                        return true;
                    }
                    break;

                default:
                    break;
            }
            return false;
        }
        public static void Display_Results(int solution, string nationality, string color, string drinks, string cigar, string pets)
        {

            Console.WriteLine("Solution" + solution.ToString());
            Console.WriteLine();
            Console.Write(string.Format("{0, -1} | ", "P"));
            Console.Write(string.Format("{0, -6} | ", "Color"));
            Console.Write(string.Format("{0, -11} | ", "NATIONALITY"));
            Console.Write(string.Format("{0, -12} | ", "DRINKS"));
            Console.Write(string.Format("{0, -12} | ", "CIGAR"));
            Console.Write(string.Format("{0, -6} | ", "PET"));

            Console.WriteLine();

            for (int c=0; c<color.Length; c++)
            {
                Console.Write(string.Format("{0, -1} |", (c+1)));
                Console.Write(string.Format("{0, -6} | ", ((Color)Convert.ToInt32(color.Substring(c,1))).ToString()));
                Console.Write(string.Format("{0, -11} | ", ((Nationality)Convert.ToInt32(nationality.Substring(c, 1))).ToString()));
                Console.Write(string.Format("{0, -12} | ", ((Drinks)Convert.ToInt32(drinks.Substring(c, 1))).ToString()));
                Console.Write(string.Format("{0, -12} | ", ((Cigar_Brand)Convert.ToInt32(cigar.Substring(c, 1))).ToString()));
                Console.Write(string.Format("{0, -6} | ", ((Pet)Convert.ToInt32(pets.Substring(c, 1))).ToString()));
                Console.WriteLine();
            }

            Console.WriteLine();

        }
        public static string[] Combinations(String positions)
        {
            //Define a list of strings that will contain the combinations
            List<string> combs = new List<string>();
            for (int c = 0; c < positions.Length; c++)
            {
                //We will consider each element one by one inside the string
                string single = positions.Substring(c, 1);
                //If its empty we will take a single combination as a single element ie A
                if (combs.Count == 0)
                {
                    combs.Add(single);
                }
                //Otherwise we will declare a new combination list to be used for calculations
                else
                {
                    List<string> newcombs = new List<string>();
                    for (int current = 0; current < combs.Count; current++)
                    {
                        for (int pos=0; pos<combs[current].Length; pos++)
                        {
                            newcombs.Add(combs[current].Substring(0, pos) + single + combs[current].Substring(pos));
                        }

                        newcombs.Add(combs[current] + single);

                    }

                    combs = newcombs;
                }

            }
            return combs.ToArray();
        }
    }
}

