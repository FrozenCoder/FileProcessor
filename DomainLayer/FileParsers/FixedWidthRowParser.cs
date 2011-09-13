using System;
using FileProcessor.DomainLayer.Entities;

namespace FileProcessor.DomainLayer.FileParsers
{
    public class FixedWidthRowParserAttribute : Attribute { }

    public class FixedWidthRowParser : IFileRowParser
    {
        public string[] ParseRow(string row, DataFileConfiguration configuration)
        {
            if (row.Length == 0) return null;

            string[] fields = new string[configuration.Elements.Count];

            for (int i = 0; i < configuration.Elements.Count; i++)
            {
                try
                {
                    if (Convert.ToInt32(configuration.Elements[i].FixedWidthStartValue) > 0 && Convert.ToInt32(configuration.Elements[i].FixedWidthLength) > 0)
                    {
                        fields[i] = row.Substring(configuration.Elements[i].FixedWidthStartValue - 1, configuration.Elements[i].FixedWidthLength).Trim();
                    }
                }
                catch (Exception)
                {
                    if (row.Length == 0) continue;
                    throw;
                }
            }

            return fields;
        }
    }
}