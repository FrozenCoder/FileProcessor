using System;
using FileProcessor.DomainLayer.FileParsers;
using Ninject.Modules;

namespace FileProcessor.FrameworkLayer.Modules
{
    internal class FileRowParserModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IFileRowParser>().To<CharacterDelimitedFileRowParser>().WhenTargetHas<CharacterDelimitedFileRowParserAttribute>();

            Bind<IFileRowParser>().To<FixedWidthRowParser>().WhenTargetHas<FixedWidthRowParserAttribute>();
        }
    }
}