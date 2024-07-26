# FROM mcr.microsoft.com/dotnet/aspnet:8.0.6-jammy-arm64v8 AS base
# FROM mcr.microsoft.com/dotnet/sdk:8.0.6-jammy-arm64v8 AS build
# FROM mcr.microsoft.com/dotnet/sdk:8.0.302-1-jammy-arm64v8 as build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Aper/Aper.csproj", "Aper/"]
COPY ["Aper.Api/Aper.Api.csproj", "Aper.Api/"]
COPY ["Aper.Api.Youtube/Aper.Api.Youtube.csproj", "Aper.Api.Youtube/"]
WORKDIR /src/Aper.Api
RUN dotnet restore
WORKDIR /src
COPY Aper Aper
COPY Aper.Api Aper.Api
COPY Aper.Api.Youtube Aper.Api.Youtube
WORKDIR "/src/Aper.Api"
RUN dotnet publish "Aper.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0.6-jammy-arm64v8 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Aper.Api.dll"]
