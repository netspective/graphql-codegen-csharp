#$ErrorActionPreference = "Stop"

$scriptDir = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent

cd $scriptDir

$nodeVersion = node -v
$npmVersion = npm -v
$yarnVersion = yarn -v

Write-Output "-------------------------------------------"
Write-Output "Node: $nodeVersion, Npm: $npmVersion, Yarn: $yarnVersion"
Write-Output "-------------------------------------------"
Write-Output "Build project"
try{
    $a = yarn install --non-interactive 
}
catch{
}
yarn build
Write-Output "-------------------------------------------"
Write-Output "Running Generator"

$schemaPath = Join-Path $scriptDir "samples/GitHub/input/GitHubSchema.json"
$outPath = Join-Path $scriptDir "samples/GitHub/output/OutTest/GitHubSchema.cs"
$queryPath = Join-Path  $scriptDir "samples/GitHub/input/*.graphql"
$templatePath = Join-Path $scriptDir "dist"

Write-Output "Schema Path:   $schemaPath"
Write-Output "Output Path:   $outPath"
Write-Output "Query Path:    $queryPath"
Write-Output "Template Path: $templatePath"

try{
    Write-Output "yarn gql-gen --schema $schemaPath --template $templatePath --out $outPath $queryPath --non-interactive"

    $a = yarn gql-gen --schema $schemaPath --template $templatePath --out $outPath $queryPath --non-interactive 
}
catch{
}

Write-Output "-------------------------------------------"