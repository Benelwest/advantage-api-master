using System;
using System.Collections.Generic;



namespace Advantage.API
{
    public class Helpers
    {
        private static string GetRandom(IList<string> items)
        {
            var rand = new Random();
            return items[rand.Next(items.Count)];
        }

        internal static string  MakeCustomerName()
        {
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);
            return prefix + suffix; 
    }


}
