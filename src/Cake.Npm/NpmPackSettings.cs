using Cake.Core;
using Cake.Core.IO;

namespace Cake.Npm
{
    /// <summary>
    /// npm pack options
    /// </summary>
    public class NpmPackSettings : NpmRunnerSettings
    {
        /// <summary>
        /// 'npm pack' settings with target
        /// </summary>
        public NpmPackSettings(string target) : base("pack")
        {
            Target = target;
        }

        /// <summary>
        /// 'npm pack' settings
        /// </summary>
        public NpmPackSettings() : this(null)
        {
        }

        /// <summary>
        /// Installation target
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);
            if (!string.IsNullOrWhiteSpace(Target))
            {
                args.Append(Target);
            }
        }
    }
}
