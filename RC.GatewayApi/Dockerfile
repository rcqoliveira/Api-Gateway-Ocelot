FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["RC.GatewayApi/RC.GatewayApi.csproj", "RC.GatewayApi/"]
RUN dotnet restore "RC.GatewayApi/RC.GatewayApi.csproj"
COPY . .
WORKDIR "/src/RC.GatewayApi"
RUN dotnet build "RC.GatewayApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RC.GatewayApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RC.GatewayApi.dll"]