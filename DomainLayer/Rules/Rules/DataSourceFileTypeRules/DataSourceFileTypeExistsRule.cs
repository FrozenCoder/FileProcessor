using System;
using FileProcessor.DomainLayer.Entities;
using FileProcessor.DomainLayer.InterfaceRepositories;
using Framework.TRH.ErrorHandling.CustomErrors;
using Ninject;

namespace FileProcessor.DomainLayer.Rules.Rules.DataSourceFileTypeRules
{
    public class DataSourceFileTypeExistsRuleAttribute : Attribute { }

    public class DataSourceFileTypeExistsRule : FileProcessorRule
    {
        private readonly IDataSourceFileTypeReadRepository _repository;
        private DataSourceFileType _fileType;

        [Inject]
        public DataSourceFileTypeExistsRule(IDataSourceFileTypeReadRepository repository)
        {
            _repository = repository;
        }

        public override void Run()
        {
            SetParameters();

            try
            {
                if (_repository.GetBySingleColumnMatch("Name", _fileType.Name ,true).Count > 0)
                {
                    Errors.Add("A DataSourceFileType named" + _fileType.Name + " already exists!");
                }
            }
            catch (DataNotFoundError)
            {
                return;
            }
            catch (DataCorruptionError error)
            {
                Errors.Add(error.Message);
            }
        }

        protected override void SetParameters()
        {
            Errors.Clear();

            _fileType = (DataSourceFileType)ParameterResolver.Resolve<BaseEntity>();
        }
    }
}