#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FIAP.IFOOD.PEDIDO.MICROSERVICO/FIAP.IFOOD.PEDIDO.MICROSERVICO.csproj", "FIAP.IFOOD.PEDIDO.MICROSERVICO/"]
COPY ["FIAP.IFOOD.PEDIDOS.DOMAIN/FIAP.IFOOD.PEDIDOS.DOMAIN.csproj", "FIAP.IFOOD.PEDIDOS.DOMAIN/"]
COPY ["FIAP.IFOOD.PEDIDO.SERVICE/FIAP.IFOOD.PEDIDO.SERVICE.csproj", "FIAP.IFOOD.PEDIDO.SERVICE/"]
COPY ["FIAP.IFOOD.PEDIDOS.REPOSITORY/FIAP.IFOOD.PEDIDOS.REPOSITORY.csproj", "FIAP.IFOOD.PEDIDOS.REPOSITORY/"]
RUN dotnet restore "FIAP.IFOOD.PEDIDO.MICROSERVICO/FIAP.IFOOD.PEDIDO.MICROSERVICO.csproj"
COPY . .
WORKDIR "/src/FIAP.IFOOD.PEDIDO.MICROSERVICO"
RUN dotnet build "FIAP.IFOOD.PEDIDO.MICROSERVICO.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FIAP.IFOOD.PEDIDO.MICROSERVICO.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FIAP.IFOOD.PEDIDO.MICROSERVICO.dll"]