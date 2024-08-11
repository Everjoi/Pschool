using MediatR;
using Pschool.Application.DTOs;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.ParentFolder.Queries.GetParentWithPagination
{
    public record GetParentWithPaginationQuery : IRequest<PaginatedResult<ParentDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Order { get; set; } = string.Empty;

        public GetParentWithPaginationQuery() { }

        public GetParentWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }


    }
}
