
docker pull structurizr/lite
docker run -it --rm -p 9999:8080 -v ${PSScriptRoot}:/usr/local/structurizr structurizr/lite