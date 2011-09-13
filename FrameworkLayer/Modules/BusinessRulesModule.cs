using FileProcessor.DomainLayer.Rules.Engines;
using FileProcessor.DomainLayer.Rules.Rules;
using FileProcessor.DomainLayer.Rules.Rules.DataFileConfigurationRules;
using FileProcessor.DomainLayer.Rules.Rules.DataSourceFileTypeRules;
using Ninject.Modules;

namespace FileProcessor.FrameworkLayer.Modules
{
    internal class BusinessRulesModule:NinjectModule
    {
        public override void Load()
        {
            BindRuleEngines();

            BindRules();
        }

        private void BindRuleEngines()
        {
            Bind<FileProcessorRuleEngine>().To<DataFileConfigurationRuleEngine>().WhenTargetHas<DataFileConfigurationRuleEngineAttribute>();

            Bind<FileProcessorRuleEngine>().To<DataSourceFileTypeRuleEngine>().WhenTargetHas<DataSourceFileTypeRuleEngineAttribute>();
        }

        private void BindRules()
        {
            Bind<FileProcessorRule>().To<DataFileConfigurationExistsRule>().WhenTargetHas<DataFileConfigurationExistsRuleAttribute>();

            Bind<FileProcessorRule>().To<DataSourceFileTypeExistsRule>().WhenTargetHas<DataSourceFileTypeExistsRuleAttribute>();
        }
    }
}