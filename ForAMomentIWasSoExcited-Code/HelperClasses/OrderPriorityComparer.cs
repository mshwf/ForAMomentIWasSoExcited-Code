using System.Collections.Generic;

namespace ForAMomentIWasSoExcited_Code.HelperClasses
{
    //{ "zld 93 12", "fp iPad Mini", "10a Galaxy Note 10", "17g 12 25 6", "ab1 iPad Mini", "125 Galaxy Note 10 Plus" }
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