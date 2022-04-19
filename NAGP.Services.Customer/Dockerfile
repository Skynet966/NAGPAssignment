#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NAGP.Services.Customer/NAGP.Services.Customer.csproj", "NAGP.Services.Customer/"]
RUN dotnet restore "NAGP.Services.Customer/NAGP.Services.Customer.csproj"
COPY . .
WORKDIR "/src/NAGP.Services.Customer"
RUN dotnet build "NAGP.Services.Customer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NAGP.Services.Customer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NAGP.Services.Customer.dll"]