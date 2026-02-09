FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src
COPY ["assogw.csproj", "."]
RUN dotnet restore "assogw.csproj"
COPY . .
RUN dotnet build "assogw.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "assogw.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER 1000
ENTRYPOINT ["dotnet", "assogw.dll"]
