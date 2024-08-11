using MediatR;
using Pschool.Application.Interfaces;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.ParentFolder.Commands.UpdateParent
{
    //TODO: add validation
    public record UpdateParentCommand : IRequest<Result<Guid>>, IMapFrom<Parent>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
    }
}
