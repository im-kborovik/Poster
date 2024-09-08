FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Posts.API/Posts.API.csproj", "Posts.API/"]
COPY ["Posts.Services/Posts.Services.csproj", "Posts.Services/"]
COPY ["Posts.Repositories/Posts.Repositories.csproj", "Posts.Repositories/"]
COPY ["Posts.Interfaces/Posts.Interfaces.csproj", "Posts.Interfaces/"]
RUN dotnet restore "Posts.API/Posts.API.csproj"
COPY . .
WORKDIR "/src/Posts.API"
RUN dotnet build "Posts.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Posts.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Posts.API.dll"]
