namespace bank_mock.Core.Models.Interfaces
{
    public abstract class BaseEntity
    {
        private long _id;
        public long Id 
        { 
            get => _id;
            set => _id = value;
        }
    }
}