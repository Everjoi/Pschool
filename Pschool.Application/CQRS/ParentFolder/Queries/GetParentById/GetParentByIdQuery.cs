using MediatR;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.ParentFolder.Queries.GetParentById
{
    public record GetParentByIdQuery : IRequest<Result<Parent>>
    {
        public Guid ParentId { get; set; }
    }
}
