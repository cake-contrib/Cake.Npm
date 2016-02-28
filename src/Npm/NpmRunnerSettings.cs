using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Npm.Npm
{
    public class NpmRunnerSettings : ToolSettings
    {
        public bool Force { get; set; }

        internal void Evaluate(ProcessArgumentBuilder args)
        {
            EvaluateCore(args);
            if (Force) args.Append("--force");
        }

        protected virtual void EvaluateCore(ProcessArgumentBuilder args)
        {
            
        }
    }
}