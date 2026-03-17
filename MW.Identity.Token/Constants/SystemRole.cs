namespace MW.Identity.Token.Constants;

public class SystemRole
{
    public const string SuperAdmin = "SuperAdmin";
    public const string AdminPanel = SuperAdmin + "," + ProductAdmin;
    public const string User = "User";
    public const string ExternalSystem = "ExternalSystem";
    public const string ProductAdmin = "ProductAdmin";
    public const string MarketPlaceAdmin = "MarketPlaceAdmin";
    public const string PublicShopAdmin = "PublicShopAdmin";
}