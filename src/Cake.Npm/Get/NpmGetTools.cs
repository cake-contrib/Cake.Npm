using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cake.Npm.Get
{
    class NpmGetTools : NpmTool<NpmSettings>
    {
        public NpmGetTools(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log)
            : base(fileSystem, environment, processRunner, tools, log)
        {
        }


        public string Get(NpmGetSettings settings)
        {
            if (string.IsNullOrWhiteSpace(settings.Key))
            {
                throw new ArgumentException();
            }
            IEnumerable<string> output = new List<string>();
            RunCore(settings, new ProcessSettings(), process =>
            {
                output = process.GetStandardOutput();
            });
            return output.SingleOrDefault();
        }
    }
}
