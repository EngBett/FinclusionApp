# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
RUN dotnet tool install -g dotnet-ef --version 5.0.13
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet ef --version
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ../ ./

# Run migrations
RUN dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
RUN dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
RUN dotnet ef migrations add InitialMigrations -c AppDbContext -o Data/Migrations

# Update database
RUN dotnet ef database update -c PersistedGrantDbContext
RUN dotnet ef database update -c ConfigurationDbContext
RUN dotnet ef database update -c AppDbContext
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "IdentityServer.dll"]