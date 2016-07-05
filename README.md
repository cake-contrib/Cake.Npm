# cake-npm

## Usage

```c#
    #addin "Cake.Npm"

    Task("Npm")
        .Does(() =>
        {
            // npm install gulp -g
            Npm.Install(settings => settings.Package("gulp").Globally());

            // npm install gulp
            Npm.Install(settings => settings.Package("gulp"));

            // npm install gulp https://path.co/package/v0.1
            Npm.Install(settings => settings.Package("https://path.co/package/v0.1"));

            // npm install gulp@">3.9 && < 4.0"
            Npm.Install(settings => settings.Package("gulp", ">3.9 && <4.0"));

            // npm install @myorg/gulp@">3.9 && < 4.0"
            Npm.Install(settings => settings.Package("gulp", ">3.9 && <4.0", "myorg"));

            // npm install --production
            Npm.Install(settings => settings.ForProduction());
        });

    Task("Npm-FromPath")
        .Does(() =>
        {
            // Npm.FromPath(DirectoryPath).

            // npm install gulp -g (from path ./wwwroot)
            Npm.FromPath("./wwwroot").Install(settings => settings.Package("gulp").Globally());

            // npm install gulp (from parent path)
            Npm.FromPath("../").Install(settings => settings.Package("gulp"));
        });

    Task("Npm-LogLevel")
        .Does(() =>
        {
            // will adapt the Cake Verbosity level to npm
            // * Quiet -> Silent
            // * Minimal -> Warn
            // * Verbose -> Info
            // * Diagnostic -> Verbose
            Npm.Install(settings => settings.Package("gulp"));
            // npm install gulp --silent
            Npm.WithLogLevel(NpmLogLevel.Silent).Install(settings => settings.Package("gulp"));

            // npm install gulp --warn
            Npm.WithLogLevel(NpmLogLevel.Warn).Install(settings => settings.Package("gulp"));

            // npm install gulp --loglevel info
            Npm.WithLogLevel(NpmLogLevel.Info).Install(settings => settings.Package("gulp"));

            // npm install gulp --loglevel verbose
            Npm.WithLogLevel(NpmLogLevel.Verbose).Install(settings => settings.Package("gulp"));

            // npm install gulp --loglevel silly
            Npm.WithLogLevel(NpmLogLevel.Silly).Install(settings => settings.Package("gulp"));

        });
```

## Scope

Cake.Npm currently supports the following npm commands:

* ```npm install```
* ```npm run``` (contributed by @agc93)

My primary goal for the project is to support the build workflow I need as a .NET developer, additional features have been contributed

## Documentation

Thanks to the cakebuild.net site, documentation can be found [here](http://cakebuild.net/api/cake.npm/)

## Tests

Cake.Npm is covered by a set of unit tests contributed by @nengberg

## I cant do _insert-command-here_

If you have feature requests please submit them as issues, or better yet as pull requests :)
