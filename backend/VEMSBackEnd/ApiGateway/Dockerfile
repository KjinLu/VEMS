FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build 
WORKDIR /src
COPY ["WebApi/WebApi.csproj","WebApi/"]
COPY ["BusinessObject/BusinessObject.csproj","BusinessObject/"]
RUN dotnet restore  "WebApi/WebApi.csproj"
COPY . . 
WORKDIR /src/WebApi
RUN dotnet build "WebApi.csproj" -c release -o /app 

FROM build AS publish 
RUN dotnet publish "WebApi.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 
WORKDIR /app 
COPY --from=build /app . 
ENTRYPOINT [ "dotnet", "WebApi.dll" ]