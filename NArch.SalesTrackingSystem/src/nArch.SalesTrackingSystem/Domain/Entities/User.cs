namespace Domain.Entities;

public class User : NArchitecture.Core.Security.Entities.User<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Phone { get; set; }


    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;
    public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = default!;
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = default!;

    public User()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
    }

    public User(Guid id, string firstName, string lastName, DateTime dateOfBirth,
        string email, string phone, byte[] passwordHash, byte[] passwordSalt) : this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Email = email;
        Phone = phone;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}
