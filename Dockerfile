FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80

RUN apt-get update && \
    apt-get install -y --no-install-recommends \
        libgssapi-krb5-2 \
        krb5-locales && \
    rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["PozorDomStoreService.slnx", "."]

COPY ["PozorDomStoreService.Api/PozorDomStoreService.Api.csproj", "PozorDomStoreService.Api/"]
COPY ["PozorDomStoreService.Application/PozorDomStoreService.Application.csproj", "PozorDomStoreService.Application/"]
COPY ["PozorDomStoreService.Domain/PozorDomStoreService.Domain.csproj", "PozorDomStoreService.Domain/"]
COPY ["PozorDomStoreService.Infrastructure/PozorDomStoreService.Infrastructure.csproj", "PozorDomStoreService.Infrastructure/"]
COPY ["PozorDomStoreService.Persistence/PozorDomStoreService.Persistence.csproj", "PozorDomStoreService.Persistence/"]

RUN dotnet restore "PozorDomStoreService.slnx"

COPY . .

WORKDIR "/src/PozorDomStoreService.Api"
RUN dotnet build "../PozorDomStoreService.slnx" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PozorDomStoreService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PozorDomStoreService.Api.dll"]
