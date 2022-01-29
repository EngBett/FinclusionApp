# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
RUN dotnet tool install -g dotnet-ef --version 5.0.13
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet ef --version
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ../ ./
# Run Migrations
RUN dotnet ef migrations add InitMigrations -o=Data/Migrations
# Update database
# RUN dotnet ef database update
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "AccManagement.dll"]