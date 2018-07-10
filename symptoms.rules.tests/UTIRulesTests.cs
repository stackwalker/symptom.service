using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace symptoms.rules.tests
{
    [TestClass]
    public class UTIRulesTests
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        
        [TestMethod]
        public void TestRefactor()
        {
            var req = new RuleRequest();
            req.Condition = new Condition();
            req.Condition.CommonName = "uti";
            req.Tests = new List<Test>()
            {
                new Test(){Name = "dysuria" },
                new Test(){Name = "frequency" },
                new Test(){Name = "hematuria" },
                new Test(){Name = "back pain"}
            };
            var cMap = new ConditionDataProvider().GetConditionMap("uti");
            var result = new ConditionEvaluator().Evaluate(req, cMap);
            TestContext.WriteLine("Highest symptom matches" + result.DiagnosticCertainty.ToString());
            Assert.AreNotEqual(1, result.DiagnosticCertainty);

        }
    }
}
