namespace Cake.Npm.Tests.Publish
{
    using Npm.Publish;

    internal sealed class NpmPublisherFixture : NpmFixture<NpmPublishSettings>
    {
        public NpmPublisherFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new NpmPublisher(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.Publish(Settings);
        }
    }
}
