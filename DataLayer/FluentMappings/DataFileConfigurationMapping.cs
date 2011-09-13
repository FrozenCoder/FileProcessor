using FileProcessor.DomainLayer.Entities;
using FluentNHibernate.Mapping;

namespace FileProcessor.DataLayer.FluentMappings
{
    public class DataFileConfigurationMapping:ClassMap<DataFileConfiguration>
    {
        public DataFileConfigurationMapping()
        {
            Table("DataFileConfiguration");

            Id(x => x.EntityId, "DataFileConfigurationID").GeneratedBy.Native();

            Map(x => x.Name, "ConfigurationName").Not.Nullable();

            References(x => x.Type)
                .Column("DataFileTypeID")
                .LazyLoad()
                .Cascade.None()
                .NotFound.Exception();

            Map(x => x.CharDelimiter);

            HasMany(x => x.Elements)
            .KeyColumn("DataFileConfigurationID")
            .Cascade.SaveUpdate()
            .LazyLoad();

            Map(x => x.UserAdded).Not.Nullable().Not.Update().Length(25);

            Map(x => x.DateAdded).Not.Nullable().Not.Update().Not.Insert();

            Map(x => x.UserEdited).Length(25).Not.Insert();

            Map(x => x.DateEdited).Not.Insert();

            Map(x => x.Active).Not.Nullable().Not.Insert();
        }
    }
}