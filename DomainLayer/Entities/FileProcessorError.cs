using System;
using Framework.TRH.ErrorHandling;

namespace FileProcessor.DomainLayer.Entities
{
    public class FileProcessorError:BaseEntity,IApplicationError
    {
        public virtual string ApplicationName { get; set; }

        public virtual string Exception { get; set; }

        public virtual string MachineName { get; set; }

        public virtual DateTime SystemTime { get; set; }

        public virtual string StackTrace { get; set; }
    }
}
