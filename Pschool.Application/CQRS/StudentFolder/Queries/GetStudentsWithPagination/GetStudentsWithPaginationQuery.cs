using MediatR;
using Pschool.Application.DTOs;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.StudentFolder.Queries.GetStudentsWithPagination
{
    public class GetStudentsWithPaginationQuery : IRequest<PaginatedResult<StudentDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Order { get; set; } = string.Empty;

        public GetStudentsWithPaginationQuery() { }

        public GetStudentsWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }


    }
}
