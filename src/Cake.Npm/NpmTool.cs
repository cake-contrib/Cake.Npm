namespace Cake.Npm
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Core.Diagnostics;
    using Core.IO;
    using Core.Tooling;

    /// <summary>
    /// Base class for all npm tools.
    /// </summary>
    /// <typeparam name="TSettings">The settings type.</typeparam>
    public abstract class NpmTool<TSettings>: Tool<TSettings>
        where TSettings : NpmSettings
    {
        private readonly ICakeLog _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="NpmTool{TSettings}"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        protected NpmTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log) : base(fileSystem, environment, processRunner, tools)
        {
            _log = log;
        }

        /// <summary>
        /// Cake log instance.
        /// </summary>
        public ICakeLog CakeLog
        {
            get
            {
                return _log;
            }
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected sealed override string GetToolName()
        {
            return "Npm";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected sealed override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "npm.cmd", "npm" };
        }

        /// <summary>
        /// Runs npm.
        /// </summary>
        /// <param name="settings">The settings.</param>
        protected void RunCore(TSettings settings)
        {
            RunCore(settings, null, null);
        }

        /// <summary>
        /// Runs npm.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="processSettings">The process settings. <c>null</c> for default settings.</param>
        /// <param name="postAction">Action which should be executed after running npm. <c>null</c> for no action.</param>
        protected void RunCore(TSettings settings, ProcessSettings processSettings, Action<IProcess> postAction)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (!settings.CakeVerbosityLevel.HasValue)
            {
                settings.CakeVerbosityLevel = CakeLog.Verbosity;
            }

            var args = GetArguments(settings);
            Run(settings, args, processSettings, postAction);
        }

        /// <summary>
        /// Builds the arguments for npm.
        /// </summary>
        /// <param name="settings">Settings used for building the arguments.</param>
        /// <returns>Argument builder containing the arguments based on <paramref name="settings"/>.</returns>
        protected ProcessArgumentBuilder GetArguments(TSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            settings.Evaluate(args);

            CakeLog.Verbose("npm arguments: {0}", args.RenderSafe());

            return args;
        }
    }
}
