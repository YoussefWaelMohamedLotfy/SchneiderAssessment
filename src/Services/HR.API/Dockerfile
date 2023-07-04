#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/Services/HR.API/HR.API.csproj", "src/Services/HR.API/"]
COPY ["src/Services/HR.Application/HR.Application.csproj", "src/Services/HR.Application/"]
COPY ["src/Shared/HR.Contracts/HR.Contracts.csproj", "src/Shared/HR.Contracts/"]
COPY ["src/Services/HR.Persistence/HR.Persistence.csproj", "src/Services/HR.Persistence/"]
COPY ["src/Services/HR.Domain/HR.Domain.csproj", "src/Services/HR.Domain/"]
RUN dotnet restore "src/Services/HR.API/HR.API.csproj"
COPY . .
WORKDIR "/src/src/Services/HR.API"
RUN dotnet build "HR.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HR.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HR.API.dll"]