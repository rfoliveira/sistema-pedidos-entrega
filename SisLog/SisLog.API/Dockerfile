# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SisLog.API/SisLog.API.csproj", "SisLog.API/"]
RUN dotnet restore "./SisLog.API/SisLog.API.csproj"
COPY . .
WORKDIR "/src/SisLog.API"
RUN dotnet build "./SisLog.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SisLog.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-infra
#WORKDIR /src
#COPY ["SisLog.Infrastructure/SisLog.Infrastructure.csproj", "SisLog.Infrastructure/"]
#RUN dotnet restore "./SisLog.Infrastructure/SisLog.Infrastructure.csproj"
#COPY . .
#WORKDIR "/src/SisLog.Infrastructure"
#RUN dotnet build "./SisLog.Infrastructure.csproj" -c Release -o /app/publish/infra
#
#FROM build-infra AS migrations-build
#WORKDIR /app/publish/infra
#COPY --from=build-infra /app/publish/infra .
#ENTRYPOINT ["dotnet", "ef", "database", "update", "--project", "src/SisLog.Infrastructure/", "--verbose"]

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SisLog.API.dll"]