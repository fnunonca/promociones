#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Promociones.Services.WebApi/Promociones.Services.WebApi.csproj", "Promociones.Services.WebApi/"]
COPY ["Promociones.Infrastructure.Data/Promociones.Infrastructure.Data.csproj", "Promociones.Infrastructure.Data/"]
COPY ["Promociones.Transversal.Common/Promociones.Transversal.Common.csproj", "Promociones.Transversal.Common/"]
COPY ["Promociones.Domain.Core/Promociones.Domain.Core.csproj", "Promociones.Domain.Core/"]
COPY ["Promociones.Infrastructure.Interface/Promociones.Infrastructure.Interface.csproj", "Promociones.Infrastructure.Interface/"]
COPY ["Promociones.Domain.Entity/Promociones.Domain.Entity.csproj", "Promociones.Domain.Entity/"]
COPY ["Promociones.Domain.Interface/Promociones.Domain.Interface.csproj", "Promociones.Domain.Interface/"]
COPY ["Promociones.Application.DTO/Promociones.Application.DTO.csproj", "Promociones.Application.DTO/"]
COPY ["Promociones.Transversal.Logging/Promociones.Transversal.Logging.csproj", "Promociones.Transversal.Logging/"]
COPY ["Promociones.Infrastructure.Repository/Promociones.Infrastructure.Repository.csproj", "Promociones.Infrastructure.Repository/"]
COPY ["Promociones.Transversal.Mapper/Promociones.Transversal.Mapper.csproj", "Promociones.Transversal.Mapper/"]
COPY ["Promociones.Application.Interface/Promociones.Application.Interface.csproj", "Promociones.Application.Interface/"]
COPY ["Promociones.Application.Main/Promociones.Application.Main.csproj", "Promociones.Application.Main/"]
RUN dotnet restore "Promociones.Services.WebApi/Promociones.Services.WebApi.csproj"
COPY . .
WORKDIR "/src/Promociones.Services.WebApi"
RUN dotnet build "Promociones.Services.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Promociones.Services.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Promociones.Services.WebApi.dll"]