namespace Cake.Npm.Gulp
{
    public static class GulpRunnerExtensions
    {
        //[CakeMethodAlias]
        //public static void NpmInstall(this ICakeContext context, IDictionary<string, string> arguments)
        //{
        //    if (context.Environment.IsUnix()) throw new NotSupportedException("only supported on windows");
        //    RunNpmCommand(context, "install", ToArgumentString(arguments, pair => $"--{pair.Key} {pair.Value}"));
        //}

        //[CakeMethodAlias]
        //public static void NpmInstall(this ICakeContext context)
        //{
        //    NpmInstall(context, null);
        //}

        //[CakeMethodAlias]
        //public static void Npm(this ICakeContext context, string command, IDictionary<string, string> arguments)
        //{
        //    if(context.Environment.IsUnix()) throw new NotSupportedException("only supported on windows");
        //    RunNpmCommand(context, command, ToArgumentString(arguments, pair => $"--{pair.Key} {pair.Value}"));
        //}

        //[CakeMethodAlias]
        //public static void Npm(this ICakeContext context, string command)
        //{
        //    Npm(context, command, null);
        //}

        //private static string ToArgumentString(IDictionary<string, string> arguments,
        //    Func<KeyValuePair<string, string>, string> stringify)
        //{
        //    if (arguments == null || !arguments.Any()) return string.Empty;

        //    return
        //        arguments.Select(x => stringify(new KeyValuePair<string, string>(x.Key, x.Value)))
        //            .Aggregate((c, n) => $"{c} {n}");
        //}

        //private static void RunNpmCommand(ICakeContext context, string command, string arguments = null)
        //{
        //    var commandLine = $"npm {command} {arguments ?? string.Empty}";
        //    var process = context.ProcessRunner.Start("cmd", new ProcessSettings
        //    {
        //        Arguments = $"/c \"{commandLine}\"",
        //        WorkingDirectory = context.Environment.WorkingDirectory
        //    });
        //    process.WaitForExit();
        //    if(process.GetExitCode() != 0) throw new CakeException("Exit code indicates failure");
        //}

    }
}