namespace Domain.Entities;
public class Customer : User
{
    public string CompanyName { get; set; }

    public ICollection<Sale> Sales { get; set; }

    public Customer()
    {

    }
    public Customer(Guid id, string firstName, string lastName,
        string companyName, string email, string phone,
        byte[] passwordHash, byte[] passwordSalt)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        CompanyName = companyName;
        Email = email;
        Phone = phone;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}
