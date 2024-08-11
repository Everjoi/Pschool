using MediatR;
using Pschool.Application.DTOs;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.StudentFolder.Queries.GetAllStudents
{
    public record GetAllStudentsQuery : IRequest<Result<List<StudentDto>>>;
}
