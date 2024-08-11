using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pschool.Application.DTOs;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.ParentFolder.Queries.GetAllParents
{
    public class GetAllParentsQueryHandler : IRequestHandler<GetAllParentsQuery, Result<List<ParentDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllParentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<ParentDto>>> Handle(GetAllParentsQuery query, CancellationToken cancellationToken)
        {
            var parents = await _unitOfWork.Repository<Parent>().Entities
                   .ProjectTo<ParentDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<ParentDto>>.SuccessAsync(parents);
        }

    }
}
