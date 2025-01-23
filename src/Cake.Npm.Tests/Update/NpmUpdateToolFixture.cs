namespace Cake.Npm.Tests.Update;

using Cake.Npm.Update;

internal sealed class NpmUpdateToolFixture : NpmFixture<NpmUpdateSettings>
{
    public NpmUpdateToolFixture()
    {
    }

    protected override void RunTool()
    {
        var tool = new NpmUpdateTool(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Update(Settings);
    }
}
