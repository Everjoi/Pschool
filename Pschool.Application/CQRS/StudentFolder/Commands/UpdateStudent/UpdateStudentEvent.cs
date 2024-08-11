using Pschool.Domain.Common;
using Pschool.Domain.Entities;


namespace Pschool.Application.CQRS.StudentFolder.Commands.UpdateStudent
{
    public class UpdateStudentEvent : BaseEvent
    {
        public Student Student { get; set; }
        public UpdateStudentEvent(Student student)
        {
            Student = student;
        }
    }
}
