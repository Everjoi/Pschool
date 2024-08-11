using Pschool.Application.Interfaces;
using MediatR;
using Pschool.Shared.Results;
using Pschool.Domain.Entities;

namespace Pschool.Application.CQRS.ParentFolder.Commands.CreateParent
{
    //TODO: add validation
    public record CreateParentCommand : IRequest<Result<Guid>>, IMapFrom<Parent>
    {
        public required string Name { get; set; } = string.Empty;
        public required string Surname { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public required DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
    }
}
