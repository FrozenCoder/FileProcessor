using System;
using FileProcessor.DomainLayer.Commands;
using Framework.TRH.Command;
using Ninject.Modules;

namespace FileProcessor.FrameworkLayer.Modules
{
    internal class CommandModule:NinjectModule
    {
        public override void Load()
        {
            Bind<CustomCommand>().To<CreateDataFileConfigurationCommand>().WhenTargetHas<CreateDataFileConfigurationCommandAttribute>();

            Bind<CustomCommand>().To<CreateDataSourceFileCommand>().WhenTargetHas<CreateDataSourceFileCommandAttribute>();
        }
    }
}
