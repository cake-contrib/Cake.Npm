namespace Cake.Npm.Tests.Ci;

using Cake.Npm.Ci;

internal sealed class NpmCiToolFixture : NpmFixture<NpmCiSettings>
{
    public NpmCiToolFixture()
    {
    }

    protected override void RunTool()
    {
        var tool = new NpmCiTool(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Install(Settings);
    }
}
