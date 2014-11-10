$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
$version = [System.Reflection.Assembly]::LoadFile("$root\FluentBootstrap\FluentBootstrap\bin\Release\FluentBootstrap.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)
& NuGet.exe pack $root\FluentBootstrap\FluentBootstrap\FluentBootstrap.csproj -Version $versionStr