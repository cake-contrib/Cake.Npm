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
        /// Source to publish.
        /// A folder containing a package.json file or an url or file path to a gzipped tar archive 
        /// containing a single folder with a package.json file inside.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Registry where the package should be published to.
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

            if (Registry != null)
            {
                args.AppendSwitch("--registry", Registry.ToString());
            }
        }
    }
}
