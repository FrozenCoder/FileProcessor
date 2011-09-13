using FileProcessor.DomainLayer.Entities;
using FileProcessor.DomainLayer.InterfaceRepositories;
using Framework.TRH.Data;
using Ninject;

namespace FileProcessor.DataLayer.FluentMappings.Repositories
{
    public class DataFileConfigurationReadRepository:BaseReadRepository<DataFileConfiguration>, IDataFileConfigurationReadRepository
    {
        [Inject]
        public DataFileConfigurationReadRepository(ISessionProvider sessionProvider): base(sessionProvider)
        {
        }
    }
}