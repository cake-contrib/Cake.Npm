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
        private readonly List<string> _packages = new List<string>();

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
        /// Gets the list of packages which should be installed.
        /// </summary>
        public IList<string> Packages => _packages;

        /// <summary>
        /// Install a package from a specific url.
        /// </summary>
        /// <param name="url">Url to directory containing package.json (see npm docs)</param>
        public NpmInstallSettings AddPackage(Uri url)
        {
            if (!url.IsAbsoluteUri)
            {
                throw new UriFormatException("Must be to an absolute url to the npm package.");
            }

            _packages.Add(url.AbsoluteUri);
            return this;
        }

        /// <summary>
        /// Install a package by name, version/tag.
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        public NpmInstallSettings AddPackage(string packageName)
        {
            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            return AddPackage(packageName, null, null);
        }

        /// <summary>
        /// Install a package by name and version/tag.
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="versionOrTag">Version or tag published to the registry.</param>
        public NpmInstallSettings AddPackage(string packageName, string versionOrTag)
        {
            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            if (string.IsNullOrWhiteSpace(versionOrTag))
            {
                throw new ArgumentNullException(nameof(versionOrTag));
            }

            return AddPackage(packageName, null, versionOrTag);
        }

        /// <summary>
        /// Install a scoped package by name, version/tag.
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="scope">Scope of the package.</param>
        public NpmInstallSettings AddScopedPackage(string packageName, string scope)
        {
            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            if (string.IsNullOrWhiteSpace(scope))
            {
                throw new ArgumentNullException(nameof(scope));
            }

            return AddPackage(packageName, scope, null);
        }

        /// <summary>
        /// Install a package by name, version/tag and scope.
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="scope">Scope of the package. Null for not restricting to a scope.</param>
        /// <param name="versionOrTag">Version or tag published to the registry. Null for latest version.</param>
        public NpmInstallSettings AddPackage(string packageName, string scope, string versionOrTag)
        {
            var resolvedPackageName = packageName;

            if (!string.IsNullOrWhiteSpace(versionOrTag))
            {
                var versionOrTagValue = versionOrTag;
                if (versionOrTagValue.Contains(" "))
                {
                    versionOrTagValue = versionOrTag.Quote();
                }
                resolvedPackageName = $"{packageName}@{versionOrTagValue}";
            }

            if (!string.IsNullOrWhiteSpace(scope))
            {
                if (!scope.StartsWith("@"))
                {
                    throw new ArgumentException("Scope should start with @", nameof(scope));
                }

                resolvedPackageName = 
                    !string.IsNullOrWhiteSpace(scope) ? $"{scope}/{resolvedPackageName}" : resolvedPackageName;
            }

            _packages.Add(resolvedPackageName);
            return this;
        }

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
