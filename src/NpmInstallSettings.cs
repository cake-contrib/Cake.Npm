using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Npm
{
    public class NpmInstallSettings : NpmRunnerSettings
    {
        private readonly ISet<string> _packages = new HashSet<string>();

        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            foreach (var package in Packages)
            {
                args.Append(package);
            }

            if (Global) args.Append("--global");
            if (Production) args.Append("--production");
        }

        /// <summary>
        /// install a package from the given url
        /// </summary>
        /// <param name="url">Url to directory containing package.json (see npm docs)</param>
        /// <returns></returns>
        public NpmInstallSettings Package(Uri url)
        {
            if(!url.IsAbsoluteUri) throw new UriFormatException("must be to an absolute url to package");
            _packages.Clear();
            _packages.Add(url.AbsoluteUri);
            return this;
        }

        /// <summary>
        /// install a package by name, with optional version/tag and scope
        /// </summary>
        /// <param name="package"></param>
        /// <param name="versionOrTag"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public NpmInstallSettings Package(string package, string versionOrTag = null, string scope = null)
        {
            var packageName = package;
            if (!string.IsNullOrWhiteSpace(versionOrTag))
            {
                var versionOrTagValue = versionOrTag;
                if (versionOrTagValue.Contains(" ")) versionOrTagValue = versionOrTag.Quote();
                packageName = $"{package}@{versionOrTagValue}";
            }

            if (!string.IsNullOrWhiteSpace(scope))
            {
                if (!scope.StartsWith("@")) throw new ArgumentException("scope should start with @");
                packageName = !string.IsNullOrWhiteSpace(scope) ? $"{scope}/{packageName}" : packageName;
            }
            
            _packages.Add(packageName);
            return this;
        }

        /// <summary>
        /// Applies the --global parameter
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public NpmInstallSettings Globally(bool enabled = true)
        {
            Global = enabled;
            return this;
        }
        
        /// <summary>
        /// Applies the --production parameter (can not be set when installing individual packages
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public NpmInstallSettings ForProduction(bool enabled = true)
        {
            if(_packages.Any()) throw new ArgumentException("cant specify production flag when installing individual packages");
            Production = enabled;
            return this;
        }

        /// <summary>
        /// List of packages to install
        /// </summary>
        public IEnumerable<string> Packages => _packages;
        /// <summary>
        /// --global
        /// </summary>
        public bool Global { get; internal set; }
        /// <summary>
        /// --production
        /// </summary>
        public bool Production { get; internal set; }
    }
}