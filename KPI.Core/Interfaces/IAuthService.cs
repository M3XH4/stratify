using KPI.Core.DTOs;

namespace KPI.Core.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(UserRegistrationRequest request, CancellationToken cancellationToken = default);
    Task<AuthResponse?> LoginAsync(AuthRequest request, CancellationToken cancellationToken = default);
}
