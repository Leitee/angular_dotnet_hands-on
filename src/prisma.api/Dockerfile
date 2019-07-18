FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY *.sln ./
COPY Leonardo.Moreno.CORE/*.csproj ./Leonardo.Moreno.CORE/
COPY Prisma.Demo.MODEL/*.csproj ./Prisma.Demo.MODEL/
COPY Prisma.Demo.DATA/*.csproj ./Prisma.Demo.DATA/
COPY Prisma.Demo.BUSINESS/*.csproj ./Prisma.Demo.BUSINESS/
COPY Prisma.Demo.API/*.csproj ./Prisma.Demo.API/

RUN dotnet restore "Leonardo.Moreno.CORE/Leonardo.Moreno.CORE.csproj"
RUN dotnet restore "Prisma.Demo.API/Prisma.Demo.API.csproj"
COPY . .
WORKDIR /src
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Prisma.Demo.API.dll"]