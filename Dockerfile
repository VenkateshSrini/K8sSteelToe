#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/k8sConfigs.csproj", "src/"]
RUN dotnet restore "src/k8sConfigs.csproj"
COPY . .
WORKDIR "/src/src"
RUN dotnet build "k8sConfigs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "k8sConfigs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "k8sConfigs.dll"]