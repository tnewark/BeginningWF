using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess
{
    public static class OrderDiscount
    {
        public static decimal ComputeDiscount(Order o, decimal total)
        {
            // count number of items ordered
            var count = o.Items.Sum(i => i.Quantity);

            // determine the discount percentage
            var pct = 0m;
            if (total > 500)
                pct = 0.2m;
            else if (total > 200)
                pct = .15m;
            else if (total > 100)
                pct = .1m;

            // calculate the discount amount
            var discount = total*pct;

            // Subtract a dollar for every item ordered
            discount -= (decimal) count;

            // Make sure it's not less than zero
            if (discount < 0) discount = 0;

            Console.WriteLine($"Discount computed: {discount}");
            return discount;

        }
    }
}
