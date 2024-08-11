using Pschool.Domain.Common;
using Pschool.Domain.Entities;

namespace Pschool.Application.CQRS.ParentFolder.Commands.CreateParent
{
    public  class CreateParentEvent : BaseEvent
    {
        public Parent Parent { get; }

        public CreateParentEvent(Parent parent)
        {
            Parent = parent;
        }
    }
}
