namespace Cake.Npm.View
{
    using System.Linq;
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Contains settings used by <see cref="NpmViewTool"/>.
    /// </summary>
    public class NpmViewSettings : NpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmViewSettings"/> class.
        /// </summary>
        public NpmViewSettings() 
            : base("view")
        {
            RedirectStandardOutput = true;
        }

        /// <summary>
        /// Gets or sets the name of the package for which the registry entry should be shown.
        /// </summary>
        public string PackageName { get; set; }

        /// <inheritdoc />
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            args.Append("--json");
            args.Append(PackageName);
        }
    }
}
