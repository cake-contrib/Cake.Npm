using System.Collections.Generic;
using Cake.Npm.Json;

namespace Cake.Npm
{
	/// <summary>
	/// Describes the package properties extracted from package.json
	/// </summary>
	public class NpmPackage
	{
	    /// <summary>
	    /// Create a new NPM package descriptor
	    /// </summary>
	    public NpmPackage()
	    {
	    }

	    internal NpmPackage(NpmPackageModel model)
	    {
	        Version = model.version;
            Name = model.name;
            Description = model.description;
            Author = model.author;
            IsPrivate = model.@private;
            License = model.license;
            Scripts = model.scripts;
            Dependencies = model.dependencies;
            DevelopmentDependencies = model.devDependencies;
            Keywords = model.keywords;
            EntryPoint = model.main;
	    }

		/// <summary>
		/// Package version
		/// </summary>
		public string Version { get; set; }

		/// <summary>
		/// Package name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Short package description
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Package author/owner
		/// </summary>
		public string Author { get; set; }

		/// <summary>
		/// Indicates a private package (i.e. not published to the registry)
		/// </summary>
		public bool IsPrivate { get; set; }

		/// <summary>
		/// The license under which this package is distributed.
		/// </summary>
		public string License { get; set; }

		/// <summary>
		/// A collection of script names and commands
		/// </summary>
		public Dictionary<string, string> Scripts { get; set; } = new Dictionary<string, string>();

		/// <summary>
		/// A collection of package names and version strings listed as deployable dependencies
		/// </summary>
		public Dictionary<string, string> Dependencies { get; set; } = new Dictionary<string, string>();

		/// <summary>
		/// A collection of package names and version constraints listed as dependencies for developing with the package.
		/// </summary>
		public Dictionary<string, string> DevelopmentDependencies { get; set; } = new Dictionary<string, string>();

		/// <summary>
		/// Keywords for use when searching for packages
		/// </summary>
		public List<string> Keywords { get; set; } = new List<string>();

		/// <summary>
		/// The entry point or default export of the package/module
		/// </summary>
		public string EntryPoint { get; set; } = string.Empty;
	}
}
