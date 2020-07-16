#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Dominos.Services.DbWrite/Dominos.Services.DbWrite.csproj", "Dominos.Services.DbWrite/"]
COPY ["Dominos.Core/Dominos.Core.csproj", "Dominos.Core/"]
RUN dotnet restore "Dominos.Services.DbWrite/Dominos.Services.DbWrite.csproj"
COPY . .
WORKDIR "/src/Dominos.Services.DbWrite"
RUN dotnet build "Dominos.Services.DbWrite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dominos.Services.DbWrite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dominos.Services.DbWrite.dll"]
