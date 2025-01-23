namespace Cake.Npm.Tests.Set;

using Cake.Npm.Set;

internal sealed class NpmSetToolFixture : NpmFixture<NpmSetSettings>
{
    public NpmSetToolFixture()
    {
    }

    protected override void RunTool()
    {
        var tool = new NpmSetTool(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Set(Settings);
    }
}
