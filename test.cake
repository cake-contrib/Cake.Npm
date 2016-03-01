#addin "Cake.Npm"

var target = Argument("target", "Default");

Task("Default").Does(() => Information("test"));

Task("Gulp")
    .Does(() => 
    {
        Information("started");
        
        Npm.Install(settings => settings.Package("gulp").Globally());
        Gulp.Global.Execute();
        
        Information("finished");
    });
    
Task("Npm")
    .Does(() => 
    {
        Information("running npm...");
    });
        
//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);    