using System.Collections.Generic;
using Ninject;

namespace FileProcessor.DomainLayer.Entities
{
    public class DataFileConfiguration:BaseEntity
    {
        private IList<DataFileElement> _elements;

        [Inject]
        public DataFileConfiguration()
        {
            _elements = new List<DataFileElement>();
        }

        public virtual string Name { get; set; }

        public virtual DataSourceFileType Type { get; set; }

        public virtual string CharDelimiter { get; set; }

        public virtual IList<DataFileElement> Elements
        {
            get { return _elements; }
            set { _elements = value; }
        }
    }
}