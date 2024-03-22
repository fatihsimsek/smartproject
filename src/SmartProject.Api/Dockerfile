FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY ["src/", "/src/"]

FROM build AS publish
WORKDIR "/src/SmartProject.Api"
RUN dotnet restore "SmartProject.Api.csproj" && \
    dotnet publish "SmartProject.Api.csproj" --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS https://*:5001
ENV ASPNETCORE_ENVIRONMENT Development
EXPOSE 5001
ENTRYPOINT ["dotnet", "SmartProject.Api.dll"]
