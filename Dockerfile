# Use the SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy only the project files and restore dependencies
COPY ["src/Services/Customers/Customers.Api/Customers.Api.csproj", "/src/Services/Customers/Customers.Api/"]
COPY ["src/Services/Customers/Customers/Customers.csproj", "/src/Services/Customers/Customers/"]
COPY ["src/Infrastructure/Infrastructure/Infrastructure.csproj", "/src/Infrastructure/Infrastructure/"]
COPY ["src/Core/Core/Core.csproj", "/src/Core/Core/"]
RUN dotnet restore "/src/Services/Customers/Customers.Api/Customers.Api.csproj"

# Copy the entire application code
COPY . .

# Build the application
WORKDIR "src/Services/Customers/Customers.Api"
RUN dotnet build "Customers.Api.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Customers.Api.csproj" -c Release -o /app/publish

# Use the base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy the published application from the build stage
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Customers.Api.dll"]
