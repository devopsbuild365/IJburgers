FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
EXPOSE 80

COPY IJburgers.slnx IJburgers.slnx
COPY src/GatewayService/GatewayService.csproj src/GatewayService/GatewayService.csproj

RUN dotnet restore src/GatewayService/GatewayService.csproj

COPY . .
WORKDIR /src/src/GatewayService
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "GatewayService.dll"]