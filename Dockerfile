# 1. Build aþamasý
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Solution dosyasýný ve tüm projeleri kopyala
COPY . .

# Solution restore
RUN dotnet restore InveonCourseApp.sln

# API projesini publish et
RUN dotnet publish InveonCourseApp.API/InveonCourseApp.API.csproj -c Release -o /app/publish

# 2. Runtime aþamasý
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "InveonCourseApp.API.dll"]
