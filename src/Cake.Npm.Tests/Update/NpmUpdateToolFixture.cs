using Cake.Npm.Update;

namespace Cake.Npm.Tests.Update
{
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
}
