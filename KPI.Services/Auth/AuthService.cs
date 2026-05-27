using KPI.Core.DTOs;
using KPI.Core.Entities;
using KPI.Core.Interfaces;

namespace KPI.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthResponse> RegisterAsync(UserRegistrationRequest request, CancellationToken cancellationToken = default)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (existingUser is not null)
        {
            throw new InvalidOperationException("Email is already registered.");
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = _passwordHasher.Hash(request.Password),
            DepartmentId = request.DepartmentId,
            ReceiveEmailNotifications = true,
            UserRoles = new List<UserRole>
            {
                new() { RoleId = 3 }
            }
        };

        await _userRepository.AddAsync(user, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);

        var roles = await _userRepository.GetRoleNamesAsync(user.Id, cancellationToken);
        return new AuthResponse(user.Id, $"{user.FirstName} {user.LastName}", user.Email, roles, user.DepartmentId);
    }

    public async Task<AuthResponse?> LoginAsync(AuthRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is null || !_passwordHasher.Verify(request.Password, user.PasswordHash) || !user.IsActive)
        {
            return null;
        }

        user.LastLoginAt = DateTime.UtcNow;
        await _userRepository.SaveChangesAsync(cancellationToken);

        var roles = await _userRepository.GetRoleNamesAsync(user.Id, cancellationToken);
        return new AuthResponse(user.Id, $"{user.FirstName} {user.LastName}", user.Email, roles, user.DepartmentId);
    }
}
