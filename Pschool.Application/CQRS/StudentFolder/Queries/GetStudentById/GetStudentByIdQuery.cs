using MediatR;
using Pschool.Application.DTOs;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.StudentFolder.Queries.GetStudentById
{
    public record GetStudentByIdQuery : IRequest<Result<StudentDto>>
    {
        public Guid StudentId { get; set; }
    }
}
