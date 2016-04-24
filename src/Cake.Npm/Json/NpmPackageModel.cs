using System.Collections.Generic;

#pragma warning disable 1591
namespace Cake.Npm.Json
{
    internal class NpmPackageModel
    {
        public string main { get; set; }
        public string name { get; set; }
        public string version { get; set; }
        public string description { get; set; }
        public string author { get; set; }
        public bool @private { get; set; }
        public string license { get; set; }
        public List<string> keywords { get; set; }
        public Dictionary<string, string> devDependencies { get; set; }
        public Dictionary<string, string> dependencies { get; set; }
        public Dictionary<string, string> scripts { get; set; }

    }
}