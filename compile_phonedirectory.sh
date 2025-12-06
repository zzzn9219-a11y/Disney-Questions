#!/bin/bash
echo "Compiling Phone Directory..."
dotnet build challenge5.csproj -o ./bin
echo ""
echo "To run: dotnet ./bin/PhoneDirectory.dll"
echo "Make sure phonedirectory.csv is in this folder!"
