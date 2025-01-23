namespace Cake.Npm.Tests.RunScript;

using Npm.RunScript;

internal sealed class NpmRunScriptFixture : NpmFixture<NpmRunScriptSettings>
{
    public NpmRunScriptFixture()
    {
    }

    protected override void RunTool()
    {
        var tool = new NpmScriptRunner(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.RunScript(Settings);
    }
}
