namespace Cake.Npm.AddUser;

/// <summary>
/// Contains the valid auth strategies for <see cref="NpmAddUser"/>.
/// </summary>
public enum AuthType
{
    /// <summary>
    /// Default Authentication.
    /// </summary>
    Default,
    /// <summary>
    /// Legacy Authentication.
    /// </summary>
    Legacy,
    /// <summary>
    /// SSO Authentication.
    /// </summary>
    SSO,
    /// <summary>
    /// SAML Authentication.
    /// </summary>
    Saml,
    /// <summary>
    /// OAuth Authentication.
    /// </summary>
    OAuth
}
