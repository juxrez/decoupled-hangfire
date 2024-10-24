#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["JobProcessor/JobProcessor.csproj", "JobProcessor/"]
COPY ["HangfirePoc.Shared/HangfirePoc.Shared.csproj", "HangfirePoc.Shared/"]
RUN dotnet restore "./JobProcessor/./JobProcessor.csproj"
COPY . .
WORKDIR "/src/JobProcessor"
RUN dotnet build "./JobProcessor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./JobProcessor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobProcessor.dll"]