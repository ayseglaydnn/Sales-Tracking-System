namespace Application.Features.Auth.Commands.Register;
public class CustomerRegisterDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string CompanyName { get; set; }
    public string Password { get; set; }
}
