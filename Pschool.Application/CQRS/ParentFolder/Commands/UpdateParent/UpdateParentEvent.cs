using Pschool.Domain.Common;
using Pschool.Domain.Entities;


namespace Pschool.Application.CQRS.ParentFolder.Commands.UpdateParent
{
    public class UpdateParentEvent : BaseEvent
    {
        public Parent Parent { get; set; }
        public UpdateParentEvent(Parent parent)
        {
            Parent = parent;
        }
    }
}
