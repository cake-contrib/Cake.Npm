using System;

namespace Cake.Npm
{
    /// <summary>
    /// Npm Runner command interface
    /// </summary>
    public interface INpmRunnerCommands
    {
        /// <summary>
        /// execute 'npm install' with options
        /// </summary>
        /// <param name="configure">options when running 'npm install'</param>
        INpmRunnerCommands Install(Action<NpmInstallSettings> configure = null);

        /// <summary>
        /// execute 'npm run'/'npm run-script' with arguments
        /// </summary>
        /// <param name="scriptName">name of the </param>
        /// <param name="configure"></param>
        INpmRunnerCommands RunScript(string scriptName, Action<NpmRunScriptSettings> configure = null);
    }
}