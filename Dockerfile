FROM mcr.microsoft.com/dotnet/core/sdk:2.2 

WORKDIR /app

COPY ./SumpThingApi /app

RUN dotnet restore

ENTRYPOINT dotnet watch run --urls=http://+:5000