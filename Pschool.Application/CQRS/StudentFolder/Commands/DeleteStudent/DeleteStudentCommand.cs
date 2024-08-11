using MediatR;
using Pschool.Application.Interfaces;
using Pschool.Domain.Entities;
using Pschool.Shared.Interfaces;


namespace Pschool.Application.CQRS.StudentFolder.Commands.DeleteStudent
{
    public record DeleteStudentCommand  : IRequest<IResult<Guid>> ,IMapFrom<Student>
    {
        public Guid StudentId { get; set; }
    }
}
