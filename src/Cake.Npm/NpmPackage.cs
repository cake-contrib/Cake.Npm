using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core.IO;
using Newtonsoft.Json;

namespace Cake.Npm
{
	/// <summary>
	/// Describes the package properties extracted from package.json
	/// </summary>
	public class NpmPackage
	{
		/// <summary>
		/// Package version
		/// </summary>
		[JsonProperty("version")]
		public string Version { get; set; }

		/// <summary>
		/// Package name
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Short package description
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Package author/owner
		/// </summary>
		[JsonProperty("author")]
		public string Author { get; set; }

		/// <summary>
		/// Indicates a private package (i.e. not published to the registry)
		/// </summary>
		[JsonProperty("private")]
		public bool IsPrivate { get; set; }

		/// <summary>
		/// The license under which this package is distributed.
		/// </summary>
		[JsonProperty("license")]
		public string License { get; set; }

		/// <summary>
		/// A collection of script names and commands
		/// </summary>
		[JsonProperty("scripts")]
		public Dictionary<string, string> Scripts { get; set; } = new Dictionary<string, string>();

		/// <summary>
		/// A collection of package names and version strings listed as deployable dependencies
		/// </summary>
		[JsonProperty("dependencies")]
		public Dictionary<string, string> Dependencies { get; set; } = new Dictionary<string, string>();

		/// <summary>
		/// A collection of package names and version constraints listed as dependencies for developing with the package.
		/// </summary>
		[JsonProperty("devDependencies")]
		public Dictionary<string, string> DevelopmentDependencies { get; set; } = new Dictionary<string, string>();

		/// <summary>
		/// Keywords for use when searching for packages
		/// </summary>
		[JsonProperty("keywords")]
		public List<string> Keywords { get; set; } = new List<string>();

		/// <summary>
		/// The entry point or default export of the package/module
		/// </summary>
		[JsonProperty("main")]
		public string EntryPoint { get; set; } = string.Empty;
	}

	internal class NpmPackageParser
	{
		internal NpmPackage ParseFromFile(FilePath path)
		{
			var json = JsonConvert.DeserializeObject<NpmPackage>(System.IO.File.ReadAllText(path.FullPath));
			return json;
		}
	}
}
