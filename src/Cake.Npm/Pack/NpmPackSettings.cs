namespace Cake.Npm.Pack
{
    using Core;
    using Core.IO;

    /// <summary>
    /// Contains settings used by <see cref="NpmPacker"/>.
    /// </summary>
    public class NpmPackSettings : NpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmPackSettings"/> class.
        /// </summary>
        public NpmPackSettings()
            : base("pack")
        {
        }

        /// <summary>
        /// Source to pack.
        /// Can be anything that is installable by npm, like a package folder, tarball, tarball url,
        /// name@tag, name@version, name, or scoped name.
        /// </summary>
        public string Source { get; set; }

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
        }
    }
}
