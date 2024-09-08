FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Posts.Migrator/Posts.Migrator.csproj", "Posts.Migrator/"]
COPY ["Posts.Interfaces/Posts.Interfaces.csproj", "Posts.Interfaces/"]
COPY ["Posts.Repositories/Posts.Repositories.csproj", "Posts.Repositories/"]
RUN dotnet restore "Posts.Migrator/Posts.Migrator.csproj"
COPY . .
WORKDIR "/src/Posts.Migrator"
RUN dotnet build "Posts.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Posts.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Posts.Migrator.dll"]
