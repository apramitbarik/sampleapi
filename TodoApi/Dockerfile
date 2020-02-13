FROM mcr.microsoft.com/dotnet/core/sdk:3.1
COPY . /app
WORKDIR /app
 
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
 
EXPOSE 5001/tcp
ENV ASPNETCORE_URLS https://*:5001
 
ENTRYPOINT ["dotnet", "run"]