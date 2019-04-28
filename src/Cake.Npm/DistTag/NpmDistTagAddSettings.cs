namespace Cake.Npm.DistTag
{
    using Cake.Core;
    using Cake.Core.IO;
    using System;
    using System.Linq;

    /// <summary>
    /// Contains settings used by <see cref="NpmDistTagTool"/> to add distribution tags.
    /// </summary>
    public class NpmDistTagAddSettings : BaseNpmDistTagSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmDistTagAddSettings"/> class.
        /// </summary>
        /// <param name="packageName">Package to which the tag should be added.</param>
        /// <param name="packageVersion">The package version on which the tag will be applied</param>
        public NpmDistTagAddSettings(string packageName, string packageVersion)
        {
            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            if (string.IsNullOrWhiteSpace(packageVersion))
            {
                throw new ArgumentNullException(nameof(packageVersion));
            }

            PackageName = packageName;
            PacakgeVersion = packageVersion;
        }

        /// <summary>
        /// Gets the bane of the package on which the tag should be applied.
        /// </summary>
        public string PackageName { get; }

        /// <summary>
        /// Gets the vrsion of the package on which the tag will be applied.
        /// </summary>
        public string PacakgeVersion { get; }

        /// <summary>
        /// Gets or sets the tag to be added.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args" />.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            args.Append("add");
            args.Append($"{PackageName}@{PacakgeVersion}");

            if (!string.IsNullOrWhiteSpace(Tag))
            {
                args.Append(Tag);
            }
        }
    }
}
