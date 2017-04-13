#r "artifacts/build/Cake.Npm.dll"

var target = Argument("target", "Default");

Task("Example").Does(() => {
        var settings = new NpmInstallSettings();
        
        settings.Global = true;
        settings.Production = false;
        settings.LogLevel = NpmLogLevel.Verbose;

        settings.AddPackage("gulp");
        settings.AddPackage("left-pad");

        NpmInstall(settings);
});

Task("PackageJsonFromDirectory").Does(() => {
        var settings = new NpmInstallSettings();
        
        settings.LogLevel = NpmLogLevel.Info;gs
        
        settings.WorkingDirectory = "usage/";
        settings.Production = true;
        NpmInstall(settings);
});

Task("Default")
    .IsDependentOn("Example")
    .IsDependentOn("PackageJsonFromDirectory");
        
//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);    