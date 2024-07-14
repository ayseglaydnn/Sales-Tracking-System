
namespace Domain.Entities;
public class Employee : User
{
    public string Position { get; set; }

    public Employee()
    {
        
    }
    public Employee(Guid id, string firstName, string lastName, DateTime dateOfBirth, 
        string email, string phone, byte[] passwordHash, byte[] passwordSalt, string position)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Email = email;
        Phone = phone;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        Position = position;
    }
}
