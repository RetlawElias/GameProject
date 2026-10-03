#!/bin/bash
# Liest die MonoGame-Version aus der .csproj und installiert den passenden Mac-Editor
VERSION=$(grep -o 'MonoGame.Framework.DesktopGL" Version="[^"]*' *.csproj | sed 's/.*Version="//')
echo "MonoGame-Version: $VERSION"

dotnet tool restore
dotnet tool install -g dotnet-mgcb-editor-mac --version "$VERSION" \
  || dotnet tool update -g dotnet-mgcb-editor-mac --version "$VERSION"