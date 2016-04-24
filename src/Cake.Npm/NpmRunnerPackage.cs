using System;
using System.IO;
using Cake.Core.IO;

namespace Cake.Npm
{
	public partial class NpmRunner
	{

		/// <summary>
		/// Parses a package.json file in the current directory
		/// </summary>
		/// <returns>An object representing the NPM package details.</returns>
		/// <exception cref="System.IO.FileNotFoundException">Thrown when a package.json could not be found in the current directory</exception>
		public NpmPackage Package()
		{
			if (!System.IO.File.Exists("package.json")) throw new System.IO.FileNotFoundException($"Could not locate package.json in '{Environment.CurrentDirectory}'");
			var parser = new NpmPackageParser();
			var package = parser.ParseFromFile(new FilePath(System.IO.Path.Combine(Environment.CurrentDirectory, "package.json")));
			return package;
		}

		/// <summary>
		/// Parses a package.json file in the specified directory
		/// </summary>
		/// <param name="packageDir">The directory containing the npm package (i.e. where package.json is located)</param>
		/// <returns>An object representing the npm package's details</returns>
		/// <exception cref="FileNotFoundException">Thrown when a package.json could not be found in the specified directory</exception>
		public NpmPackage Package(DirectoryPath packageDir)
		{
			var oldDir = Environment.CurrentDirectory;
			Environment.CurrentDirectory = packageDir.FullPath;
			var package = Package();
			Environment.CurrentDirectory = oldDir;
			return package;
		}
	}
}
