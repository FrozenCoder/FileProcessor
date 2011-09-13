using System;
using FileProcessor.DomainLayer.Entities;
using FileProcessor.DomainLayer.Rules.Engines;
using Framework.TRH.Command;
using Framework.TRH.Data;
using Framework.TRH.ErrorHandling;
using Framework.TRH.ErrorHandling.CustomErrors;
using NHibernate;
using Ninject;

namespace FileProcessor.DomainLayer.Commands
{
    public class CreateDataFileConfigurationCommandAttribute:Attribute{}

    public class CreateDataFileConfigurationCommand:CustomCommand
    {
        private DataFileConfiguration _fileConfig;

        private readonly IWriteRepository<DataFileConfiguration> _repository;
        private readonly FileProcessorRuleEngine _ruleEngine;

        [Inject]
        public CreateDataFileConfigurationCommand(IWriteRepository<DataFileConfiguration> repository, [DataFileConfigurationRuleEngine]FileProcessorRuleEngine ruleEngine, ErrorHandler errorHandler) : base(errorHandler)
        {
            _repository = repository;
            _ruleEngine = ruleEngine;
        }

        protected override bool CanExecute()
        {
            SetParameters();

            if(_fileConfig == null)
            {
                CommandErrors.Add("DataFileConfiguration object is null");
                return false;
            }

            _ruleEngine.RunRules();
            
            if(_ruleEngine.Errors.Count == 0)
            {
                return true;
            }

            CommandErrors = _ruleEngine.Errors;

            return false;
        }

        public override void Execute()
        {
            if (!CanExecute()) return;

            try
            {
                _repository.Persist(_fileConfig);
            }
            catch (BusinessRuleError error)
            {
                CommandErrors.Add(error.Message);
            }
            catch (PropertyValueException valueException)
            {
                _fileConfig.EntityId = 0;
                CommandErrors.Add("Required Field Missing:" + valueException.PropertyName);
            }
            catch(Exception error)
            {
                _errorHandler.Log(error, true);
                CommandErrors.Add(error.Message);
            }
        }

        protected override void SetParameters()
        {
            _fileConfig = ParameterResolver.Resolve<DataFileConfiguration>();
            _ruleEngine.ParameterResolver.Register<BaseEntity>(_fileConfig);
        }
    }
}