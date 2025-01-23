namespace Cake.Npm;

/// <summary>
/// Details the npm log levels
/// </summary>
public enum NpmLogLevel
{
    /// <summary>
    /// Uses log level as defined by the running Cake script.
    /// </summary>
    Default,

    /// <summary>
    /// -s, --silent or --loglevel silent
    /// </summary>
    Silent,

    /// <summary>
    /// -q, --quiet or --loglevel warn
    /// </summary>
    Warn,

    /// <summary>
    /// -d or --loglevel info
    /// </summary>
    Info,

    /// <summary>
    /// --loglevel error
    /// </summary>
    Error,

    /// <summary>
    /// -dd or --loglevel verbose
    /// </summary>
    Verbose,

    /// <summary>
    /// -ddd or --loglevel silly
    /// </summary>
    Silly,

    /// <summary>
    /// --loglevel http
    /// </summary>
    Http
}