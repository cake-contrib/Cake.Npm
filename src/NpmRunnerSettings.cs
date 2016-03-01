using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Npm
{
    /// <summary>
    /// Npm runner settings
    /// </summary>
    public class NpmRunnerSettings : ToolSettings
    {
        /// <summary>
        /// Applies the --force parameter
        /// </summary>
        public bool Force { get; set; }

        internal void Evaluate(ProcessArgumentBuilder args)
        {
            EvaluateCore(args);
            if (Force) args.Append("--force");
        }

        /// <summary>
        /// evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected virtual void EvaluateCore(ProcessArgumentBuilder args)
        {
            
        }
    }
}