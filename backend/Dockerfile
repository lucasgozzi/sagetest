FROM mcr.microsoft.com/dotnet/core/sdk:2.1
WORKDIR /app
COPY . /app
RUN dotnet restore
RUN dotnet build

RUN dotnet publish "./Api/Api.csproj" -c Release -o /app/publish

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh