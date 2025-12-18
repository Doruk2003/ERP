using Admin.Application.Abstractions.Persistence;
using Admin.Application.Common;
using Admin.Domain.Users;
using MediatR;

namespace Admin.Application.Users.Create;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        var exists = await _userRepository.EmailExistsAsync(email, cancellationToken);

        if (exists)
            return Result.Failure("Email already exists.");

        var user = User.Create(email, request.FirstName, request.LastName);

        await _userRepository.AddAsync(user, cancellationToken);

        return Result.Success();
    }
}
