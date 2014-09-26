param($installPath, $toolsPath, $package, $project)

# Checking if Path exists because the websites don't have a project file
if ([System.IO.File]::Exists($project.FullName))
{
  # Need to load MSBuild assembly if it's not loaded yet.
  Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

  # Grab the loaded MSBuild project for the project
  # Normalize project path before calling GetLoadedProjects as it performs a string based match
  $msbuildProject = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects([System.IO.Path]::GetFullPath($project.FullName)) | Select-Object -First 1

  # Find all the imports and targets added by this package.
  $itemsToRemove = @()

  # Allow many in case a past package was incorrectly uninstalled
  $itemsToRemove += $msbuildProject.Xml.Imports | Where-Object { $_.Project.EndsWith($package.Id + '.targets') }
  $itemsToRemove += $msbuildProject.Xml.Targets | Where-Object { $_.Name -eq "EnsureApplicationInsightsImported" }
  
  # Remove the elements and save the project
  if ($itemsToRemove -and $itemsToRemove.length)
  {
     foreach ($itemToRemove in $itemsToRemove)
     {
         $msbuildProject.Xml.RemoveChild($itemToRemove) | out-null
     }
     
     $project.Save()
  }
}