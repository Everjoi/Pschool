namespace Pschool.Domain.Interfaces
{
    internal interface IPersonEntity : IEntity
    {
        string Name { get; set; }
        string Surname { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        DateTime DateOfBirth { get; set; }
        string Gender { get; set; }
    }
}
