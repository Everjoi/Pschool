using Pschool.Domain.Common;
using Pschool.Domain.Entities;


namespace Pschool.Application.CQRS.ParentFolder.Commands.DeleteParent
{
    public class DeleteParentEvent : BaseEvent
    {
        public Parent Parent { get; set; }
        public DeleteParentEvent(Parent parent)
        {
            Parent = parent;
        }
    }
}
