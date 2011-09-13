using System;
using FileProcessor.DomainLayer.Rules.Rules;
using FileProcessor.DomainLayer.Rules.Rules.DataFileConfigurationRules;
using Ninject;

namespace FileProcessor.DomainLayer.Rules.Engines
{
    public class DataFileConfigurationRuleEngineAttribute:Attribute {}

    public class DataFileConfigurationRuleEngine:FileProcessorRuleEngine
    {
        private readonly FileProcessorRule _existingRecordRule;

        [Inject]
        public DataFileConfigurationRuleEngine([DataFileConfigurationExistsRule]FileProcessorRule existingRecordRule)
        {
            _existingRecordRule = existingRecordRule;
        }

        protected override void AddRules()
        {
            if(_entity.EntityId == 0)
            {
                Rules.Add(_existingRecordRule);
            }
        }
    }
}