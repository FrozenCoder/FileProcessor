using System;

namespace FileProcessor.DomainLayer.Entities
{
    public class BaseEntity
    {
        private string _userAddded;

        public BaseEntity()
        {
            _userAddded = Environment.UserName;
        }

        public virtual int EntityId { get; set; }

        public virtual string UserAdded { get { return _userAddded; } set { _userAddded = value; } }

        public virtual DateTime DateAdded { get; set; }

        public virtual string UserEdited { get; set; }

        public virtual DateTime? DateEdited { get; set; }

        public virtual bool Active { get; set; }
    }
}
