#load nuget:?package=Cake.Recipe&version=1.0.0

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./src",
    title: "Cake.Npm",
    repositoryOwner: "cake-contrib",
    repositoryName: "Cake.Npm",
    appVeyorAccountName: "cakecontrib",
    shouldRunDupFinder: false,
    shouldRunCodecov: false,
    shouldRunGitVersion: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(
    context: Context,
    dupFinderExcludePattern: new string[] { BuildParameters.RootDirectoryPath + "/src/Cake.Npm.Tests/*.cs", BuildParameters.RootDirectoryPath + "/src/Cake.Npm*/**/*.AssemblyInfo.cs" },
    testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[Shouldly]*",
    testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
    testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.RunDotNetCore();
