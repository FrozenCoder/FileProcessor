using FileProcessor.DomainLayer.Entities;
using FileProcessor.DomainLayer.InterfaceRepositories;
using Framework.TRH.Data;
using Ninject;

namespace FileProcessor.DataLayer.FluentMappings.Repositories
{
    public class DataSourceFileTypeReadRepository:BaseReadRepository<DataSourceFileType>, IDataSourceFileTypeReadRepository
    {
        [Inject]
        public DataSourceFileTypeReadRepository(ISessionProvider sessionProvider):base(sessionProvider)
        {
        }
    }
}