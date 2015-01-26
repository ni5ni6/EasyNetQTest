using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetQTest
{
    public interface IJob
    {
        void Execute(Dictionary<string, object> map);
    }
}
