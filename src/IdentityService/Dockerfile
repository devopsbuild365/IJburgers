FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
EXPOSE 80

COPY IJburgers.slnx IJburgers.slnx
COPY src/IdentityService/IdentityService.csproj src/IdentityService/IdentityService.csproj

RUN dotnet restore src/IdentityService/IdentityService.csproj

COPY . .
WORKDIR /src/src/IdentityService
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IdentityService.dll"]