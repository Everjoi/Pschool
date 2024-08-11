using Pschool.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;


namespace Pschool.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        private readonly List<BaseEvent> _domainEvents = new();

        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }


        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();

    }
}
