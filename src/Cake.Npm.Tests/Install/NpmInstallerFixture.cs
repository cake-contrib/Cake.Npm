namespace Cake.Npm.Tests.Pack
{
    using Npm.Install;

    internal sealed class NpmInstallerFixture : NpmFixture<NpmInstallSettings>
    {
        public NpmInstallerFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new NpmInstaller(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.Install(Settings);
        }
    }
}
