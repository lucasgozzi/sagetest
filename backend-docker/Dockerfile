FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /src
COPY ["backend-docker.csproj", "./"]
RUN dotnet restore "./backend-docker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "backend-docker.csproj" -c Release -o /app/build
RUN dotnet publish "backend-docker.csproj" -c Release -o /app/publish
EXPOSE 5000
EXPOSE 5001
WORKDIR /app
COPY publish .
ENTRYPOINT ["dotnet", "backend-docker.dll"]