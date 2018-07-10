using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using symptoms.rules;
using System.IO;

namespace symptoms.service.Controllers
{
    [Produces("application/json")]
    [Route("api/Symptoms")]
    public class SymptomsController : Controller
    {
        // GET: api/Symptoms
        [HttpGet]
        public ConditionMap Get(string condition)
        {
            return new ConditionDataProvider().GetConditionMap(condition);
        }

        // GET: api/Symptoms/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Symptoms
        [HttpPost]
        public RuleResult Post([FromBody]RuleRequest req)
        {
            var cMap = new ConditionDataProvider().GetConditionMap(req.Condition.CommonName);
            var result = new ConditionEvaluator().Evaluate(req, cMap);
            return result;
        }
        
        // PUT: api/Symptoms/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
