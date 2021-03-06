#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
#WORKDIR /app
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["ML_App/ML_App.csproj", "ML_App/"]
#RUN dotnet restore "ML_App/ML_App.csproj"
#COPY . .
#WORKDIR "/src/ML_App"
#RUN dotnet build "ML_App.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "ML_App.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ML_App.dll"]

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
copy MLModel/MLModel.zip MLModel/
copy Input/ Input/
copy Output/ Output/
RUN dotnet restore

# Copy everything else and build
COPY . ./
copy MLModel/MLModel.zip MLModel/
copy Input/ Input/
copy Output/ Output/
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
copy MLModel/MLModel.zip MLModel/
copy Input/ Input/
copy Output/ Output/
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ML_App.dll"]