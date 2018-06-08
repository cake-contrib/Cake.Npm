using Cake.Core;
using Cake.Core.IO;

namespace Cake.Npm.Update
{
    /// <summary>
    /// Contains settings used by <see cref="NpmUpdateTool"/>.
    /// </summary>
    public class NpmUpdateSettings : NpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmUpdateSettings"/> class.
        /// </summary>
        public NpmUpdateSettings()
            : base("update")
        {
        }

        /// <summary>
        /// Gets a value indicating whether to update globally installed packages.
        /// </summary>
        public bool Global { get; internal set; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            if (Global)
            {
                args.Append("-g");
            }
        }
    }
}
