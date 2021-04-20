#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ASM.WebApi/ASM.WebApi.csproj", "ASM.WebApi/"]
COPY ["Tools.Library.Authorization/Tools.Library.Authorization.csproj", "Tools.Library.Authorization/"]
COPY ["ASM.ApiServices/ASM.ApiServices.csproj", "ASM.ApiServices/"]
COPY ["ASM.SMFaker/ASM.SMFaker.csproj", "ASM.SMFaker/"]
COPY ["Tools.Library.HttpClient/Tools.Library.HttpClient.csproj", "Tools.Library.HttpClient/"]
COPY ["ASM.Models/ASM.Models.csproj", "ASM.Models/"]
COPY ["Tools.Library.Analyzers/Tools.Library.Analyzers.csproj", "Tools.Library.Analyzers/"]
RUN dotnet restore "ASM.WebApi/ASM.WebApi.csproj"
COPY . .
WORKDIR "/src/ASM.WebApi"
RUN dotnet build "ASM.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ASM.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASM.WebApi.dll"]