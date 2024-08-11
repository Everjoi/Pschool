namespace Pschool.Domain.Exceptions
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException(Type type, Guid id) : base($"Item: {type} with id: {id} already exist")
        {
        }
    }
}
