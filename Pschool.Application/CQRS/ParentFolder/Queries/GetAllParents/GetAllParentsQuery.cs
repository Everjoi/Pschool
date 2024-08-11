using MediatR;
using Pschool.Application.DTOs;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.ParentFolder.Queries.GetAllParents
{
    public record GetAllParentsQuery : IRequest<Result<List<ParentDto>>>;
}
