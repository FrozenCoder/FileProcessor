namespace FileProcessor.DomainLayer.Entities
{
    public class DataSourceFileType:BaseEntity
    {
        protected DataSourceFileType() { }

        public virtual string Name { get; set; }
    }
}