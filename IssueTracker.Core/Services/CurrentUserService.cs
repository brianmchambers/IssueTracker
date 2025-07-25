using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace IssueTracker.Core.Services
{
    public interface ICurrentUserService
    {
        Task<ClaimsPrincipal> GetUserAsync();
        Task<string?> GetUserNameAsync();
    }

    public class CurrentUserService(AuthenticationStateProvider authProvider) : ICurrentUserService
    {
        public async Task<ClaimsPrincipal> GetUserAsync()
        {
            var authState = await authProvider.GetAuthenticationStateAsync();
            return authState.User;
        }

        public async Task<string?> GetUserNameAsync()
        {
            return await Task.FromResult("Brian");
            // var user = await GetUserAsync();
            // return user.Identity?.Name?.Split('\\').Last();
        }
    }
}
