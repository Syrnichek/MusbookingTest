FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5002
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EquipmentService/EquipmentService.API/EquipmentService.API.csproj", "EquipmentService/EquipmentService.API/"]
COPY ["EquipmentService/EquipmentService.Application/EquipmentService.Application.csproj", "EquipmentService/EquipmentService.Application/"]
COPY ["EquipmentService/EquipmentService.Core/EquipmentService.Core.csproj", "EquipmentService/EquipmentService.Core/"]
COPY ["EquipmentService/EquipmentService.Infrastructure/EquipmentService.Infrastructure.csproj", "EquipmentService/EquipmentService.Infrastructure/"]
RUN dotnet restore "EquipmentService/EquipmentService.API/EquipmentService.API.csproj"
COPY . .
WORKDIR "/src/EquipmentService/EquipmentService.API"
RUN dotnet build "EquipmentService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EquipmentService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EquipmentService.API.dll"]
