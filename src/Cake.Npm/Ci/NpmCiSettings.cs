namespace Cake.Npm.Ci
{
    /// <summary>
    /// Contains settings used by <see cref="NpmCiTool"/>.
    /// </summary>
    public class NpmCiSettings : NpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmCiSettings"/> class.
        /// </summary>
        public NpmCiSettings()
            : base("ci")
        {
        }
    }
}
