#!/usr/bin/env pwsh

$env:KEKIRI_OUTPUT='console,files'

dotnet test src/TestRunner/NUnit/Kekiri.Examples.NUnit
dotnet test src/TestRunner/Xunit/Kekiri.Examples.NUnit.ServiceProvider
dotnet test src/TestRunner/Xunit/Kekiri.Examples.NUnit.ServiceProvider.Startup
dotnet test src/TestRunner/Xunit/Kekiri.Examples.Xunit
dotnet test src/TestRunner/Xunit/Kekiri.Examples.Xunit.ServiceProvider
dotnet test src/TestRunner/Xunit/Kekiri.Examples.Xunit.ServiceProvider.Startup
