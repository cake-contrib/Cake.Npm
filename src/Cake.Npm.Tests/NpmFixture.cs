namespace Cake.Npm.Tests;

using Core.Diagnostics;
using Core.IO;
using Core.Tooling;
using Testing;
using Testing.Fixtures;

internal abstract class NpmFixture<TSettings> : NpmFixture<TSettings, ToolFixtureResult>
    where TSettings : ToolSettings, new()
{
    protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
    {
        return new ToolFixtureResult(path, process);
    }
}

internal abstract class NpmFixture<TSettings, TFixtureResult> : ToolFixture<TSettings, TFixtureResult>
    where TSettings : ToolSettings, new()
    where TFixtureResult : ToolFixtureResult
{
    private readonly ICakeLog _log = new FakeLog();

    protected NpmFixture()
        : base("npm.cmd")
    {
        _log.Verbosity = Verbosity.Normal;
    }

    protected ICakeLog Log
    {
        get
        {
            return _log;
        }
    }
}
