using Pschool.Domain.Interfaces;


namespace Pschool.Domain.Common
{ 
    public abstract class BasePersonEntity : BaseEntity, IPersonEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
    }
}
