using MediatR;
using Pschool.Application.Interfaces;
using Pschool.Domain.Entities;
using Pschool.Shared.Interfaces;
 

namespace Pschool.Application.CQRS.StudentFolder.Commands.UpdateStudent
{
    //TODO: add validation
    public class UpdateStudentCommand : IRequest<IResult<Guid>>, IMapFrom<Student>
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public required DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public string Grade { get; set; } = string.Empty;
    }
}
