using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetQTest
{
    /// <summary>
    /// Implement this interface for the class which expects some conditional execution upon instantiation/ raise
    /// </summary>
    public interface ITrigger
    {
        Dictionary<string, object> Map { get; set; }
        
        string Value { get; }

        IEnumerable<Rule> GetRules();
    }

    public abstract class TriggerEvaluator
    {
        public abstract bool Evaluate(ITrigger trigger);
    }

    public class AssetStringStateChangeTriggerEvaluator : TriggerEvaluator
    {
        string expectedValue;
        string op;

        public AssetStringStateChangeTriggerEvaluator(string expectedValue)
        {
            this.expectedValue = expectedValue;
        }

        public override bool Evaluate(ITrigger trigger)
        {
            return trigger.Value == expectedValue;
        }

    }
}
