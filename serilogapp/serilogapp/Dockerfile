FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY . /src/serilogapp/
RUN dotnet restore "serilogapp/serilogapp.csproj"

RUN dotnet build "serilogapp/serilogapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "serilogapp/serilogapp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "serilogapp.dll"]