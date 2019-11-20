using System;
using System.Collections.Generic;
namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input Array");
            Console.WriteLine();
            string FutureArray = Console.ReadLine();

            char[] seperator = new char[] { ' ', ',' };                 //-//
            string[] elementsAsString = FutureArray.Split(seperator, StringSplitOptions.RemoveEmptyEntries);   //-//

            int[] Exist = new int[elementsAsString.Length];
            #region Validation
            try
            {
                for (int i = 0; i < Exist.Length; i++)
                {
                    Exist[i] = Int32.Parse(elementsAsString[i]);
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Filling with some values... (10 Value)");
                Random rand = new Random();

                Exist = new int[10];
                Console.Write("New Values : ");
                for (int i = 0; i < 10; i++)
                {
                    Exist[i] = rand.Next(300);
                    Console.Write(Exist[i] + " ");
                }
            }
            #endregion

            Console.WriteLine();
            ////////////////////////////////
            #region პრედიკატის დაკმაყოფილება 

            Exist.ThisDoesntMakeAnySense(x => x % 2 == 0 || true, ()=> { return null; });
            Console.WriteLine();

            #endregion
            ///////////////////////////////

            ////////////////////////////////
            #region პრედიკატის არ შესრულების შემთხვევაში (ახალი ჩანაწერი)

            Exist.ThisDoesntMakeAnySense(x => false, ()=> { Random x = new Random();
                                                            return new int[] { x.Next(600), x.Next(600) }; });// პრედიკატი არასდროს დაკმაყოფილდება 
            Console.WriteLine();

            #endregion
            ///////////////////////////////

            ////////////////////////////////
            #region პარამეტრების NULL გადაცემა
            try
            {
              Exist.ThisDoesntMakeAnySense(null, null);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("3)" + e.Message);
            }
            #endregion
            ///////////////////////////////
            Console.ReadLine();
        }
    }
}
