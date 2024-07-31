#!/bin/bash

echo
echo "+================================"
echo "| START: Shepherd"
echo "+================================"
echo

source .env
cd Shepherd

datehash=`date | md5sum | cut -d" " -f1`
abbrvhash=${datehash: -8}
echo "Using conn string ${MDBCONNSTR}"
echo "Using key string ${MASTERENCKEYASBASE64}"
echo "Using Auth0 domain string ${AUTH0DOMAIN}"

echo 
echo "Building container using tag ${abbrvhash}"
echo
docker build -t graboskyc/shepherd:latest -t graboskyc/shepherd:${abbrvhash} --platform=linux/amd64 .

EXITCODE=$?

if [ $EXITCODE -eq 0 ]
    then

    echo 
    echo "Starting container"
    echo
    docker stop shepherd
    docker rm shepherd
    docker run -t -i -d -p 8000:8080 --name shepherd -e "MDBCONNSTR=${MDBCONNSTR}" -e "MASTERENCKEYASBASE64=${MASTERENCKEYASBASE64}" -e "AUTH0DOMAIN=${AUTH0DOMAIN}" -e "AUTH0CLIENTID=${AUTH0CLIENTID}" --restart unless-stopped graboskyc/shepherd:${abbrvhash}

    echo
    echo "+================================"
    echo "| END:  Shepherd"
    echo "+================================"
    echo
else
    echo
    echo "+================================"
    echo "| ERROR: Build failed"
    echo "+================================"
    echo
fi