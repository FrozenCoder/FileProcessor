using FileProcessor.DomainLayer.Entities;
using Framework.TRH.Data;
using Ninject.Modules;

namespace FileProcessor.FrameworkLayer.Modules
{
    internal class WriteRepositoryModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IWriteRepository<DataFileConfiguration>>().To<WriteRepository<DataFileConfiguration>>();

            Bind<IWriteRepository<DataSourceFile>>().To<WriteRepository<DataSourceFile>>();

            Bind<IWriteRepository<DataSourceFileType>>().To<WriteRepository<DataSourceFileType>>();

            Bind<IWriteRepository<FileProcessorError>>().To<WriteRepository<FileProcessorError>>();
        }
    }
}