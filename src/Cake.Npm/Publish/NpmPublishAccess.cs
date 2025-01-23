namespace Cake.Npm.Publish;

/// <summary>
/// Possible values for <see cref="NpmPublishSettings.Access"/>.
/// </summary>
public enum NpmPublishAccess
{
    /// <summary>
    /// Default value for <c>npm publish</c>.
    /// </summary>
    Default,

    /// <summary>
    /// Public access.
    /// </summary>
    Public,

    /// <summary>
    /// Restricted access.
    /// </summary>
    Restricted
}
