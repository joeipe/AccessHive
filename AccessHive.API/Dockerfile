#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AccessHive.API/AccessHive.API.csproj", "AccessHive.API/"]
COPY ["AccessHive.Application/AccessHive.Application.csproj", "AccessHive.Application/"]
COPY ["AccessHive.Read.Data/AccessHive.Read.Data.csproj", "AccessHive.Read.Data/"]
COPY ["AccessHive.Read.Domain/AccessHive.Read.Domain.csproj", "AccessHive.Read.Domain/"]
COPY ["AccessHive.ViewModels/AccessHive.ViewModels.csproj", "AccessHive.ViewModels/"]
COPY ["AccessHive.Write.Data/AccessHive.Write.Data.csproj", "AccessHive.Write.Data/"]
COPY ["AccessHive.Integration.MessagingBus/AccessHive.Integration.MessagingBus.csproj", "AccessHive.Integration.MessagingBus/"]
COPY ["SharedKernel/SharedKernel.csproj", "SharedKernel/"]
COPY ["AccessHive.Write.Domain/AccessHive.Write.Domain.csproj", "AccessHive.Write.Domain/"]
RUN dotnet restore "AccessHive.API/AccessHive.API.csproj"
COPY . .
WORKDIR "/src/AccessHive.API"
RUN dotnet build "AccessHive.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccessHive.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccessHive.API.dll"]