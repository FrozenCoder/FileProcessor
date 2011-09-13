using FileProcessor.DomainLayer.Entities;
using FileProcessor.DomainLayer.FileParsers;
using FileProcessor.DomainLayer.InterfaceRepositories;
using Framework.TRH.DomainService;
using Ninject;

namespace FileProcessor.DomainLayer.Services
{
    public class ParseService:DomainServiceBase
    {
        private readonly IFileRowParser _fwFileRowParser;
        private readonly IFileRowParser _cdFileRowParser;
        private readonly IDataFileConfigurationReadRepository _repository;
        
        [Inject]
        public ParseService([FixedWidthRowParserAttribute]IFileRowParser fwFileRowParser, 
                            [CharacterDelimitedFileRowParserAttribute]IFileRowParser cdFileRowParser,
                            IDataFileConfigurationReadRepository repository)
        {
            _fwFileRowParser = fwFileRowParser;
            _cdFileRowParser = cdFileRowParser;
            _repository = repository;
        }

        public string[] ParseWithFixedWidthConfig(string fileLine, DataFileConfiguration fileConfig)
        {
            IFileRowParser parser = _fwFileRowParser;

            return parser.ParseRow(fileLine, fileConfig);
        }

        public string[] ParseWithFixedWidthConfig(string fileLine, string fileConfigName)
        {
            IFileRowParser parser = _fwFileRowParser;

            DataFileConfiguration fileConfig = _repository.GetBySingleColumnMatch("Name", fileConfigName, true)[0];

            return parser.ParseRow(fileLine, fileConfig);
        }

        public string[] ParseWithCharacterDelimitedConfig(string fileLine, DataFileConfiguration fileConfig)
        {
            IFileRowParser parser = _cdFileRowParser;

            return parser.ParseRow(fileLine, fileConfig);
        }

        public string[] ParseWithCharacterDelimitedConfig(string fileLine, string fileConfigName)
        {
            IFileRowParser parser = _cdFileRowParser;

            DataFileConfiguration fileConfig = _repository.GetBySingleColumnMatch("Name", fileConfigName, true)[0];

            return parser.ParseRow(fileLine, fileConfig);
        }
    }
}