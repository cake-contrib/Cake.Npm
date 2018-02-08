# Build Script

To use the Cake Npm addin in your Cake file simply import it. Then define a task.


:::{.alert .alert-info}
The addin requires npm to already be installed.
You can use the [ChocolateyInstall](https://cakebuild.net/api/Cake.Common.Tools.Chocolatey/ChocolateyAliases/B1E32DCB) or the
[Cake.Chocolatey.Module](https://github.com/cake-contrib/Cake.Chocolatey.Module) to install npm from your Cake build script.
:::

```csharp
#addin "Cake.Npm"

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

        settings.LogLevel = NpmLogLevel.Info;
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
```
