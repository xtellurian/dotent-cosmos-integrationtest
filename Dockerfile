FROM mcr.microsoft.com/dotnet/core/sdk:3.0
RUN curl -sL https://aka.ms/InstallAzureCLIDeb | bash

# Copy csproj and restore as distinct layers
COPY . ./
RUN dotnet build
ENV ASPNETCORE_ENVIRONMENT=Development

CMD [ "dotnet", "test", "-l:trx;LogFileName=/output/TestOutput.xml ", "/p:CollectCoverage=true", "/p:CoverletOutputFormat=cobertura", "/p:CoverletOutput=/output/" ]
