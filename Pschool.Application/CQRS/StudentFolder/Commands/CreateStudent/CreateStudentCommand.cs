using MediatR;
using Pschool.Application.Interfaces;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.StudentFolder.Commands.CreateStudent
{
    //TODO: add validation
    public record class CreateStudentCommand : IRequest<Result<Guid>>, IMapFrom<Student>
    {
        public required string Name { get; set; }
        public required string Surname { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public required DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public Guid ParentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Grade { get; set; } = string.Empty;

    }
}
