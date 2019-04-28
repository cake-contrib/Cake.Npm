namespace Cake.Npm.DistTag
{
    using System;
    using System.Linq;
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Contains settings used by <see cref="NpmDistTagTool"/> to remove distribution tags.
    /// </summary>
    public class NpmDistTagRemoveSettings : BaseNpmDistTagSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmDistTagRemoveSettings"/> class.
        /// </summary>
        /// <param name="packageName">Package on which a tag should be removed.</param>
        /// <param name="tag">Tag which should be removed.</param>
        public NpmDistTagRemoveSettings(string packageName, string tag)
        {
            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException(nameof(tag));
            }

            this.PackageName = packageName;
            this.Tag = tag;
        }

        /// <summary>
        /// Gets the name of the package on which the tag should be removed.
        /// </summary>
        public string PackageName { get; }

        /// <summary>
        /// Gets the tag to be removed.
        /// </summary>
        public string Tag { get; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args" />.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            args.Append("rm");
            args.Append(PackageName);
            args.Append(Tag);
        }
    }
}
