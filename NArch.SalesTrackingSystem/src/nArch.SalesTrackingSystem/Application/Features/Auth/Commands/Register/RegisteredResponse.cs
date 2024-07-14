using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.Register;

public class RegisteredResponse : IResponse
{
    public string Email { get; set; }
    public string Password { get; set; }
}
