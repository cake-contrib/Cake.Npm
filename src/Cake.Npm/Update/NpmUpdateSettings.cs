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

        /// <inheritdoc />
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
