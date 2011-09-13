using System;
using FileProcessor.DomainLayer.Entities;
using Framework.TRH.Command;
using Framework.TRH.Data;
using Framework.TRH.ErrorHandling;
using Framework.TRH.ErrorHandling.CustomErrors;
using NHibernate;

namespace FileProcessor.DomainLayer.Commands
{
    public class CreateDataSourceFileCommandAttribute:Attribute{}

    public class CreateDataSourceFileCommand:CustomCommand
    {
        private DataSourceFile _sourceFile;

        private readonly IWriteRepository<DataSourceFile> _repository;

        public CreateDataSourceFileCommand(IWriteRepository<DataSourceFile> repository, ErrorHandler errorHandler) : base(errorHandler)
        {
            _repository = repository;
        }

        protected override bool CanExecute()
        {
            SetParameters();

            if(_sourceFile == null)
            {
                CommandErrors.Add("DataSourceFile object is null");
                return false;
            }

            return true;
        }

        public override void Execute()
        {
            if (!CanExecute()) return;

            try
            {
                _repository.Persist(_sourceFile);
            }
            catch (BusinessRuleError error)
            {
                CommandErrors.Add(error.Message);
            }
            catch (PropertyValueException valueException)
            {
                _sourceFile.EntityId = 0;
                CommandErrors.Add("Required Field Missing:" + valueException.PropertyName);
            }
            catch (Exception error)
            {
                _errorHandler.Log(error, true);
                CommandErrors.Add(error.Message);
            }
        }

        protected override void SetParameters()
        {
            _sourceFile = ParameterResolver.Resolve<DataSourceFile>();
        }
    }
}