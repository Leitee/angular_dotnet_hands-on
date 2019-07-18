FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Prisma.Demo.API/Prisma.Demo.API.csproj", "Prisma.Demo.API/"]
COPY ["Leonardo.Moreno.CORE/Leonardo.Moreno.CORE.csproj", "Leonardo.Moreno.CORE/"]
COPY ["Prisma.Demo.BUSINESS/Prisma.Demo.BUSINESS.csproj", "Prisma.Demo.BUSINESS/"]
COPY ["Prisma.Demo.Model/Prisma.Demo.MODEL.csproj", "Prisma.Demo.Model/"]
COPY ["Prisma.Demo.DATA/Prisma.Demo.DATA.csproj", "Prisma.Demo.DATA/"]
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