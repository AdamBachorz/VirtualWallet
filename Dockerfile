#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY ["VirtualWallet.API/VirtualWallet.API.csproj", "VirtualWallet.API/"]
COPY ["VirtualWallet.WebApp/VirtualWallet.WebApp.csproj", "VirtualWallet.WebApp/"]
COPY ["VirtualWallet.ApiConsumer/VirtualWallet.ApiConsumer.csproj", "VirtualWallet.ApiConsumer/"]
COPY ["VirtualWallet.Common/VirtualWallet.Common.csproj", "VirtualWallet.Common/"]
COPY ["VirtualWallet.Model/VirtualWallet.Model.csproj", "VirtualWallet.Model/"]
COPY ["VirtualWallet.DAL/VirtualWallet.DAL.csproj", "VirtualWallet.DAL/"]
#COPY ["VirtualWallet.csproj", "VirtualWallet/"]

# RUN dotnet restore "VirtualWallet.API/VirtualWallet.API.csproj"
# COPY . .
# WORKDIR "/src/VirtualWallet.API"
# #WORKDIR "/src/VirtualWallet"
# #COPY . .
# RUN dotnet build "VirtualWallet.API.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "VirtualWallet.API.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# #ENTRYPOINT ["dotnet", "VirtualWallet.dll"]
# CMD ASPNETCORE_URLS=http://*:$PORT dotnet VirtualWallet.API.dll


RUN dotnet restore "VirtualWallet.WebApp/VirtualWallet.WebApp.csproj"
COPY . .
WORKDIR "/src/VirtualWallet.WebApp"
#WORKDIR "/src/VirtualWallet"
#COPY . .
RUN dotnet build "VirtualWallet.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VirtualWallet.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "VirtualWallet.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet VirtualWallet.WebApp.dll