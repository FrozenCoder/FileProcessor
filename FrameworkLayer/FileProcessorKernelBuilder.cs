using FileProcessor.DataLayer;
using FileProcessor.FrameworkLayer.Modules;
using Framework.TRH.Data;
using Ninject;

namespace FileProcessor.FrameworkLayer
{
    public class FileProcessorKernelBuilder
    {
        private static IKernel _kernel;

        public static IKernel Kernel
        {
            get
            {
                if (_kernel != null)
                {
                    return _kernel;
                }

                BuildKernel();

                return _kernel;
            }
        }

        public static IKernel BuildKernel()
        {
            _kernel = new StandardKernel();

            _kernel.Bind<ISessionProvider>().To<SessionProvider>().InSingletonScope().WithConstructorArgument("sessionFactory", FileProcessorDataConfig.BuildSessionFactory());

            _kernel.Load(
                            new WriteRepositoryModule(),
                            new ReadRepositoryModule(),
                            new ErrorHandlingModule(),
                            new CommandModule(),
                            new BusinessRulesModule(),
                            new FileRowParserModule()
                        );

            return _kernel;
        }
    }
}