using System;
using FileProcessor.DomainLayer.Entities;
using FileProcessor.DomainLayer.InterfaceRepositories;
using Framework.TRH.ErrorHandling.CustomErrors;
using Ninject;

namespace FileProcessor.DomainLayer.Rules.Rules.DataFileConfigurationRules
{
    public class DataFileConfigurationExistsRuleAttribute:Attribute {}

    public class DataFileConfigurationExistsRule:FileProcessorRule
    {
        private readonly IDataFileConfigurationReadRepository _repository;
        private DataFileConfiguration _config;

        [Inject]
        public DataFileConfigurationExistsRule(IDataFileConfigurationReadRepository repository)
        {
            _repository = repository;    
        }

        public override void Run()
        {
            SetParameters();

            try
            {
                if(_repository.GetBySingleColumnMatch("Name", _config.Name, true).Count > 0)
                {
                    Errors.Add("A DataFileConfiguration named" + _config.Name + " already exists!");
                }
            }
            catch (DataNotFoundError)
            {
                return;    
            }
            catch(DataCorruptionError error)
            {
                Errors.Add(error.Message);
            }
        }

        protected override void SetParameters()
        {
            Errors.Clear();

            _config = (DataFileConfiguration) ParameterResolver.Resolve<BaseEntity>();
        }
    }
}