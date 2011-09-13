using FileProcessor.DomainLayer.Entities;
using FluentNHibernate.Mapping;

namespace FileProcessor.DataLayer.FluentMappings
{
    public class DataFileElementMapping:ClassMap<DataFileElement>
    {
        public DataFileElementMapping()
        {
            Table("DataFileElement");

            Id(x => x.EntityId, "DataElementID").GeneratedBy.Native();

            Map(x => x.ElementName);

            Map(x => x.ElementIndex);

            Map(x => x.FixedWidthStartValue);

            Map(x => x.FixedWidthEndValue);

            Map(x => x.FixedWidthLength);

            Map(x => x.CharDelimitedColumnIndex);

            References(x => x.Configuration)
                .Columns("DataFileConfigurationID")
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