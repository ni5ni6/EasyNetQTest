using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetQTest
{
    public class ConsoleJob : IJob
    {
        public void Execute(Dictionary<string, object> map)
        {
            Console.WriteLine("job executed. context: {0}", map["data"]);
        }
    }
}
