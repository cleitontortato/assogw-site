# Stage 1: Build Tailwind CSS
FROM node:22-slim AS tailwind
WORKDIR /src
COPY package.json package-lock.json ./
RUN npm ci
COPY . .
RUN npm run css:build

# Stage 2: .NET base runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Stage 3: .NET build
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src
COPY ["assogw.csproj", "."]
RUN dotnet restore "assogw.csproj"
COPY . .
COPY --from=tailwind /src/wwwroot/css/output.css ./wwwroot/css/output.css
RUN dotnet build "assogw.csproj" -c Release -o /app/build

# Stage 4: .NET publish
FROM build AS publish
RUN dotnet publish "assogw.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 5: Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER 1000
ENTRYPOINT ["dotnet", "assogw.dll"]
