using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess
{
    public sealed class LookupItem : CodeActivity
    {
        public InArgument<string> ItemCode { get; set; }

        public OutArgument<ItemInfo> Item { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var i = new ItemInfo {ItemCode = context.GetValue(ItemCode)};

            switch (i.ItemCode)
            {
                case "12345":
                    i.Description = "Widget";
                    i.Price = 10.0m;
                    break;
                case "12346":
                    i.Description = "Gadget";
                    i.Price = 15.0m;
                    break;
                case "12347":
                    i.Description = "Super Gadget";
                    i.Price = 25.0m;
                    break;
            }
            context.SetValue(Item, i);
        }
    }
}
