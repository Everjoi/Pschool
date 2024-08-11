using Pschool.Domain.Entities;


namespace Pschool.Application.Interfaces.Repository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<List<Student>> GetStudentsByParentId(Guid parentId);
    }
}
