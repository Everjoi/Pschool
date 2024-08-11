namespace Pschool.Domain.Exceptions
{
    public class RepositoryNotFoundException : Exception
    {
        public RepositoryNotFoundException(string repository) : base($"Repository: {repository} not found")
        {
        }
    }
}
