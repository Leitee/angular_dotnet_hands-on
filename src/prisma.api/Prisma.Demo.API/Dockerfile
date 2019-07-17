FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Prisma.Demo.API/Prisma.Demo.API.csproj", "Prisma.Demo.API/"]
RUN dotnet restore "Prisma.Demo.API/Prisma.Demo.API.csproj"
COPY . .
WORKDIR "/src/Prisma.Demo.API"
RUN dotnet build "Prisma.Demo.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Prisma.Demo.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Prisma.Demo.API.dll"]