FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
EXPOSE 80

COPY IJburgers.slnx IJburgers.slnx
COPY src/PostService/PostService.csproj src/PostService/PostService.csproj
COPY src/Contracts/Contracts.csproj src/Contracts/Contracts.csproj

RUN dotnet restore src/PostService/PostService.csproj

COPY . .
WORKDIR /src/src/PostService
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PostService.dll"]