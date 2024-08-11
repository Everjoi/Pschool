using Pschool.Application.Interfaces;
using Pschool.Domain.Entities;


namespace Pschool.Application.DTOs
{
    public class ParentDto : IMapFrom<Parent>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int StudentsCount { get; set; } 
    }
}
