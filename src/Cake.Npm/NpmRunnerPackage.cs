using System;
using System.IO;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Npm
{
	public partial class NpmRunner
	{
	    private readonly ICakeEnvironment _environment;
	    private readonly IFileSystem _fileSystem;

		/// <summary>
		/// Parses a package.json file in the current directory
		/// </summary>
		/// <returns>An object representing the NPM package details.</returns>
		/// <exception cref="System.IO.FileNotFoundException">Thrown when a package.json could not be found in the current directory</exception>
		public NpmPackage Package()
		{
		    return Package(_environment.WorkingDirectory);
		}

		/// <summary>
		/// Parses a package.json file in the specified directory
		/// </summary>
		/// <param name="packageDir">The directory containing the npm package (i.e. where package.json is located)</param>
		/// <returns>An object representing the npm package's details</returns>
		/// <exception cref="FileNotFoundException">Thrown when a package.json could not be found in the specified directory</exception>
		public NpmPackage Package(DirectoryPath packageDir)
		{
            var parser = new NpmPackageParser(_fileSystem, _environment);
            var package = parser.ParseFromFile(packageDir.CombineWithFilePath("./package.json"));
            return package;
        }
	}
}
