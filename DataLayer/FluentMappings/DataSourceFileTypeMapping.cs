using FileProcessor.DomainLayer.Entities;
using FluentNHibernate.Mapping;

namespace FileProcessor.DataLayer.FluentMappings
{
    public class DataSourceFileTypeMapping:ClassMap<DataSourceFileType>
    {
        public DataSourceFileTypeMapping()
        {
            Table("DataSourceFileType");

            Id(x => x.EntityId, "DataFileTypeID").GeneratedBy.Native();

            Map(x => x.Name, "TypeName").Not.Nullable();

            Map(x => x.UserAdded).Not.Nullable().Not.Update().Length(25);

            Map(x => x.DateAdded).Not.Nullable().Not.Update().Not.Insert();

            Map(x => x.UserEdited).Length(25).Not.Insert();

            Map(x => x.DateEdited).Not.Insert();

            Map(x => x.Active).Not.Nullable().Not.Insert();
        } 
    }
}