using Ninject;

namespace FileProcessor.DomainLayer.Entities
{
    public class DataFileElement:BaseEntity
    {
        private DataFileConfiguration _configuration;

        protected DataFileElement() { }

        [Inject]
        public DataFileElement(DataFileConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual string ElementName { get; set; }

        public virtual int ElementIndex { get; set; }

        public virtual int FixedWidthStartValue { get; set; }

        public virtual int FixedWidthEndValue { get; set; }

        public virtual int FixedWidthLength { get; set; }

        public virtual int CharDelimitedColumnIndex { get; set; }

        public virtual DataFileConfiguration Configuration
        {
            get { return _configuration; }
            set { _configuration = value; }
        }
    }
}