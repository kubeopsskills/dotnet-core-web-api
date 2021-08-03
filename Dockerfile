FROM mcr.microsoft.com/dotnet/sdk:6.0.100-preview.6-alpine3.13-amd64 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0.0-preview.6-alpine3.13-amd64
WORKDIR /app
RUN apk --no-cache add curl
COPY --from=build-env /app/out .
EXPOSE 8090
ENTRYPOINT ["dotnet", "dotnet-core-web-api.dll"]