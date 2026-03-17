using System.Security.Claims;

namespace MW.Identity.Token.Abstractions;

public interface IUserTokenManager
{
    /// <summary>
    /// Has User Login
    /// </summary>
    public bool HasLogin { get; }
    /// <summary>
    /// Get ClaimsPrincipal From Token 
    /// </summary>
    public ClaimsPrincipal? TokenClaimsPrincipal { get; }
    /// <summary>
    /// Token User Id
    /// </summary>
    public string? UserId { get; }
    /// <summary>
    /// Is Super Admin User
    /// </summary>
    public bool IsSuperAdmin { get; }
    /// <summary>
    /// Get Value From Token
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    string? Get(string type);

    T? Get<T>(string type);

    bool HasClaimType(string type);

    /// <summary>
    /// Get UserID And Check
    /// </summary>
    /// <param name="userClaims"></param>
    /// <returns> User ID | string </returns>
    string? GetUserId();

    /// <summary>
    /// Get User All Roles
    /// </summary>
    IList<string> GetUserRoles();

    /// <summary>
    /// Checks whether data access will be given to the user
    /// </summary>
    /// <param name="userId">User id</param>
    /// <returns> bool? | null mean => send Data is dirty </returns>
    bool? CheckUserAuthorize(string userId);

    bool IsInRole(string role);
    string GetHeaderValue(string key);
}