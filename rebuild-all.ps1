#!/usr/bin/env pwsh
# 
# This file is a part of CopperWire project.
# 
# Copyright 2018 Emzi0767
# 
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# 
#   http:#www.apache.org/licenses/LICENSE-2.0
# 
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# 
# Rebuild-all
#
# Rebuilds the CopperWire project and its documentation, and places artifacts in specified directories.
# Not specifying documentation options will skip documentation build.
# 
# Author:       Emzi0767
# Version:      2017-09-11 14:20
#
# Arguments:
#   .\rebuild-docs.ps1 <output path> <version suffix> [path to docfx] [output path] [docs project path]
#
# Run as:
#   .\rebuild-lib.ps1 .\path\to\artifact\location version-suffix .\path\to\docfx\project .\path\to\output project-docs

param
(
    [parameter(Mandatory = $true)]
    [string] $ArtifactLocation,

    [parameter(Mandatory = $false)]
    [string] $VersionSuffix,
    
    [parameter(Mandatory = $false)]
    [string] $DocsPath,
    
    [parameter(Mandatory = $false)]
    [string] $DocsPackageName,

    [parameter(Mandatory = $true)]
    [string] $Configuration
)

# Check if configuration is valid
if ($Configuration -ne "Debug" -and $Configuration -ne "Release")
{
    Write-Host "Invalid configuration specified. Must be Release or Debug."
    Exit 1
}

# Check if we have a version prefix
if (-not $VersionSuffix)
{
    # Nope
    Write-Host "Building production packages"
}
else
{
    # Yup
    Write-Host "Building beta packages"
}

# Invoke the build script
& .\rebuild-lib.ps1 -artifactlocation "$ArtifactLocation" -versionsuffix "$VersionSuffix" -configuration "$Configuration" | Out-Host

# Check if it failed
if ($LastExitCode -ne 0)
{
    Write-Host "Build failed with code $LastExitCode"
    $host.SetShouldExit($LastExitCode)
    Exit $LastExitCode
}

# Check if we're building docs
if ($DocsPath -and $DocsPackageName)
{
    # Yup
    Write-Host "Building documentation"
    & .\rebuild-docs.ps1 -docspath "$DocsPath" -outputpath "$ArtifactLocation" -packagename "$DocsPackageName"
    
    # Check if it failed
    if ($LastExitCode -ne 0)
    {
        Write-Host "Documentation build failed with code $LastExitCode"
        $host.SetShouldExit($LastExitCode)
        Exit $LastExitCode
    }
}
else
{
    # Nope
    Write-Host "Not building documentation"
}
Exit 0
