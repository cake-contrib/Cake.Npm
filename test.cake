// #addin "Cake.Npm"
#r "bin/debug/cake.npm.dll"

var target = Argument("target", "Default");

Task("Default")
    .Does(() => 
    {
        Information("started");
        
        Npm.Install(settings => settings.Package("gulp").Globally());
        Gulp.Global.Execute();
        
        Information("finished");
    });
    
//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);    