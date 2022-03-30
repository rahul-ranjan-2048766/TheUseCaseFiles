#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pays Transaction/Pays Transaction.csproj", "Pays Transaction/"]
RUN dotnet restore "Pays Transaction/Pays Transaction.csproj"
COPY . .
WORKDIR "/src/Pays Transaction"
RUN dotnet build "Pays Transaction.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pays Transaction.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pays Transaction.dll"]