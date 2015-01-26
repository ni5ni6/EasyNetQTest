using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetQTest
{
    public class RuleEngine
    {
        public static void Handle(ITrigger trigger)
        {
            var rules = Rules.GetByTrigger(trigger);
            foreach (Rule rule in rules)
            {
                if (rule.Evaluator.Evaluate(trigger))
                {
                    var map = trigger.Map;
                    rule.Job.Execute(map);
                }
            }
        }

    }
}
