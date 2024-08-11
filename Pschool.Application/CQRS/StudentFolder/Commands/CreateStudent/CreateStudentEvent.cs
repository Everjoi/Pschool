using Pschool.Domain.Common;
using Pschool.Domain.Entities;


namespace Pschool.Application.CQRS.StudentFolder.Commands.CreateStudent
{
    public class CreateStudentEvent : BaseEvent
    {
        public Student Student { get; set; }
        public CreateStudentEvent(Student student)
        {
            Student = student;
        }
    }
}
