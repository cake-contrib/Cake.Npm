namespace Cake.Npm
{
    using System.Reflection;
    using Cake.Core.Diagnostics;

    /// <summary>
    /// Helper to log addin version information
    /// </summary>
    internal static class AddinInformation
    {
        private static readonly string InformationalVersion = typeof(AddinInformation).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        private static readonly string AssemblyVersion = typeof(AddinInformation).GetTypeInfo().Assembly.GetName().Version.ToString();
        private static readonly string AssemblyName = typeof(AddinInformation).GetTypeInfo().Assembly.GetName().Name;

        /// <summary>
        /// verbosely log addin version information
        /// </summary>
        /// <param name="log"></param>
        public static void LogVersionInformation(ICakeLog log)
        {
            log.Verbose(entry => entry("Using addin: {0} v{1} ({2})", AssemblyName, AssemblyVersion, InformationalVersion));
        }
    }
}