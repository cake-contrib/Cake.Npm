namespace Cake.Npm.Install
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.IO;

    /// <summary>
    /// Contains settings used by <see cref="NpmInstaller"/>.
    /// </summary>
    public class NpmInstallSettings : NpmSettings
    {
        private readonly List<string> _packages = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="NpmInstallSettings"/> class.
        /// </summary>
        public NpmInstallSettings()
            : base("install")
        {
        }

        /// <summary>
        /// Gets a value indicating whether npm should fetch remote resources even if a local copy
        /// exists on disk.
        /// </summary>
        public bool Force { get; set; }

        /// <summary>
        /// Gets a value indicating whether the package should be installed globally rather than locally.
        /// </summary>
        public bool Global { get; set; }

        /// <summary>
        /// Gets a value indicating whether npm should ignore modules listed in <code>devDependencies</code>.
        /// </summary>
        public bool Production { get; set; }

        /// <summary>
        /// Gets a value indicating whether npm should prevent optional dependencies from being installed
        /// (the --no-optional argument)
        /// </summary>
        public bool NoOptional { get; set; }

        /// <summary>
        /// Gets the list of packages which should be installed.
        /// </summary>
        public IList<string> Packages => _packages;

        /// <summary>
        /// Gets or sets a value indicating which registry we should point to. Defaulted to whatever the NPM configuration is.
        /// </summary>
        public Uri Registry { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not to utilise the prefer offline flag, avoiding going to the internet for packages if possible.
        /// </summary>
        public bool PreferOffline { get; set; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            foreach (var package in Packages)
            {
                args.Append(package);
            }

            if (Force)
            {
                args.Append("--force");
            }

            if (Global)
            {
                args.Append("--global");
            }

            if (NoOptional)
            {
                args.Append("--no-optional");
            }

            if (Registry != null)
            {
                args.AppendSwitch("--registry", Registry.ToString());
            }

            if (PreferOffline)
            {
                args.Append("--prefer-offline");
            }

            if (Production)
            {
                if (Packages.Any())
                {
                    throw new NotSupportedException("Can't specify production flag when installing individual packages");
                }

                args.Append("--production");
            }
        }
    }
}
