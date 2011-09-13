using System;
using FileProcessor.DataLayer.FluentMappings.Repositories;
using FileProcessor.DomainLayer.InterfaceRepositories;
using Ninject.Modules;

namespace FileProcessor.FrameworkLayer.Modules
{
    internal class ReadRepositoryModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IDataFileConfigurationReadRepository>().To<DataFileConfigurationReadRepository>();

            Bind<IDataSourceFileReadRepository>().To<DataSourceFileReadRepository>();

            Bind<IDataSourceFileTypeReadRepository>().To<DataSourceFileTypeReadRepository>();
        }
    }
}