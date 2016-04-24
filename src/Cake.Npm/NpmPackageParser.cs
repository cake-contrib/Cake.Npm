using System;
using System.Text;
using Cake.Core;
using Cake.Core.IO;
using LitJson;
using System.Collections.Generic;
using System.Linq;
using Cake.Npm.Json;

namespace Cake.Npm
{
    internal class NpmPackageParser
    {
        private readonly IFileSystem _fileSystem;
        private readonly ICakeEnvironment _environment;

        public NpmPackageParser(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            if (fileSystem == null) throw new ArgumentNullException(nameof(fileSystem));
            if (environment == null) throw new ArgumentNullException(nameof(environment));
            _fileSystem = fileSystem;
            _environment = environment;
        }
        internal NpmPackage ParseFromFile(FilePath path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (path.IsRelative)
            {
                path = path.MakeAbsolute(_environment);
            }
            var file = _fileSystem.GetFile(path);
            if (!file.Exists)
            {
                throw new CakeException($"Package file not found at '{path}'!");
            }
            var content = string.Join(Environment.NewLine, file.ReadLines(Encoding.UTF8));
            var m = JsonMapper.ToObject<NpmPackageModel>(content);
            return new NpmPackage(m);
        }
    }
}