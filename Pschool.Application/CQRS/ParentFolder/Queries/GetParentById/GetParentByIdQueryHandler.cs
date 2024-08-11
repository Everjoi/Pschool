using AutoMapper;
using MediatR;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.ParentFolder.Queries.GetParentById
{
    internal class GetParentByIdQueryHandler : IRequestHandler<GetParentByIdQuery, Result<Parent>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetParentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Parent>> Handle(GetParentByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Parent>().GetByIdAsync(query.ParentId);
            var parent = _mapper.Map<Parent>(entity);
            return await Result<Parent>.SuccessAsync(parent);
        }

    }
}
