namespace Cake.Npm.Set
{
    using Cake.Core;
    using Cake.Core.IO;
    using System;

    /// <summary>
    /// Contains settings used by <see cref="NpmSetTool"/>.
    /// </summary>
    public class NpmSetSettings : NpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmSetSettings"/> class.
        /// </summary>
        public NpmSetSettings()
            : base("set")
        {
        }

        /// <summary>
        /// The config key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The config value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Determines whether to set the config key value globally
        /// </summary>
        public bool Global { get; set; }

        /// <inheritdoc />
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (string.IsNullOrWhiteSpace(Key))
            {
                throw new ArgumentNullException(nameof(Key));
            }

            if (string.IsNullOrWhiteSpace(Value))
            {
                throw new ArgumentNullException(nameof(Value));
            }

            args.Append($"\"{Key}\"=\"{Value}\"");

            if (Global)
            {
                args.Append("-g");
            }

            base.EvaluateCore(args);
        }
    }
}
