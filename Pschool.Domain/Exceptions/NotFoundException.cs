namespace Pschool.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Type type, Guid id) : base($"Item {type}: {id} not found")
        {
        }
    }
}
