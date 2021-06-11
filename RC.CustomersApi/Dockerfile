FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["RC.CustomersApi/RC.CustomersApi.csproj", "RC.CustomersApi/"]
RUN dotnet restore "RC.CustomersApi/RC.CustomersApi.csproj"
COPY . .
WORKDIR "/src/RC.CustomersApi"
RUN dotnet build "RC.CustomersApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RC.CustomersApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RC.CustomersApi.dll"]