using Cake.Npm.AddUser;

namespace Cake.Npm.Tests.AddUser
{
    internal class NpmAddUserFixture : NpmFixture<NpmAddUserSettings>
    {
        public NpmAddUserFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new NpmAddUser(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.AddUser(Settings);
        }
    }
}
