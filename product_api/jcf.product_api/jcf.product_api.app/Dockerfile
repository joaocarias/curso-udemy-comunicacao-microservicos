#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["jcf.product_api.app/jcf.product_api.app.csproj", "jcf.product_api.app/"]
RUN dotnet restore "jcf.product_api.app/jcf.product_api.app.csproj"
COPY . .
WORKDIR "/src/jcf.product_api.app"
RUN dotnet build "jcf.product_api.app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "jcf.product_api.app.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "jcf.product_api.app.dll"]