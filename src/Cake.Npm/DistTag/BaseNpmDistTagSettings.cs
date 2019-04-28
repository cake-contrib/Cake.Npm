namespace Cake.Npm.DistTag
{
    /// <summary>
    /// Contains settings used by <see cref="NpmDistTagTool"/>.
    /// </summary>
    public abstract class BaseNpmDistTagSettings : NpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseNpmDistTagSettings"/> class.
        /// </summary>
        protected BaseNpmDistTagSettings()
            : base("dist-tag")
        {
        }
    }
}
