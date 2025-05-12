# Imagen base para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Etapa de build
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src

# Copiar solo el proyecto y restaurar dependencias
COPY ["Pokedex-Api.csproj", "./"]
RUN dotnet restore "Pokedex-Api.csproj"

# Copiar el resto del código
COPY . .

# Compilar el proyecto
RUN dotnet build "Pokedex-Api.csproj" -c $configuration -o /app/build

# Etapa de publicación
FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Pokedex-Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Etapa final: imagen liviana para ejecución
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Pokedex-Api.dll"]
