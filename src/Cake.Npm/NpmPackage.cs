using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core.IO;
using Newtonsoft.Json;

namespace Cake.Npm
{
	public class NpmPackage
	{
		[JsonProperty("version")]
		public string Version { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("author")]
		public string Author { get; set; }

		[JsonProperty("private")]
		public bool IsPrivate { get; set; }

		[JsonProperty("license")]
		public string License { get; set; }

		[JsonProperty("scripts")]
		public Dictionary<string, string> Scripts { get; set; } = new Dictionary<string, string>();

		[JsonProperty("dependencies")]
		public Dictionary<string, string> Dependencies { get; set; } = new Dictionary<string, string>();

		[JsonProperty("devDependencies")]
		public Dictionary<string, string> DevelopmentDependencies { get; set; } = new Dictionary<string, string>();
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
