#!/bin/bash

echo "Creating solution TicketHub..."
dotnet new sln -n TicketHub

echo "Creating main projects..."
dotnet new classlib -n TicketHub.Domain
dotnet new classlib -n TicketHub.Application
dotnet new classlib -n TicketHub.Infrastructure
dotnet new webapi    -n TicketHub.WebAPI
dotnet new classlib -n TicketHub.Documentation

echo "Creating test projects..."
mkdir -p tests
cd tests
dotnet new xunit -n TicketHub.UnitTests
dotnet new xunit -n TicketHub.IntegrationTests
cd ..

echo "Adding all projects to the solution..."
dotnet sln TicketHub.sln add \
  TicketHub.Domain \
  TicketHub.Application \
  TicketHub.Infrastructure \
  TicketHub.WebAPI \
  TicketHub.Documentation \
  tests/TicketHub.UnitTests \
  tests/TicketHub.IntegrationTests

echo "Adding project references..."
dotnet add TicketHub.Application/TicketHub.Application.csproj reference TicketHub.Domain/TicketHub.Domain.csproj

dotnet add TicketHub.Infrastructure/TicketHub.Infrastructure.csproj reference TicketHub.Application/TicketHub.Application.csproj
dotnet add TicketHub.Infrastructure/TicketHub.Infrastructure.csproj reference TicketHub.Domain/TicketHub.Domain.csproj

dotnet add TicketHub.WebAPI/TicketHub.WebAPI.csproj reference TicketHub.Application/TicketHub.Application.csproj
dotnet add TicketHub.WebAPI/TicketHub.WebAPI.csproj reference TicketHub.Infrastructure/TicketHub.Infrastructure.csproj

dotnet add TicketHub.Documentation/TicketHub.Documentation.csproj reference TicketHub.WebAPI/TicketHub.WebAPI.csproj

dotnet add tests/TicketHub.UnitTests/TicketHub.UnitTests.csproj reference TicketHub.Domain/TicketHub.Domain.csproj
dotnet add tests/TicketHub.UnitTests/TicketHub.UnitTests.csproj reference TicketHub.Application/TicketHub.Application.csproj

dotnet add tests/TicketHub.IntegrationTests/TicketHub.IntegrationTests.csproj reference TicketHub.WebAPI/TicketHub.WebAPI.csproj

echo "Backend setup complete!"