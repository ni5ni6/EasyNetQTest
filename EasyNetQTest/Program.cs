using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;

namespace EasyNetQTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // design time

            //AssetStringStateChangeTriggerEvaluator evaluator = new AssetStringStateChangeTriggerEvaluator("test1");

            //Rules.Add(evaluator, new ConsoleJob());
            //Rules.Add(evaluator, new ConsoleJob());

            // runtime

            using (var bus = RabbitHutch.CreateBus("host=att-2.cloudapp.net;virtualHost=dev;username=AttAdmin;password=Att953953;requestedHeartbeat=10"))
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    if (input == "sch")
                    {
                        bus.Publish<ITrigger>(new ScheduledTrigger().WithDataMap(DateTime.UtcNow.ToString()));
                        continue;
                    }
                    
                    bus.Publish<ITrigger>(new AssetNewState(input).WithDataMap("asset1"));
                }
            }

        }

    }
}
