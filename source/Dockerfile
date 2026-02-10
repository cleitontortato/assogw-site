FROM node:22-alpine AS tailwind
WORKDIR /src
COPY package.json package-lock.json ./
RUN npm ci
COPY wwwroot/css/input.css ./wwwroot/css/input.css
COPY wwwroot/js/ ./wwwroot/js/
COPY Views/ ./Views/
RUN npx @tailwindcss/cli -i ./wwwroot/css/input.css -o ./wwwroot/css/output.css --minify

FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src
COPY ["assogw.csproj", "."]
RUN dotnet restore "assogw.csproj"
COPY . .
COPY --from=tailwind /src/wwwroot/css/output.css ./wwwroot/css/output.css
RUN dotnet build "assogw.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "assogw.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER 1000
ENTRYPOINT ["dotnet", "assogw.dll"]
