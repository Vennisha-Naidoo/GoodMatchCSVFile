/*******************************************
THE COMMENTS for most of the was done done
in part one of the question. That file
exists in main, with this
*******************************************/

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace CSVFileInput
{
    class Program
    {
        public static String toMatch1;

        static String MatchingLetters(string toMatch)
        {
            toMatch1 = toMatch = toMatch.Replace(" ", "");

            int counter;
            int matching;


            String finalnumber = "";

            for (int s = 0; s < toMatch1.Length; s++)
            {
                matching = 1;
                counter = s + 1;

                if (s == toMatch1.Length - 1)
                {
                    finalnumber = finalnumber + matching.ToString();
                }

                for (int i = s; counter < toMatch1.Length; counter++)
                {

                    if (counter == toMatch1.Length - 1)
                    {

                        if (toMatch1[i] == toMatch1[counter])
                        {

                            matching++;

                            toMatch1 = toMatch1.Remove((counter), 1);

                            finalnumber = finalnumber + matching.ToString();
                        }
                        else
                        {

                            finalnumber = finalnumber + matching.ToString();

                        }

                    }
                    else if (toMatch1[i] == toMatch1[counter])
                    {

                        matching++;

                        toMatch1 = toMatch1.Remove((counter), 1);

                        counter--;

                    }

                }
            }

            return finalnumber;
        }

        public static string gettingpercentage(string number)
        {
            String percentage = "";

            for (int i = 0; i < number.Length; i++)
            {


                double md = number.Length / 2;

                double middle = Math.Ceiling(md);

                if (i >= middle && number.Length % 2 == 0)
                {


                    break;

                }
                else if (i == middle && number.Length % 2 > 0)
                {

                    percentage = percentage + number[(int)middle].ToString();

                    break;

                }
                else
                {
                    percentage = percentage + ((int)Char.GetNumericValue(number[i]) + (int)Char.GetNumericValue(number[number.Length - (i + 1)])).ToString();
                }

            }

            return percentage;

        }

        //Defining a new method
        static void PeopleInput()
        {

            //Asking for input of first persons name
            Console.WriteLine("Person One: ");
            //Taking string input, first persons name
            string PersonOne = Console.ReadLine();

            //Asking for input of first persons name
            Console.WriteLine("Person Two: ");
            //Taking string input, first persons name
            string PersonTwo = Console.ReadLine();

            if ((Regex.IsMatch(PersonOne, @"^[a-zA-Z]+$")) && (Regex.IsMatch(PersonTwo, @"^[a-zA-Z]+$")))
            {
                string Sentence = PersonOne + " matches " + PersonTwo;


                String firstpart = MatchingLetters(Sentence);

                String part2 = gettingpercentage(firstpart);

                do
                {
                    part2 = gettingpercentage(part2);

                } while (part2.Length > 2);


                if (Int32.Parse(part2) >= 80)
                {

                    Console.WriteLine(Sentence + " " + part2 + "%, good match");

                }
                else
                {

                    Console.WriteLine(Sentence + " " + part2 + "%");

                }


            }
            else
            {
                Console.WriteLine("Invalid. Try Again.");
                //Clears the console
                Console.Clear();
                //RECURSION of the method - It will be called until/unless the input is correct
                PeopleInput();
            }

        }


        //Method is being overloadded
        //Modified to take in two parameters, rather than user input
        static void PeopleInput(String x, String y)
        {

            string Sentence = x + " matches " + y;


            String firstpart = MatchingLetters(Sentence);

            String part2 = gettingpercentage(firstpart);

            do
            {
                part2 = gettingpercentage(part2);

            } while (part2.Length > 2);


            if (Int32.Parse(part2) >= 80)
            {

                Console.WriteLine(Sentence + "\t\t" + part2 + "%, good match");

            }
            else
            {

                Console.WriteLine(Sentence + "\t\t" + part2 + "%");

            }


        }


        public static void Main(string[] args)
        {
            //declaration of arrays - It saves each persons details
            string[] Females = new string[5];
            string[] Males = new string[5];

            int maleCount = 0, femaleCount = 0;// Intialised to zero

            //Finding file path
            var lines = File.ReadAllLines("GraduateAssessment.csv");
            foreach (var line in lines)// reading each line of file
            {
                //Last index of line
                int lastChar = line.Length - 1;
                //Last index finds the last character, which is the gender
                string gen = line.Substring(lastChar);

                //checking if male or female
                if (gen == "m")
                {
                    //adding line to array Male[], if last character is 'm'
                    Males[maleCount] = line;
                    //Increment
                    maleCount++;
                }
                else if (gen == "f")
                {
                    //adding line to array Female[], if last character is 'f'
                    Females[femaleCount] = line;
                    //Increment
                    femaleCount++;
                }


            }

            Console.WriteLine("****************************");


            Males = Males.Distinct().ToArray();//Removes any duplicates in array

            Console.WriteLine("Males: ");
            for (int i = 0; i < Males.Length; i++)//looping through Male[] and displaying
            {
                Console.WriteLine(Males[i]);

            }

            Console.WriteLine("\n****************************");


            Females = Females.Distinct().ToArray();//Removes any duplicates in array

            Console.WriteLine("Females: ");
            for (int i = 0; i < Females.Length; i++)//looping through Female[] and displaying
            {
                Console.WriteLine(Females[i]);

            }

            Console.WriteLine("\n****************************");

            //Nested for-loop - The Good match code will run for each male matched with each female, in the CSV file
            //Outter-loop Female
            for (int x = 0; x < Males.Length; x++)
            {
                int counter = 0;//counter intialised to zero

                //inner-loop is Female
                for (int i = x; counter < Females.Length; counter++)
                {
                    //once condition is met, break loop
                    if (counter == Females.Length - 2)
                    {

                        //Split getting the name
                        string[] twoparts = Males[i].Split(',');

                        //assigning the split to 'malename' variable
                        String malename = twoparts[0];

                        //Split getting the name
                        string[] twoparts2 = Females[counter].Split(',');

                        //assigning the split to 'malename' variable
                        String femalename = twoparts2[0];

                        //Passing arguments, 'malename' and 'female'
                        PeopleInput(malename, femalename);

                        break;

                    }
                    else
                    {

                        string[] twoparts = Males[i].Split(',');

                        String malename = twoparts[0];

                        string[] twoparts2 = Females[counter].Split(',');

                        String femalename = twoparts2[0];

                        PeopleInput(malename, femalename);

                    }

                }


            }











        }

    }

}

