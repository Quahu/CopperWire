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
# One-click rebuild
#
# Rebuilds all CopperWire components with default values.
#
# Author: Emzi0767
# Version: 2017-09-11 14:20
#
# Arguments: none
#
# Run as: just run it

# ------------ Defaults -----------

# Output path for bots binaries and documentation.
$target = "..\cw-artifacts"

# Version suffix. Default is none. General format is 5-digit number.
$suffix = ""

# Documentation build. Set either to empty string to skip documentation build.
$docs_path = ".\docs"
$docs_pkgname = "copperwire-docs"

# --------- Execute build ---------
& .\rebuild-all.ps1 -ArtifactLocation "$target" -VersionSuffix "$suffix" -Configuration "Release" -DocsPath "$docs_path" -DocsPackageName "$docs_pkgname" | Out-Host
if ($LastExitCode -ne 0)
{
    Write-Host "----------------------------------------------------------------"
    Write-Host "                          BUILD FAILED"
    Write-Host "----------------------------------------------------------------"
}

Write-Host "Press any key to continue..."
$x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
Exit $LastExitCode
