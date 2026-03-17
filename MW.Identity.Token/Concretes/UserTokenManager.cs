using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MW.Identity.Token.Abstractions;
using MW.Identity.Token.Constants;
using Newtonsoft.Json;

namespace MW.Identity.Token.Concretes;

public class UserTokenManager: IUserTokenManager 
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserTokenManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool HasLogin => _httpContextAccessor.HttpContext.User?.Identity?.IsAuthenticated == true;
    
    public ClaimsPrincipal? TokenClaimsPrincipal =>
         HasLogin ? _httpContextAccessor.HttpContext.User : null;

    public string? UserId => HasLogin ? GetUserId() : null;
    
    public bool IsSuperAdmin => HasLogin && TokenClaimsPrincipal != null && TokenClaimsPrincipal.IsInRole(SystemRole.SuperAdmin);

    /// <summary>
    /// Get UserID And Check
    /// </summary>
    /// <returns> User ID | string </returns>
    public string? GetUserId()
    {
        
        var currentUserId = HasClaimType(UserConstant.UserId) ? TokenClaimsPrincipal.FindFirst(UserConstant.UserId).Value : null;
        if (currentUserId == null) return null;
        return currentUserId;
    }

    public string? Get(string type)
        => HasClaimType(type) ? TokenClaimsPrincipal?.Claims?.FirstOrDefault(s => s.Type == type)?.Value
                                                                                : null;
    
    public T? Get<T>(string type)
    {
        var value = Get(type);
        if (!string.IsNullOrEmpty(value)) return JsonConvert.DeserializeObject<T>(value);
        return default;
    }

    public bool HasClaimType(string type) => HasLogin && TokenClaimsPrincipal != null &&
        TokenClaimsPrincipal.HasClaim(s => s.Type == type);

    /// <summary>
    /// Get User All Roles
    /// </summary>
    public IList<string> GetUserRoles()
    {
        var userRoles =  Get(UserConstant.Roles) ; // superamdin,admin,user 
        return userRoles is null ?  new List<string>() :
                userRoles.Contains(",") ? userRoles.Split(",").ToList() : new List<string>{userRoles};
    }
    
    public bool IsInRole(string role) => HasLogin && TokenClaimsPrincipal != null && TokenClaimsPrincipal.IsInRole(role);

    public string GetHeaderValue(string key) => _httpContextAccessor.HttpContext.Request.Headers[key];
    
    /// <summary>
    /// Checks whether data access will be given to the user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns> bool? | null mean => send Data is dirty </returns>
    public bool? CheckUserAuthorize(string userId)
    {
        if (TokenClaimsPrincipal == null || !HasLogin) return false;
        if (TokenClaimsPrincipal.IsInRole(SystemRole.SuperAdmin)) return true;
        return GetUserId() == userId;
    }    
}