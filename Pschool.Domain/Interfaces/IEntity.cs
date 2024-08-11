namespace Pschool.Domain.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
        Guid CreatedBy { get; set; }
        Guid ModifiedBy { get; set; }
    }
}
