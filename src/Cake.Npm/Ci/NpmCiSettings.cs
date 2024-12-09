namespace Cake.Npm.Ci
{
    using Cake.Core;
    using Cake.Core.IO;
    using System;

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

        /// <summary>
        /// Gets a value indicating whether npm should ignore modules listed in <code>devDependencies</code>.
        /// </summary>
        public bool Production { get; set; }

        /// <summary>
        /// Gets or sets the registry where packages should be restored from.
        /// Defaulted to whatever the NPM configuration is.
        /// </summary>
        public Uri Registry { get; set; }

        /// <inheritdoc />
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            if (Production)
            {
                args.Append("--production");
            }

            if (Registry != null)
            {
                args.AppendSwitch("--registry", Registry.ToString());
            }
        }
    }
}
