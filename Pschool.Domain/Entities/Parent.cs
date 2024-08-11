using Pschool.Domain.Common;


namespace Pschool.Domain.Entities
{
    public class Parent : BasePersonEntity
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Student> Students { get; set; } = new();
    }
}
