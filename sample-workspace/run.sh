#!/usr/bin/env bash

scriptLocation=$(dirname "${BASH_SOURCE[0]}")

docker pull structurizr/lite
docker run -it --rm -p 999:8080 -v $scriptLocation:/usr/local/structurizr structurizr/lite