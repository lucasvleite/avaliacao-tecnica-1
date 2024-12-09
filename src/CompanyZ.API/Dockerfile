FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5020

ENV ASPNETCORE_URLS=http://+:5020

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/CompanyZ.API/CompanyZ.API.csproj", "src/CompanyZ.API/"]
RUN dotnet restore "src/CompanyZ.API/CompanyZ.API.csproj"
COPY . .
WORKDIR "/src/src/CompanyZ.API"
RUN dotnet build "CompanyZ.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "CompanyZ.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyZ.API.dll"]
