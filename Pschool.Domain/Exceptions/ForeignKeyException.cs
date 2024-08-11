namespace Pschool.Domain.Exceptions
{
    public class ForeignKeyException  : Exception
    {
        public ForeignKeyException(string data) : base($"You can`t delete this item by foreign key constraint. Detail: {data}")
        {
        }
    }
}
