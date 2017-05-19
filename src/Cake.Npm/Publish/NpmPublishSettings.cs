namespace Cake.Npm.Publish
{
    using System;
    using Core;
    using Core.IO;

    /// <summary>
    /// Contains settings used by <see cref="NpmPublisher"/>.
    /// </summary>
    public class NpmPublishSettings : NpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmPublishSettings"/> class.
        /// </summary>
        public NpmPublishSettings()
            : base("publish")
        {
        }

        /// <summary>
        /// Gets or sets the source to publish.
        /// A folder containing a package.json file or an url or file path to a gzipped tar archive 
        /// containing a single folder with a package.json file inside.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the tag with which the package will be published.
        /// By default the <c>latest</c> tag is used. 
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets whether the package should be published as public or restricted.
        /// </summary>
        public NpmPublishAccess Access { get; set; }

        /// <summary>
        /// Gets or sets the registry where the package should be published to.
        /// </summary>
        public Uri Registry { get; set; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            if (!string.IsNullOrWhiteSpace(Source))
            {
                args.AppendQuoted(Source);
            }

            if (!string.IsNullOrWhiteSpace(Tag))
            {
                args.AppendSwitch("--tag", Tag);
            }

            if (Access != NpmPublishAccess.Default)
            {
                args.AppendSwitch("--access", Access.ToString().ToLowerInvariant());
            }

            if (Registry != null)
            {
                args.AppendSwitch("--registry", Registry.ToString());
            }
        }
    }
}
