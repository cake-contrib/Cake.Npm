namespace Cake.Npm.Version
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Contains settings used by <see cref="NpmVersionTool"/>.
    /// </summary>
    public class NpmVersionSettings : NpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmVersionSettings"/> class.
        /// </summary>
        public NpmVersionSettings()
            : base("version")
        {
            // Since 'NpmVersion' returns a string we should redirect standard output.
            RedirectStandardOutput = true;
        }
    }
}
