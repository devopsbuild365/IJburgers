FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
EXPOSE 80

COPY IJburgers.slnx IJburgers.slnx
COPY src/SearchService/SearchService.csproj src/SearchService/SearchService.csproj
COPY src/Contracts/Contracts.csproj src/Contracts/Contracts.csproj

RUN dotnet restore src/SearchService/SearchService.csproj

COPY . .
WORKDIR /src/src/SearchService
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SearchService.dll"]