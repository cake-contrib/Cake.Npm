namespace Cake.Npm.Prune
{
    using Core;
    using Core.IO;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Contains settings used by <see cref="NpmPruneRunner"/>.
    /// </summary>
    public class NpmPruneSettings : NpmSettings
    {
        private readonly List<string> _packages = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="NpmPruneSettings"/> class.
        /// </summary>
        public NpmPruneSettings()
            : base("prune")
        {
        }

        /// <summary>
        /// Whether npm should remove modules listed in <code>devDependencies</code>.
        /// </summary>
        public bool Production { get; set; }

        /// <summary>
        /// If a package name is added, then only packages matching one of the supplied names are removed.
        /// </summary>
        public IList<string> Packages => _packages;

        /// <summary>
        /// If true, then no changes will actually be made.
        /// </summary>
        public bool DryRun { get; set; }

        /// <summary>
        /// If true, then the changes npm prune made (or would have made with DryRun) are printed as a JSON object.
        /// </summary>
        public bool Json { get; set; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            foreach(var package in Packages)
            {
                args.Append(package);
            }

            if (DryRun)
            {
                args.Append("--dry-run");
            }

            if (Json)
            {
                args.Append("--json");
            }

            if (Production)
            {
                args.Append("--production");
            }
        }
    }
}
