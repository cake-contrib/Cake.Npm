namespace Cake.Npm.AddUser;

using System;
using System.Linq;
using Core;
using Core.IO;

/// <summary>
/// Contains settings used by <see cref="NpmAddUser"/>.
/// </summary>
public class NpmAddUserSettings : NpmSettings
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NpmAddUserSettings"/> class.
    /// </summary>
    public NpmAddUserSettings()
        : base("adduser")
    {
    }

    /// <summary>
    /// Gets or sets a value indicating which registry we should point to. Defaulted to the current NPM configuration.
    /// </summary>
    public Uri Registry { get; set; }

    /// <summary>
    /// Gets or sets a value indicating the specificed scope for the user and login credentials provided. Defaults to <c>string.Empty</c>.
    /// </summary>
    public string Scope { get; set; }

    /// <summary>
    /// Gets a value indicating that all requests to the given registry should 
    /// include authorization information. Defaults to <c>false</c>.
    /// </summary>
    public bool AlwaysAuth { get; set; }

    /// <summary>
    /// Gets or sets the authentication stragety to use. Defaults to <c>AuthType.Legacy</c>
    /// </summary>
    public AuthType AuthType { get; set; }

    /// <summary>
    /// Evaluates the settings and writes them to <paramref name="args"/>.
    /// </summary>
    /// <param name="args">The argument builder into which the settings should be written.</param>
    protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        base.EvaluateCore(args);

        if (Registry != null)
        {
            args.AppendSwitch("--registry", Registry.ToString());
        }

        if (!string.IsNullOrWhiteSpace(Scope))
        {
            if (!Scope.StartsWith('@'))
            {
                throw new ArgumentException("Scope should start with @", nameof(Scope));
            }
            args.AppendSwitch("--scope", Scope.ToString());
        }

        if (AlwaysAuth)
        {
            args.Append("--always-auth");
        }

        switch (AuthType)
        {
            case AuthType.Legacy:
                args.AppendSwitch("--auth-type", "legacy");
                break;
            case AuthType.OAuth:
                args.AppendSwitch("--auth-type", "oauth");
                break;
            case AuthType.SSO:
                args.AppendSwitch("--auth-type", "sso");
                break;
            case AuthType.Saml:
                args.AppendSwitch("--auth-type", "saml");
                break;
            case AuthType.Default:
                break;
            default:
                throw new ArgumentOutOfRangeException("Authentication Type is not a valid value.");
        }
        
    }
}
