using MediatR;
using Pschool.Application.Interfaces;
using Pschool.Domain.Entities;
using Pschool.Shared.Interfaces;


namespace Pschool.Application.CQRS.ParentFolder.Commands.DeleteParent
{
    public record DeleteParentCommand : IRequest<IResult<Guid>> ,IMapFrom<Parent>
    {
        public Guid ParentId { get; set; }
    }
}
