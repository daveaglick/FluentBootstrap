param($installPath, $toolsPath, $package, $project)

# Checking if Path exists because the websites don't have a project file
if ([System.IO.File]::Exists($project.FullName))
{
	# Need to load MSBuild assembly if it's not loaded yet.
	Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

	# Grab the loaded MSBuild project for the project
	# Normalize project path before calling GetLoadedProjects as it performs a string based match
	$projectFullPath = [System.IO.Path]::GetFullPath($project.FullName) 
	$msbuildProject = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($projectFullPath) | Select-Object -First 1

	# Make the path to the targets file relative.
	$targetsFilePathToAdd = [System.IO.Path]::Combine($toolsPath, $package.Id + '.targets')
	$targetUri = new-object Uri($targetsFilePathToAdd, [System.UriKind]::Absolute)
	$projectUri = new-object Uri($project.FullName, [System.UriKind]::Absolute)
	$relativePath = [System.Uri]::UnescapeDataString($projectUri.MakeRelativeUri($targetUri).ToString()).Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)

	# Add the import with a condition, to allow the project to load without the targets present.
	$import = $msbuildProject.Xml.AddImport($relativePath)
	$import.Condition = "Exists('$relativePath')"

	# Add a target to fail the build when our targets are not imported
    $target = $msbuildProject.Xml.AddTarget("EnsureApplicationInsightsImported")
    $target.BeforeTargets = "BeforeBuild"
	$target.Condition = "'`$(ApplicationInsightsImported)' == ''"

    # if the targets don't exist at the time the target runs, package restore didn't run
    $errorTask = $target.AddTask("Error")
    $errorTask.Condition = "!Exists('$relativePath')"
    $errorTask.SetParameter("Text", "This project references NuGet package(s) that are missing on this computer. Enable NuGet Package Restore to download them.  For more information, see http://go.microsoft.com/fwlink/?LinkID=317567.")

    # if the targets exist at the time the target runs, package restore ran but the build didn't import the targets.
    $errorTask = $target.AddTask("Error")
    $errorTask.Condition = "Exists('$relativePath')"
    $errorTask.SetParameter("Text", "The build restored NuGet packages. Build the project again to include these packages in the build. For more information, see http://go.microsoft.com/fwlink/?LinkID=317567.")

	$project.Save()
}
