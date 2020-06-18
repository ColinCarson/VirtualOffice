#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ZoomLink/ZoomLink.csproj", "ZoomLink/"]
RUN dotnet restore "ZoomLink/ZoomLink.csproj"
COPY . .
WORKDIR "/src/ZoomLink"
RUN dotnet build "ZoomLink.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZoomLink.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZoomLink.dll"]