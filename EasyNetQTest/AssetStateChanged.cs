using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetQTest
{
    public class AssetNewState : ITrigger
    {
        string value;

        public AssetNewState(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return this.value; }
        }

        public IEnumerable<Rule> GetRules()
        {
            return new List<Rule>();
        }

        public Dictionary<string, object> Map { get; set; }

        internal ITrigger WithDataMap(string p)
        {
            if(Map == null)
            {
                Map = new Dictionary<string, object>();
            }

            Map.Add("data", p);

            return this;
        }
    }
}
