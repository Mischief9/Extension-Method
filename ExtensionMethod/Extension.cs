using System;
using System.Collections.Generic;


namespace ExtensionMethod
{
    public static class Extension
    {
       public delegate T[] InputDelegate<T>();
       public static void ThisDoesntMakeAnySense<T>(this IEnumerable<T> mass,Predicate<T> pred,InputDelegate<T> newInput)
       { 
            if(mass == null || pred == null || newInput==null)
            {
                throw new NullReferenceException("Invalid Parameter: NULL exception.");
            }

            foreach (var x in mass)
            {
                if(pred(x))
                {
                  Console.Write("1)Default Value When Predicate is true: ");
                  if (default(T) == null)
                       Console.Write("NULL");
                  else Console.Write(default(T)); 
                  return;

                }
            }
            Console.Write("2)New Array When Predicate is false (2 value) : ");
            mass = newInput();
            foreach(var x in mass)
            {
                Console.Write(x + " ");
            }
        }
    }
}
