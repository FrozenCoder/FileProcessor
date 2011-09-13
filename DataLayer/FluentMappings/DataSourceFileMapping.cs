using FileProcessor.DomainLayer.Entities;
using FluentNHibernate.Mapping;

namespace FileProcessor.DataLayer.FluentMappings
{
    public class DataSourceFileMapping:ClassMap<DataSourceFile>
    {
        public DataSourceFileMapping()
        {
            Table("DataSourceFile");

            Id(x => x.EntityId, "DataSourceFileID").GeneratedBy.Native();

            Map(x => x.FilePath).Not.Nullable();

            Map(x => x.RowCount, "FileRowCount");

            References(x => x.Configuration)
                .Column("DataFileConfigurationID")
                .LazyLoad()
                .Cascade.None()
                .NotFound.Exception();

            Map(x => x.UserAdded).Not.Nullable().Not.Update().Length(25);

            Map(x => x.DateAdded).Not.Nullable().Not.Update().Not.Insert();

            Map(x => x.UserEdited).Length(25).Not.Insert();

            Map(x => x.DateEdited).Not.Insert();

            Map(x => x.Active).Not.Nullable().Not.Insert();
        }
    }
}