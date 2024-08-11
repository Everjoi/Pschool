using AutoMapper;
using MediatR;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;

namespace Pschool.Application.CQRS.ParentFolder.Commands.CreateParent
{
    public class CreateParentCommandHandler : IRequestHandler<CreateParentCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const int DaysPerYear = 365;
        
        public CreateParentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateParentCommand request, CancellationToken cancellationToken)
        {
            var parent = new Parent
            {
                Name = request.Name,
                Age = (DateTime.Now - request.DateOfBirth).Days / DaysPerYear,
                Surname = request.Surname,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Occupation =request.Occupation,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                //CreatedBy =  TODO: create service and get id from current user session
                //ModifiedBy = TODO: create service and get id from current user session
            };

            await _unitOfWork.Repository<Parent>().AddAsync(parent);
            parent.AddDomainEvent(new CreateParentEvent(parent));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(parent.Id, "Parent Created.");
        }
    }
}
