FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish

COPY . .

RUN dotnet publish -c Debug -o /app --ignore-failed-sources

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

WORKDIR /app

COPY --from=publish /app .

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    libgdiplus \
    libc6-dev \
    && rm -rf /var/lib/apt/lists/*

RUN rm -rf Common

ENTRYPOINT ["dotnet", "API.dll"]
