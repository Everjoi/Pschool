using AutoMapper;
using MediatR;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.ParentFolder.Commands.UpdateParent
{
    public class UpdateParentCommandHandler : IRequestHandler<UpdateParentCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const int DaysPerYear = 365;

        public UpdateParentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(UpdateParentCommand request, CancellationToken cancellationToken)
        {
            var parent = await _unitOfWork.Repository<Parent>().GetByIdAsync(request.Id);
            parent.Surname = request.Surname;
            parent.PhoneNumber = request.PhoneNumber;
            parent.Address = request.Address;
            parent.Age = (DateTime.Now - request.DateOfBirth).Days / DaysPerYear;
            parent.DateOfBirth = request.DateOfBirth;
            parent.LastName = request.LastName;
            parent.ModifiedOn = DateTime.Now;
            parent.Email = request.Email;
            parent.Gender = request.Gender;
            parent.Name = request.Name;
            parent.Occupation = request.Occupation;


            await _unitOfWork.Repository<Parent>().UpdateAsync(parent);
            parent.AddDomainEvent(new UpdateParentEvent(parent));

            await _unitOfWork.Save(cancellationToken);

            return await Result<Guid>.SuccessAsync(parent.Id, "Parent Updated.");
        }
    }
}
