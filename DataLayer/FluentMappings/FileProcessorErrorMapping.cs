using FileProcessor.DomainLayer.Entities;
using FluentNHibernate.Mapping;

namespace FileProcessor.DataLayer.FluentMappings
{
    public class FileProcessorErrorMapping:ClassMap<FileProcessorError>
    {
        public FileProcessorErrorMapping()
        {
            Table("Error");

            Id(x => x.EntityId, "ErrorID").GeneratedBy.Native();

            Map(x => x.ApplicationName).Not.Nullable();

            Map(x => x.Exception).Not.Nullable();

            Map(x => x.MachineName).Not.Nullable();

            Map(x => x.SystemTime).Not.Insert();

            Map(x => x.StackTrace).Not.Nullable();

            Map(x => x.UserAdded).Not.Nullable().Not.Update().Length(25);

            Map(x => x.DateAdded).Not.Nullable().Not.Update().Not.Insert();

            Map(x => x.UserEdited).Length(25).Not.Insert();

            Map(x => x.DateEdited).Not.Insert();

            Map(x => x.Active).Not.Nullable().Not.Insert();
        }
    }
}