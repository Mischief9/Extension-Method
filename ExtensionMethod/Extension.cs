using System;
using System.Collections.Generic;


namespace ExtensionMethod
{
    public static class Extension
    {
       public delegate T[] InputDelegate<T>();
       public static T[] ThisDoesntMakeAnySense<T>(this IEnumerable<T> mass,Predicate<T> pred,InputDelegate<T> newInput)
       { 
            if(mass == null || pred == null || newInput==null)
            {
                throw new NullReferenceException("Invalid Parameter: NULL exception.");
            }

            foreach (var x in mass)
            {
                if(pred(x))
                {
                    return new T[] { default(T) };

                }
            }
            return newInput();
        }
    }
}
