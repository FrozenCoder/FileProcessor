using FileProcessor.DomainLayer.Commands;
using FileProcessor.DomainLayer.Entities;
using FileProcessor.DomainLayer.InterfaceRepositories;
using Framework.TRH.Command;
using Framework.TRH.DomainService;
using Ninject;

namespace FileProcessor.DomainLayer.Services
{
    public class DataFileConfigurationService: DomainServiceBase
    {
        private readonly CustomCommand _createDFCCommand;

        public IDataFileConfigurationReadRepository DataFileConfigurationReadRepository { get; set; }

        [Inject]
        public DataFileConfigurationService([CreateDataFileConfigurationCommandAttribute]CustomCommand createDFCCommand,
                                            IDataFileConfigurationReadRepository repository)
        {
            _createDFCCommand = createDFCCommand;
            DataFileConfigurationReadRepository = repository;
        }

        public void AddDataFileConfiguration(DataFileConfiguration dataFileConfiguration)
        {
            _createDFCCommand.ParameterResolver.Register<DataFileConfiguration>(dataFileConfiguration);
            _createDFCCommand.Execute();
        }  
    }
}