using Microsoft.EntityFrameworkCore;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Domain.Exceptions;
using Pschool.Infrastructure.Data.Contexts;


namespace Pschool.Infrastructure.Repository
{

    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(PschoolPersonContext dbContext) : base(dbContext) { }
        public async Task<List<Student>> GetStudentsByParentId(Guid parentId)
        {
            var result = await _dbContext.Set<Student>().Where(x=>x.ParentId == parentId).ToListAsync();
            if (result == null)
                throw new NotFoundException(new Student().GetType(), parentId);

            return result;
        }
    }
}
