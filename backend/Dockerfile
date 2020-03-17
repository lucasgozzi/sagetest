FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
WORKDIR /app
FROM mcr.microsoft.com/dotnet/core/sdk:2.1
WORKDIR /src
COPY . .
RUN dotnet restore "./Api/Api.csproj"
RUN dotnet build "Api/Api.csproj" -c Release -o /app/build
RUN dotnet publish "Api/Api.csproj" -c Release -o /app/publish
EXPOSE 5000
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Api.dll"]