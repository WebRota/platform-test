# Use the official .NET SDK image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj files and restore any dependencies (NuGet packages) for a .NET application
COPY ./WebRota.Domain/WebRota.Domain.csproj ./WebRota.Domain/
COPY ./WebRota.Infra/WebRota.Infra.csproj ./WebRota.Infra/
COPY ./WebRota/WebRota.web.csproj ./WebRota/
RUN dotnet restore ./WebRota.Domain/WebRota.Domain.csproj
RUN dotnet restore ./WebRota.Infra/WebRota.Infra.csproj
RUN dotnet restore ./WebRota/WebRota.web.csproj

# Copy the remaining source code for the .NET application
COPY ./WebRota.Domain ./WebRota.Domain/
COPY ./WebRota.Infra ./WebRota.Infra/
COPY ./WebRota ./WebRota/

# Build the .NET application
RUN dotnet publish WebRota/WebRota.web.csproj -c Release -o out

# Create a temporary stage for the Node.js application
# FROM node AS node

# Set the working directory for the Node.js application
# WORKDIR /nodeapp

# Copy the package.json and package-lock.json files to the Node.js container
#COPY ./WebRota/ClientApp/package*.json ./

# Install npm dependencies for the Node.js application
#RUN npm install

# Copy the remaining source code for the Node.js application
#COPY ./WebRota ./

# Build the .NET application
#RUN npm run build

# Use a lighter-weight runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the published .NET application to the runtime image
#COPY --from=build /app/out ./

# Copy the Node.js application to the runtime image
#COPY --from=node /WebRota/ClientApp/ ./wwwroot

# Expose a port that the application will listen on
EXPOSE 80

# Define the entry point for the application
ENTRYPOINT ["dotnet", "WebRota.Web.dll"]
