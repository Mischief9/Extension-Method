using System;
using System.Collections.Generic;


namespace ExtensionMethod
{
    public static class Extension
    {
       public delegate void InputDelegate<T>(T[] mass);
       public static  IEnumerable<T> ThisDoesntMakeAnySense<T>(this T[] mass,Predicate<T> pred,InputDelegate<T> newInput)
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
            newInput(mass);
            return mass;
        }
    }
}
