namespace Pschool.Domain.Common
{
    public class BaseEvent
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
