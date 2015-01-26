using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetQTest
{
    public class ScheduledTrigger : ITrigger
    {

        public ScheduledTrigger()
        {
        }

        public string Value
        {
            get { return "Time's up"; }
        }

        public IEnumerable<Rule> GetRules()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> Map { get; set; }

        internal ITrigger WithDataMap(string p)
        {
            if (Map == null)
            {
                Map = new Dictionary<string, object>();
            }

            Map.Add("data", p);

            return this;
        }
    }
}
