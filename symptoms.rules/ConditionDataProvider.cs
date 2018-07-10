using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace symptoms.rules
{
    public class ConditionDataProvider
    {
        public ConditionMap GetConditionMap(string condition)
        {
            return JsonConvert.DeserializeObject<ConditionMap>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), $"\\projects\\symptoms.service\\symptoms.rules\\Data\\{condition}-condition.json")));
        }
    }
}
