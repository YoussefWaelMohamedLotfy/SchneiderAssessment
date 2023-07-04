FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
#COPY ["src/Apps/HR.Blazor.WebAssembly/HR.Blazor.WebAssembly.csproj", "."]
#RUN dotnet restore "HR.Blazor.WebAssembly.csproj"
COPY ["Directory.Build.props", "."]
COPY ["src/Apps/HR.Blazor.WebAssembly/HR.Blazor.WebAssembly.csproj", "src/Apps/HR.Blazor.WebAssembly/"]
COPY ["src/Shared/HR.Razor.Components/HR.Razor.Components.csproj", "src/Shared/HR.Razor.Components/"]
COPY ["src/SDKs/HR.SDK/HR.SDK.csproj", "src/SDKs/HR.SDK/"]
COPY ["src/Shared/HR.Contracts/HR.Contracts.csproj", "src/Shared/HR.Contracts/"]
RUN dotnet restore "src/Apps/HR.Blazor.WebAssembly/HR.Blazor.WebAssembly.csproj"
COPY . .
WORKDIR "/src/src/Apps/HR.Blazor.WebAssembly"
RUN dotnet build "HR.Blazor.WebAssembly.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HR.Blazor.WebAssembly.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish .
COPY nginx.conf /etc/nginx/nginx.conf
ENTRYPOINT ["dotnet", "HR.Blazor.WebAssembly.dll"]