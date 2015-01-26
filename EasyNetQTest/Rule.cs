using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetQTest
{
    public class Rule
    {
        public string Uid { get; set; }

        public TriggerEvaluator Evaluator { get; set; }

        public IJob Job { get; set; }
    }


    public static class Rules
    {
        static Dictionary<string, Rule> dic = new Dictionary<string, Rule>();

        static Rules()
        {
            AssetStringStateChangeTriggerEvaluator evaluator = new AssetStringStateChangeTriggerEvaluator("test1");

            Add(Guid.NewGuid().ToString(), evaluator, new ConsoleJob());
        }

        public static Rule Get(string uid)
        {
            return dic[uid];
        }

        internal static Rule Add(string uid, TriggerEvaluator evaluator, IJob job)
        {
            Rule rule = new Rule();

            rule.Uid = uid;
            rule.Evaluator = evaluator;
            rule.Job = job;

            dic.Add(rule.Uid, rule);

            return rule;
        }

        public static IEnumerable<Rule> GetByTrigger(ITrigger trigger)
        {
            return dic.Values;
        }
    }
}
