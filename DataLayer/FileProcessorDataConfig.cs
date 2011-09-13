using System.Configuration;
using FileProcessor.DataLayer.FluentMappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace FileProcessor.DataLayer
{
    public class FileProcessorDataConfig
    {
        public static ISessionFactory BuildSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString(c => c.Is(ConfigurationManager.ConnectionStrings["FILEPROCESSOR_CONNECTION"].ToString())))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<DataFileConfigurationMapping>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<DataFileElementMapping>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<DataSourceFileMapping>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<DataSourceFileTypeMapping>())
                .BuildSessionFactory();
        }
    }
}