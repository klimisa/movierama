FROM microsoft/dotnet:2-sdk

MAINTAINER Antonios Klimis

ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV ASPNETCORE_URLS=http://*:5000

WORKDIR /app
CMD ["/bin/bash", "-c", "dotnet restore && cd movierama.web && dotnet watch run"]
