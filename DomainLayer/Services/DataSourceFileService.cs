using FileProcessor.DomainLayer.Commands;
using FileProcessor.DomainLayer.Entities;
using FileProcessor.DomainLayer.InterfaceRepositories;
using Framework.TRH.Command;
using Framework.TRH.DomainService;
using Ninject;

namespace FileProcessor.DomainLayer.Services
{
    public class DataSourceFileService:DomainServiceBase
    {
        private readonly CustomCommand _createDataSourceFileCommand;

        public IDataSourceFileReadRepository DataSourceFileReadRepository { get; set; }

        [Inject]
        public DataSourceFileService([CreateDataSourceFileCommandAttribute]CustomCommand createDatatSourceFileCommand,
                                     IDataSourceFileReadRepository dataSourceFileReadRepository)
        {
            _createDataSourceFileCommand = createDatatSourceFileCommand;
            DataSourceFileReadRepository = dataSourceFileReadRepository;
        }

        public void AddDataSourceFile(DataSourceFile dataSourceFile)
        {
            _createDataSourceFileCommand.ParameterResolver.Register<DataSourceFile>(dataSourceFile);
            _createDataSourceFileCommand.Execute();
        }
    }
}