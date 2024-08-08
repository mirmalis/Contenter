FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Aper/Aper.csproj", "Aper/"]
COPY ["Aper.Api/Aper.Api.csproj", "Aper.Api/"]
WORKDIR /src/Aper.Api
RUN dotnet restore
WORKDIR /src
COPY Aper Aper
COPY Aper.Api Aper.Api
WORKDIR "/src/Aper.Api"
RUN dotnet publish "Aper.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0.6-jammy-arm64v8 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Aper.Api.dll"]
