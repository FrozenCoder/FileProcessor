using System;
using System.Collections.Generic;
using System.Linq;
using FileProcessor.DomainLayer.Entities;

namespace FileProcessor.DomainLayer.FileParsers
{
    public class CharacterDelimitedFileRowParserAttribute : Attribute { }

    public class CharacterDelimitedFileRowParser : IFileRowParser
    {
        public string[] ParseRow(string row, DataFileConfiguration configuration)
        {
            if (row.Length == 0)
            {
                return null;
            }

            string[] seperator = { configuration.CharDelimiter };

            string[] fileFields = row.Trim().Split(seperator, StringSplitOptions.None);

            string[] parsedFields = new string[configuration.Elements.Count];

            IList<DataFileElement> orderedElements = (configuration.Elements.OrderBy(element => element.ElementIndex)).ToList();

            for (int i = 0; i < orderedElements.Count - 1; i++)
            {
                parsedFields[i] = fileFields[orderedElements[i].CharDelimitedColumnIndex].Trim();
            }

            return parsedFields;
        }
    }
}
