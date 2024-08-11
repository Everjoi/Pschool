using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Pschool.Application.DTOs;
using Pschool.Application.Extensions;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.StudentFolder.Queries.GetStudentsWithPagination
{
    public class GetStudentsWithPaginationQueryHandler : IRequestHandler<GetStudentsWithPaginationQuery, PaginatedResult<StudentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentsWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<StudentDto>> Handle(GetStudentsWithPaginationQuery query, CancellationToken cancellationToken)
        {
            if (query.Order == "desc")
            {
                return await _unitOfWork.Repository<Student>().Entities
                   .OrderByDescending(x => x.Name)
                   .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
            }
            else
            {
                return await _unitOfWork.Repository<Student>().Entities
                   .OrderBy(x => x.Name)
                   .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
            }

        }

    }
}
