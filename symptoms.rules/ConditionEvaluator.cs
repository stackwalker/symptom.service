using System;
using System.Collections.Generic;
using System.Text;

namespace symptoms.rules
{
    public class ConditionEvaluator
    {
        public RuleResult Evaluate(RuleRequest req, ConditionMap cMap)
        {
            var certainty = cMap.BasePrevalence;
            var odds = (decimal)(1 / ((1 / certainty) - 1));

            req.Tests.ForEach(t =>
            {
                if(t.PositiveResult || t.NegativeResult)
                {
                    odds = ApplyTest(odds, t, cMap.TestRatios.Find(tr => tr.Name.Equals(t.Name)));
                }
            });

            return new RuleResult() { DiagnosticCertainty = odds / (odds +1) };
        }

        private decimal ApplyTest(decimal odds, Test result, TestRatio ratio)
        {
            if (result.PositiveResult)
            {
                if(ratio.PositiveLR.LowerCI <= 1 && ratio.PositiveLR.UpperCI >= 1)
                {
                    return odds;
                }
                else
                {
                    return odds * ratio.PositiveLR.Value;
                }
            }
            else if(result.NegativeResult)
            {
                if(ratio.NegativeLR.LowerCI <= 1 && ratio.NegativeLR.UpperCI >= 1)
                {
                    return odds;
                }
                else
                {
                    return odds * ratio.NegativeLR.Value;
                }
            }
            else
            {
                return odds;
            }
        }
    }
}
