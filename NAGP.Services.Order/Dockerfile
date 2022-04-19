#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NAGP.Services.Order/NAGP.Services.Order.csproj", "NAGP.Services.Order/"]
RUN dotnet restore "NAGP.Services.Order/NAGP.Services.Order.csproj"
COPY . .
WORKDIR "/src/NAGP.Services.Order"
RUN dotnet build "NAGP.Services.Order.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NAGP.Services.Order.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NAGP.Services.Order.dll"]