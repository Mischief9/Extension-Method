using System;
using System.Collections.Generic;
namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("maita masivi");
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
            IEnumerable<int> newMass = Exist.ThisDoesntMakeAnySense(x => x % 2 == 0 || true, Input);

            IEnumerator<int> NewMassEnumerator = newMass.GetEnumerator();
            Console.Write("1)Default Value When Predicate is true: ");
            while (NewMassEnumerator.MoveNext())
            {
                Console.Write(NewMassEnumerator.Current);
            }

            Console.WriteLine();
            #endregion
            ///////////////////////////////

            ////////////////////////////////
            #region პრედიკატის არ შესრულების შემთხვევაში (ახალი ჩანაწერი)
            IEnumerable<int> newMassForDefault = Exist.ThisDoesntMakeAnySense(x => false, Input);// პრედიკატი არასდროს დაკმაყოფილდება 

            IEnumerator<int> NewMassEnumeratorForDefault = newMassForDefault.GetEnumerator();
            Console.Write("2)New Array When Predicate is false (value+1): ");
            while (NewMassEnumeratorForDefault.MoveNext())
                Console.Write(NewMassEnumeratorForDefault.Current + " ");

            Console.WriteLine();
            #endregion
            ///////////////////////////////

            ////////////////////////////////
            #region პარამეტრების NULL გადაცემა
            try
            {
                IEnumerable<int> newMassNULL = Exist.ThisDoesntMakeAnySense(null, null);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("3)" + e.Message);
            }
            #endregion
            ///////////////////////////////
            Console.ReadLine();
        }

        public static void Input(int[] mass)
        {
            for(int i =0;i<mass.Length;i++)
            {
                mass[i] =mass[i]+1;
            }
        }
    }
}
