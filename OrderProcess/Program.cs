using System;
using System.Activities;
using System.Collections.Generic;

namespace OrderProcess
{

    class Program
    {
        static void Main()
        {
            var myOrder = new Order
            {
                OrderId = 1,
                Description = "Need some stuff",
                ShippingMethod = "2ndDay",
                TotalWeight = 100

            };

            myOrder.Items.Add(new OrderItem
            {
                OrderItemId = 1,
                Quantity = 1,
                ItemCode = "12345",
                Description = "Widget"
            });

            myOrder.Items.Add(new OrderItem
            {
                OrderItemId = 2,
                Quantity = 3,
                ItemCode = "12346",
                Description = "Gadget"
            });

            myOrder.Items.Add(new OrderItem
            {
                OrderItemId = 3,
                Quantity = 2,
                ItemCode = "12347",
                Description = "Super Widget"
            });



            var input = new Dictionary<string, object>
            {
                {"OrderInfo", myOrder}
            };



            var output = WorkflowInvoker.Invoke(new OrderWF(), input);

            var total = (decimal) output["TotalAmount"];
            Console.WriteLine($"Workflow returned ${total} for my order total");

            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
    }
}
