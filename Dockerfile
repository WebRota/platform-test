#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0  as base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
# COPY ["WebRota.Web.csproj", "."]
# RUN dotnet restore "./WebRota.Web.csproj"

# Copy the .csproj files and restore any dependencies (NuGet packages) for a .NET application
COPY ./WebRota.Domain/WebRota.Domain.csproj ./WebRota.Domain/
COPY ./WebRota.Infra/WebRota.Infra.csproj ./WebRota.Infra/
COPY ./WebRota.Web/WebRota.Web.csproj ./WebRota.Web/
RUN dotnet restore ./WebRota.Domain/WebRota.Domain.csproj
RUN dotnet restore ./WebRota.Infra/WebRota.Infra.csproj
RUN dotnet restore ./WebRota.Web/WebRota.Web.csproj

# Copy the remaining source code for the .NET application
COPY ./WebRota.Domain ./WebRota.Domain/
COPY ./WebRota.Infra ./WebRota.Infra/
COPY ./WebRota.Web ./WebRota.Web/



COPY . .
WORKDIR "/src/."
RUN dotnet build "WebRota.Web/WebRota.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebRota.Web/WebRota.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebRota.Web.dll"]