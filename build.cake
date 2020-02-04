var target = Argument("target", "Default");
var nugetArtifactsPath = "./artifacts/NuGet";

Task("Restore")
    .Does(() => {
        DotNetCoreRestore("src");
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() => {
        DotNetCoreBuild("src",
        new DotNetCoreBuildSettings 
        {
            NoRestore = true
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() => {
        DotNetCoreTest("src",
        new DotNetCoreTestSettings 
        {
            NoRestore = true,
            NoBuild = true
        });
    });

Task("Package")
    .IsDependentOn("Test")
    .Does(() => {
        DotNetCorePack("src",
        new DotNetCorePackSettings 
        {
            NoRestore = true,
            NoBuild = true,
            OutputDirectory = nugetArtifactsPath
        });
    });

Task("Publish")
    .IsDependentOn("Package")
    .WithCriteria(TFBuild.IsRunningOnAzurePipelinesHosted)
    .Does(() => {
        TFBuild.Commands.UploadArtifactDirectory(
            nugetArtifactsPath,
            "NuGet"
        );
    });

Task("Default")
    .IsDependentOn("Publish");

RunTarget(target);