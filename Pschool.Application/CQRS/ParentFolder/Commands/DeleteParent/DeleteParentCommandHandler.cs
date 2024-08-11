using AutoMapper;
using MediatR;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Interfaces;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.ParentFolder.Commands.DeleteParent
{
    public class DeleteParentCommandHandler : IRequestHandler<DeleteParentCommand, IResult<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteParentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<Guid>> Handle(DeleteParentCommand request, CancellationToken cancellationToken)
        {
            var parent = await _unitOfWork.Repository<Parent>().GetByIdAsync(request.ParentId);
            await _unitOfWork.Repository<Parent>().DeleteAsync(parent);
            parent.AddDomainEvent(new DeleteParentEvent(parent));
            try
            {
                await _unitOfWork.Save(cancellationToken);
            }
            catch (Exception)
            {
                return await Result<Guid>.FailureAsync(parent.Id, "Foreign key contraint."); 
            }
            
            return await Result<Guid>.SuccessAsync(parent.Id, "Parent Deleted.");
        }
    }
}
