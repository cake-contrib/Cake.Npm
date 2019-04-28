namespace Cake.Npm.DistTag
{
    using Cake.Core;
    using Cake.Core.IO;
    using System.Linq;

    /// <summary>
    /// Contains settings used by <see cref="NpmDistTagTool"/> to list distribution tags.
    /// </summary>
    public class NpmDistTagListSettings : BaseNpmDistTagSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmDistTagListSettings"/> class.
        /// </summary>
        public NpmDistTagListSettings()
        {
        }

        /// <summary>
        /// Gets or sets the name of the package for which tags should be returned.
        /// </summary>
        public string PackageName { get; set; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args" />.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            args.Append("ls");
            args.Append(PackageName);
        }
    }
}
