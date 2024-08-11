using MediatR;
using Pschool.Application.DTOs;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.ParentFolder.Queries.GetParentByStudentId
{
    public record GetParentByStudentIdQuery : IRequest<Result<ParentDto>>
    {
        public Guid StudentId { get; set; }
    }
}
