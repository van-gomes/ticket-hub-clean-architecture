#!/bin/bash

echo "Listing project references for all projects in the backend..."

IFS=$'\n'

for csproj in $(find . -name "*.csproj" | sort); do
  echo ""
  echo "Project: $csproj"
  dotnet list "$csproj" reference
done
