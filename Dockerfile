FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RatorServer/RatorServer.csproj", "RatorServer/"]
RUN dotnet restore "RatorServer/RatorServer.csproj"
COPY . .
WORKDIR "/src/RatorServer"
RUN dotnet build "RatorServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RatorServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RatorServer.dll"]
