using MediatR;
using Pschool.Application.DTOs;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.StudentFolder.Queries.GetStudentsByParent
{
    public record GetStudentByParentIdQuery : IRequest<Result<List<StudentDto>>>
    {
        public Guid ParentId { get; set; }
    }
}
