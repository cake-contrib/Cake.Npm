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
```

## Scope
At present the scope of the implementation of this Cake addin is to meet my own requirements, which are primarily to support a client side build process for a typical .NET based web application.  
This process would usual involve a design or creative team developing and maintaining client side assets (js, scss) for which they have a gulp based development and build workflow.

My goal to be to able to support this workflow as part of a complete solution build.

### I cant do <insert-function-here>
See above, the initial release supports only the most basic functionality I need, if you have feature requests please submit them as issues
