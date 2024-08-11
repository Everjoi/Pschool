using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Pschool.Application.DTOs;
using Pschool.Application.Extensions;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.ParentFolder.Queries.GetParentWithPagination
{
    internal class GetParentWithPaginationQueryHandler : IRequestHandler<GetParentWithPaginationQuery, PaginatedResult<ParentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetParentWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<ParentDto>> Handle(GetParentWithPaginationQuery query, CancellationToken cancellationToken)
        {
            if (query.Order == "desc")
            {
                return await _unitOfWork.Repository<Parent>().Entities
                   .OrderByDescending(x=>x.Name)
                   .ProjectTo<ParentDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
            }      
            else
            {
                return await _unitOfWork.Repository<Parent>().Entities
                   .OrderBy(x => x.Name)
                   .ProjectTo<ParentDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
            }

        }

    }
}
