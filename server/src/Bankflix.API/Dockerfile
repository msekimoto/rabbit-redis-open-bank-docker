FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV mongoConnection__server "mongodb://mongo:27017/bankflix"
ENV rabbitmq__uri "amqp://guest:guest@rabbitmq:5672/rabbitmq-bankflix"

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Bankflix.API/Bankflix.API.csproj", "src/Bankflix.API/"]
COPY ["src/Clientes.Infra.CrossCutting/Clientes.Infra.CrossCutting.csproj", "src/Clientes.Infra.CrossCutting/"]
COPY ["src/Clientes.Domain/Clientes.Domain.csproj", "src/Clientes.Domain/"]
COPY ["src/Core.Domain/Core.Domain.csproj", "src/Core.Domain/"]
COPY ["src/Clientes.Infra.Data.Mongo/Clientes.Infra.Data.Mongo.csproj", "src/Clientes.Infra.Data.Mongo/"]
COPY ["src/Clientes.CommandStack/Clientes.CommandStack.csproj", "src/Clientes.CommandStack/"]
COPY ["src/Clientes.Commands/Clientes.Commands.csproj", "src/Clientes.Commands/"]
COPY ["src/Agencia.Infra.CrossCutting/Agencia.Infra.CrossCutting.csproj", "src/Agencia.Infra.CrossCutting/"]
COPY ["src/Agencia.Infra.Data/Agencia.Infra.Data.Mongo.csproj", "src/Agencia.Infra.Data/"]
COPY ["src/Agencia.Domain/Agencia.Domain.csproj", "src/Agencia.Domain/"]
COPY ["src/Movimentacoes.Infra.CrossCutting/Movimentacoes.Infra.CrossCutting.csproj", "src/Movimentacoes.Infra.CrossCutting/"]
COPY ["src/Movimentacoes.CommandStack/Movimentacoes.CommandStack.csproj", "src/Movimentacoes.CommandStack/"]
COPY ["src/Movimentacoes.Commands/Movimentacoes.Commands.csproj", "src/Movimentacoes.Commands/"]
COPY ["src/Movimentacoes.Domain/Movimentacoes.Domain.csproj", "src/Movimentacoes.Domain/"]
COPY ["src/Movimentacoes.Infra.Data.Mongo/Movimentacoes.Infra.Data.Mongo.csproj", "src/Movimentacoes.Infra.Data.Mongo/"]
RUN dotnet restore "src/Bankflix.API/Bankflix.API.csproj"
COPY . .
WORKDIR "/src/src/Bankflix.API"
RUN dotnet build "Bankflix.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bankflix.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bankflix.API.dll"]