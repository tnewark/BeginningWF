using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace Chapter01
{

    class Program
    {
        static void Main(string[] args)
        {
            Activity workflow1 = new Workflow1();
            WorkflowInvoker.Invoke(workflow1);

            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
    }
}
