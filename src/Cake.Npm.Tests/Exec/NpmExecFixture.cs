using Cake.Npm.Exec;

namespace Cake.Npm.Tests.Exec;

internal sealed class NpmExecFixture : NpmFixture<NpmExecSettings>
{
    protected override void RunTool()
    {
        var tool = new NpmExecRunner(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Exec(Settings);
    }
}