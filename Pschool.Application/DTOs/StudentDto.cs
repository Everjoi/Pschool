using Pschool.Application.Interfaces;
using Pschool.Domain.Entities;


namespace Pschool.Application.DTOs
{
    public  class StudentDto : IMapFrom<Student>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Parent { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
    }
}
