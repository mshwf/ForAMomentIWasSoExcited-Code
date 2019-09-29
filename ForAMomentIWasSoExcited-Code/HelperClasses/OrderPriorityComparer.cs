using System.Collections.Generic;

namespace ForAMomentIWasSoExcited_Code.HelperClasses
{
    class OrderPriorityComparer : IComparer<KeyValuePair<string, string>>
    {
        public int Compare(KeyValuePair<string, string> x, KeyValuePair<string, string> y)
        {
            if (x.Value.CompareTo(y.Value) == 0)
            {
                return x.Key.CompareTo(y.Key);
            }
            else
                return x.Value.CompareTo(y.Value);
        }
    }
}
