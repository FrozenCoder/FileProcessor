using FileProcessor.DomainLayer.InterfaceRepositories;
using Framework.TRH.DomainService;
using Ninject;

namespace FileProcessor.DomainLayer.Services
{
    public class DataSourceFileTypeService:DomainServiceBase
    {
        public IDataSourceFileTypeReadRepository DataSourceFileTypeReadRepository { get; set; }

        [Inject]
        public DataSourceFileTypeService(IDataSourceFileTypeReadRepository repository)
        {
            DataSourceFileTypeReadRepository = repository;
        }
    }
}