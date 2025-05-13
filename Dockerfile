FROM nvidia/cuda:11.8.0-runtime-ubuntu22.04

ENV DEBIAN_FRONTEND="noninteractive"
RUN apt-get update && \
    # General
    apt-get install -y build-essential software-properties-common wget && \
    # .NET
    add-apt-repository -y ppa:dotnet/backports && \
    apt-get update && \
    apt-get install -y dotnet-sdk-9.0 && \
    # Fonts required by DevExpress Office File API
    apt-get install -y libc6 libicu-dev libfontconfig1 ttf-mscorefonts-installer libjpeg-turbo8
   
# Add dev express source URL
RUN dotnet nuget add source https://nuget.devexpress.com/$DEVEXPRESSKEY/api

# Remove usage of base image entrypoint script
ENTRYPOINT ["/bin/bash"]

WORKDIR /App

# Add context everything
ADD . ./
# Go to target project directory
WORKDIR /App
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out


ENTRYPOINT ["dotnet", "DevExpressTest.dll"]