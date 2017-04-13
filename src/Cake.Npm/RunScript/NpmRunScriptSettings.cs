namespace Cake.Npm.RunScript
{
    using Core;
    using Core.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Contains settings used by <see cref="NpmScriptRunner"/>.
    /// </summary>
    public class NpmRunScriptSettings : NpmSettings
    {
        private readonly List<string> _arguments = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="NpmRunScriptSettings"/> class.
        /// </summary>
        public NpmRunScriptSettings()
            : base("run-script")
        {
        }

        /// <summary>
        /// Name of the script to execute as defined in package.json.
        /// </summary>
        public string ScriptName { get; set; }

        /// <summary>
        /// Arguments to pass to the target script.
        /// </summary>
        public IList<string> Arguments
        {
            get
            {
                return _arguments;
            }
        }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (string.IsNullOrEmpty(ScriptName))
            {
                throw new ArgumentNullException(nameof(ScriptName), "Must provide script name.");
            }

            base.EvaluateCore(args);

            args.AppendQuoted(ScriptName);

            if (Arguments.Any())
            {
                args.Append("--");
                foreach (var arg in Arguments)
                {
                    args.Append(arg);
                }
            }
        }
    }
}
