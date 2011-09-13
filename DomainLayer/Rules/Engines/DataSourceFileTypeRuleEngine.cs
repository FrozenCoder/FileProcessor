using System;
using FileProcessor.DomainLayer.Rules.Rules;
using FileProcessor.DomainLayer.Rules.Rules.DataSourceFileTypeRules;
using Ninject;

namespace FileProcessor.DomainLayer.Rules.Engines
{
    public class DataSourceFileTypeRuleEngineAttribute:Attribute {}

    public class DataSourceFileTypeRuleEngine:FileProcessorRuleEngine
    {
        private readonly FileProcessorRule _existingRecordRule;

        [Inject]
        public DataSourceFileTypeRuleEngine([DataSourceFileTypeExistsRule]FileProcessorRule existingRecordRule)
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