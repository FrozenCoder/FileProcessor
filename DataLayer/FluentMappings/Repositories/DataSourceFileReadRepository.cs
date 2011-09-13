using FileProcessor.DomainLayer.Entities;
using FileProcessor.DomainLayer.InterfaceRepositories;
using Framework.TRH.Data;
using Ninject;

namespace FileProcessor.DataLayer.FluentMappings.Repositories
{
    public class DataSourceFileReadRepository:BaseReadRepository<DataSourceFile>, IDataSourceFileReadRepository
    {
        [Inject]
        public DataSourceFileReadRepository(ISessionProvider sessionProvider): base(sessionProvider)
        {
        }
    }
}