#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["dc-accounts/dc-accounts.csproj", "dc-accounts/"]
RUN dotnet restore "dc-accounts/dc-accounts.csproj"
COPY . .
WORKDIR "/src/dc-accounts"
RUN dotnet build "dc-accounts.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dc-accounts.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dc-accounts.dll"]