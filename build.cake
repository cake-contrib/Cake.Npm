#tool "xunit.runner.console"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var solutionPath            = MakeAbsolute(File(Argument("solutionPath", "Cake.Npm.sln")));
var projectName             = Argument("projectName", "Cake.Npm");

var artifacts               = MakeAbsolute(Directory(Argument("artifactPath", "./artifacts")));
var testResultsPath         = MakeAbsolute(Directory(artifacts + "./test-results"));
var versionAssemblyInfo     = MakeAbsolute(File(Argument("versionAssemblyInfo", "./src/VersionAssemblyInfo.cs")));

SolutionParserResult solution        = null;
SolutionProject project              = null;
GitVersion versionInfo               = null;

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Setup(() => {
    CreateDirectory(artifacts);
    
    if(!FileExists(solutionPath)) throw new Exception(string.Format("Solution file not found - {0}", solutionPath.ToString()));
    solution = ParseSolution(solutionPath.ToString());
    project = solution.Projects.FirstOrDefault(x => x.Name == projectName);
    if(project == null || !FileExists(project.Path)) throw new Exception(string.Format("Project not found in solution - {0}", projectName));
});

Task("Clean")
    .Does(() =>
{
    CleanDirectory(artifacts);
    var binDirs = GetDirectories(solutionPath.GetDirectory() +@"\src\**\bin");
    var objDirs = GetDirectories(solutionPath.GetDirectory() +@"\src\**\obj");
    CleanDirectories(binDirs);
    CleanDirectories(objDirs);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solutionPath, new NuGetRestoreSettings());
});

Task("Update-Version-Info")
    .IsDependentOn("CreateVersionAssemblyInfo")
    .Does(() => 
{
        versionInfo = GitVersion(new GitVersionSettings {
            UpdateAssemblyInfo = true,
            UpdateAssemblyInfoFilePath = versionAssemblyInfo
        });

    if(versionInfo != null) {
        Information("Version: {0}", versionInfo.FullSemVer);
    } else {
        throw new Exception("Unable to determine version");
    }
});

Task("CreateVersionAssemblyInfo")
    .WithCriteria(() => !FileExists(versionAssemblyInfo))
    .Does(() =>
{
    Information("Creating version assembly info");
    CreateAssemblyInfo(versionAssemblyInfo, new AssemblyInfoSettings {
        Version = "0.0.0.1",
        FileVersion = "0.0.0.1",
        InformationalVersion = "",
    });
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .IsDependentOn("Update-Version-Info")
    .Does(() =>
{
    MSBuild(solutionPath, settings => settings
        .WithProperty("TreatWarningsAsErrors","true")
        .WithProperty("UseSharedCompilation", "false")
        .WithProperty("AutoParameterizationWebConfigConnectionStrings", "false")
        .SetVerbosity(Verbosity.Quiet)
        .SetConfiguration(configuration)
        .WithTarget("Rebuild")
    );
});

Task("Copy-Files")
    .IsDependentOn("Build")
    .Does(() => 
{
    CreateDirectory(artifacts + "/build");
    var files = GetFiles(project.Path.GetDirectory() +"/bin/" +configuration +"/" +project.Name +".*");
    CopyFiles(files, artifacts +"/build");
});

Task("Package")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore-NuGet-Packages")
    .IsDependentOn("Update-Version-Info")
    .Does(() =>
{
    CreateDirectory(Directory(artifacts +"/packages"));

    NuGetPack(project.Path, new NuGetPackSettings {
        Version = versionInfo.NuGetVersionV2,
        OutputDirectory = Directory(artifacts +"/packages"),
        Symbols = true,
        Properties = new Dictionary<string, string>() { { "Configuration", configuration } }
    });
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
/*
    CreateDirectory(testResultsPath);

    var settings = new XUnit2Settings {
        XmlReportV1 = true,
        NoAppDomain = true,
        OutputDirectory = testResultsPath,
    };
    settings.ExcludeTrait("Category", "Integration");
    
    XUnit2(testAssemblies, settings); */
});

Task("Update-AppVeyor-Build-Number")
    .IsDependentOn("Update-Version-Info")
    .WithCriteria(() => AppVeyor.IsRunningOnAppVeyor)
    .Does(() =>
{
    AppVeyor.UpdateBuildVersion(versionInfo.FullSemVer +" (Build: " +AppVeyor.Environment.Build.Number +")");
});

Task("Upload-AppVeyor-Artifacts")
    .IsDependentOn("Package")
    .WithCriteria(() => AppVeyor.IsRunningOnAppVeyor)
    .Does(() =>
{
    foreach(var nupkg in GetFiles(artifacts +"/packages/*.nupkg")) {
        AppVeyor.UploadArtifact(nupkg);
    }
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Update-Version-Info")
    .IsDependentOn("Update-AppVeyor-Build-Number")
    .IsDependentOn("Build")
    .IsDependentOn("Copy-Files")
    .IsDependentOn("Run-Unit-Tests")
    .IsDependentOn("Package")
    .IsDependentOn("Upload-AppVeyor-Artifacts")
    ;

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
