using Cake.Core;
using Cake.Core.IO;

namespace Cake.Npm.Version
{
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
        }
    }
}
