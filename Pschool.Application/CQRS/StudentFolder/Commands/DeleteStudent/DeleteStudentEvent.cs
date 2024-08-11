using Pschool.Domain.Common;
using Pschool.Domain.Entities;


namespace Pschool.Application.CQRS.StudentFolder.Commands.DeleteStudent
{
    public class DeleteStudentEvent : BaseEvent
    {
        public Student Student { get; set; }
        public DeleteStudentEvent(Student student)
        {
            Student = student;
        }
    }
}
