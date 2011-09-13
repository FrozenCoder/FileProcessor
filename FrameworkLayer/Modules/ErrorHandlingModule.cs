using System;
using FileProcessor.DomainLayer.Services;
using Framework.TRH.ErrorHandling;
using Ninject.Modules;

namespace FileProcessor.FrameworkLayer.Modules
{
    internal class ErrorHandlingModule:NinjectModule
    {
        public override void Load()
        {
           Bind<ErrorHandler>().To<DomainErrorService>();
        }
    }
}