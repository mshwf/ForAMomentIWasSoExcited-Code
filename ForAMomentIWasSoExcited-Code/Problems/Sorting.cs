using ForAMomentIWasSoExcited_Code.HelperClasses;
using System.Collections.Generic;
using System.Linq;

namespace ForAMomentIWasSoExcited_Code.Problems
{
    public class Sorting
    {
        //every order in the orderList is represented by a space delimieted string, first part (before first space) is id,
        //after first space is the metadata, if metadata contains letters then this order has higher priority.
        //sort orders where higher priority orders come first (lexicographically order), order by the metadata, if two orders has same metadata, then order by ID,
        //non higher priority orders, come in its original order, last.

        //orderList example: {"zld 93 12", "fp iPad Mini", "10a Galaxy Note 10", "17g 12 25 6", "ab1 iPad Mini", "125 Galaxy Note 10 Plus"}
        public static List<string> PrioritizedOrders(int numOrders, string[] orderList)
        {
            IDictionary<string, string> prime = new Dictionary<string, string>();
            List<string> nonPrime = new List<string>();

            for (int i = 0; i < numOrders; i++)
            {
                var order = orderList[i];

                var splitted = order.Split(new char[] { ' ' }, 2);
                if (char.IsLetter(splitted[1][0]))
                    prime.Add(splitted[0], splitted[1]);
                else
                    nonPrime.Add(order);
            }
           
            var xprime = prime.OrderBy(x => x, new OrderPriorityComparer()).Select(x => x.Key + " " + x.Value).ToList();

            xprime.AddRange(nonPrime);
            return xprime;
        }
    }
}
