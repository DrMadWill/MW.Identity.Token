using System.Security.Claims;
using MW.Identity.Token.Constants;

namespace MW.Identity.Token.Extensions;

public static class UserUtils
{
    public static string? Get(this ClaimsPrincipal claimsPrincipal, string type)
    {
        return claimsPrincipal.FindFirst(type)?.Value;
    }

    public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.Get(UserConstant.UserId);
        if (userId == null) throw new Exception("User ID not found in claims");
        return userId;
    }

    public static string? GetUserName(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.UserName);

    public static string? GetUserEmail(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.Email);

    public static string? GetUserRoles(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.Roles);

    public static string? GetUserDisplayName(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.DisplayName);

    public static string? GetUserPhone(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.Phone);

    public static string? GetUserCreatedDate(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.CreatedDate);

    public static string? GetTelegramChatId(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.TelegramChatId);

    public static string? GetSystemId(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.SystemId);

    public static string? GetExpiration(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.Expiration);

    public static string? GetShopPointId(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.ShopPointId);

    public static string? GetShopPointName(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.ShopPointName);

    public static string? GetIsTemporaryPassword(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.IsTemporaryPassword);

    public static string? GetCreatedMarketPlaceUserId(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.CreatedMarketPlaceUserId);

    public static string? GetName(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Get(UserConstant.Name);

    public static bool IsSuperAdmin(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.IsInRole(SystemRole.SuperAdmin);

    public static bool IsProductAdmin(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.IsInRole(SystemRole.ProductAdmin);

    public static bool IsMarketPlaceAdmin(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.IsInRole(SystemRole.MarketPlaceAdmin);

    public static bool IsPublicShopAdmin(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.IsInRole(SystemRole.PublicShopAdmin);

    public static bool IsExternalSystem(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.IsInRole(SystemRole.ExternalSystem);

    public static bool IsUser(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.IsInRole(SystemRole.User);
}
