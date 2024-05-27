using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cake.Npm.Get
{
    class NpmGetSettings : NpmSettings
    {
        public NpmGetSettings() : base("get")
        {
            RedirectStandardOutput = true;
        }
        public string Key { get; set; }

        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);
            args.Append(Key);
        }
    }
}
