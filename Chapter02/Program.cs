using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;

namespace Chapter02
{
    class Program
    {
        static void Main()
        {
            WorkflowInvoker.Invoke(CreateWorkflow());
            Console.WriteLine("Press ENTER to exit"); Console.ReadLine();
        }

        static Activity CreateWorkflow()
        {
            var numberBells = new Variable<int>()
            {
                Name = "numberBells",
                Default = DateTime.Now.Hour
            };
            var counter = new Variable<int>()
            {
                Name = "counter",
                Default = 1
            };

            return new Sequence()
            {
                DisplayName = "Main Sequence",
                Variables = {numberBells, counter},
                Activities =
                {
                    new WriteLine()
                    {
                        DisplayName =  "Hello",
                        Text = "Hello, World!"
                    },
                    new If()
                    {
                        DisplayName = "Adjust for PM",
                        Condition = ExpressionServices.Convert
                            (env => numberBells.Get(env) > 12),
                        Then = new Assign<int>()
                        {
                            DisplayName = "Adjust Bells",
                            To = new OutArgument<int>(numberBells),
                            Value = new InArgument<int>(env => numberBells.Get(env) - 12)
                        }

                    },
                    new While()
                    {
                        DisplayName = "Sound Bells",
                        Condition = ExpressionServices.Convert<bool>
                            (env => counter.Get(env) <= numberBells.Get(env)),
                        Body = new Sequence()
                        {
                            DisplayName = "Sound Bell",
                            Activities =
                            {
                                new WriteLine()
                                {
                                    Text = new InArgument<string>(env => counter.Get(env).ToString())
                                },
                                new Assign<int>()
                                {
                                    DisplayName = "Increment Counter",
                                    To = new OutArgument<int>(counter),
                                    Value = new InArgument<int>(env => counter.Get(env) + 1)
                                },
                                new Delay()
                                {
                                    Duration = TimeSpan.FromSeconds(1)
                                }

                            }
                        }
                    },
                    new WriteLine()
                    {
                        DisplayName = "Display Time",
                        Text = $"The time is: {DateTime.Now}"
                    },
                    new If()
                    {
                        DisplayName = "Greeting",
                        Condition = ExpressionServices.Convert<bool>
                            (env => DateTime.Now.Hour >= 18),
                        Then = new WriteLine() {Text = "Good Evening" },
                        Else = new WriteLine() {Text = "Good Day" }
                    }
                }
            };

        }
    }
}
