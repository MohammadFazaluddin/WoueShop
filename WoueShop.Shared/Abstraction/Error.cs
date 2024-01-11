namespace WoueShop.Shared.Abstraction
{
    ///<summary>
    ///     Custom defined Error class for exception handling
    ///</summary>
    public sealed record Error(string code, string? description = null)
    {
        public static readonly Error None = new(string.Empty);
    }
}
