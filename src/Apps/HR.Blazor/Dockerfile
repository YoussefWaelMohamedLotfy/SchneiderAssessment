#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/Apps/HR.Blazor/HR.Blazor.csproj", "src/Apps/HR.Blazor/"]
COPY ["src/SDKs/HR.SDK/HR.SDK.csproj", "src/SDKs/HR.SDK/"]
COPY ["src/Shared/HR.Contracts/HR.Contracts.csproj", "src/Shared/HR.Contracts/"]
COPY ["src/Shared/HR.Razor.Components/HR.Razor.Components.csproj", "src/Shared/HR.Razor.Components/"]
RUN dotnet restore "src/Apps/HR.Blazor/HR.Blazor.csproj"
COPY . .
WORKDIR "/src/src/Apps/HR.Blazor"
RUN dotnet build "HR.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HR.Blazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HR.Blazor.dll"]