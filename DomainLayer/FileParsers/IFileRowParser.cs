using FileProcessor.DomainLayer.Entities;

namespace FileProcessor.DomainLayer.FileParsers
{
    public interface IFileRowParser
    {
        string[] ParseRow(string row, DataFileConfiguration configuration);
    }
}