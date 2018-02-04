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
# Rebuild-Micro
# 
# Rebuilds the test project only.
# 
# Author:       Emzi0767
# Version:      2018-02-03 18:18
# 
# Arguments: 
#  .\rebuild-micro.ps1
# 
# Run as:
#  .\rebuild-micro.ps1

Set-Location "CopperWire.Test"
dotnet build -c Debug -f netcoreapp2.0
Set-Location ".."