using Pschool.Domain.Common;


namespace Pschool.Domain.Entities
{
    public class Student : BasePersonEntity
    {
        public Guid ParentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Grade { get; set; } = string.Empty;
    }
}
