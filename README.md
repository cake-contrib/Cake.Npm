# cake-npm

## Usage

```c#
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

## Documentation

Thanks to the cakebuild.net site, documentation can be found [here](http://cakebuild.net/api/cake.npm/)

## Tests

Cake.Npm is covered by a set of unit tests contributed by @nengberg

## I cant do _insert-command-here_

If you have feature requests please submit them as issues, or better yet as pull requests :)
