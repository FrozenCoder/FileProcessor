using System.Collections.Generic;
using Ninject;

namespace FileProcessor.DomainLayer.Entities
{
    public class DataSourceFile:BaseEntity
    {
        private DataFileConfiguration _configuration;

        protected DataSourceFile() { }

        [Inject]
        public DataSourceFile(DataFileConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual string FilePath { get; set; }

        public virtual int? RowCount { get; set; }

        public virtual DataFileConfiguration Configuration
        {
            get { return _configuration; }
            set { _configuration = value; }
        }
    }
}