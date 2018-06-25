using Cake.Npm.Set;

namespace Cake.Npm.Tests.Set
{
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
}
