using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;

namespace EasyNetQTest.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=att-2.cloudapp.net;virtualHost=dev;username=AttAdmin;password=Att953953;requestedHeartbeat=10"))
            {
                bus.Subscribe<ITrigger>("triggerHandler", HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleTextMessage(ITrigger message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", message);
            Console.ResetColor();

            RuleEngine.Handle(message);
        }
    }
}
