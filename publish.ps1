$scriptDir = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent

cd $scriptDir

$version = $env:APPVEYOR_BUILD_VERSION

$packagePath = Join-Path $scriptDir "package.json"

$packageJson = ConvertFrom-Json (gc $packagePath -Raw -Encoding Ascii) 


if([string]::IsNullOrWhiteSpace($version)){
    $v = [Version]::Parse($packageJson.version)    
    $version = "$($v.Major).$($v.Minor).$($v.Build + 1)"
}

$packageJson.version = $version

$jsonText = ConvertTo-Json -InputObject $packageJson 

$jsonText | Out-File $packagePath -Encoding ascii

npm publish


