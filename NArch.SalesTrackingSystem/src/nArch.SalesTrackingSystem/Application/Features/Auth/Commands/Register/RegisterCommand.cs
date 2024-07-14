using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Security.Hashing;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>
{
    public CustomerRegisterDto CustomerForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public RegisterCommand()
    {
        CustomerForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public RegisterCommand(CustomerRegisterDto customerForRegisterDto, string ipAddress)
    {
        CustomerForRegisterDto = customerForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public RegisterCommandHandler(
            ICustomerRepository customerRepository,
            IAuthService authService,
            AuthBusinessRules authBusinessRules,
            IUserOperationClaimRepository userOperationClaimRepository
        )
        {
            _customerRepository = customerRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.CustomerForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request.CustomerForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            Customer newCustomer =
                new()
                {
                    FirstName = request.CustomerForRegisterDto.FirstName,
                    LastName = request.CustomerForRegisterDto.LastName,
                    DateOfBirth = request.CustomerForRegisterDto.DateOfBirth,
                    CompanyName = request.CustomerForRegisterDto.CompanyName,
                    Email = request.CustomerForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };
            Customer createdUser = await _customerRepository.AddAsync(newCustomer);

            // User operation claims

            List<UserOperationClaim> userOperationClaims = new List<UserOperationClaim>
            {
                new UserOperationClaim { UserId = createdUser.Id, OperationClaimId = 25 },
                new UserOperationClaim { UserId = createdUser.Id, OperationClaimId = 30 },
                new UserOperationClaim { UserId = createdUser.Id, OperationClaimId = 36 }
            };

            await _userOperationClaimRepository.AddRangeAsync(userOperationClaims);

            RegisteredResponse registeredResponse = 
                new() { Email = request.CustomerForRegisterDto.Email, Password = request.CustomerForRegisterDto.Password };
            
            return registeredResponse;
        }
    }
}
