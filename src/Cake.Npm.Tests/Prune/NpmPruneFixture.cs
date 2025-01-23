namespace Cake.Npm.Tests.Prune;

using Cake.Npm.Prune;

internal sealed class NpmPruneFixture : NpmFixture<NpmPruneSettings>
{
    protected override void RunTool()
    {
        var tool = new NpmPruneRunner(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Prune(Settings);
    }
}
