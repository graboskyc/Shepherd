#!/bin/bash

echo
echo "+================================"
echo "| START: Shepherd"
echo "+================================"
echo

source .env

datehash=`date | md5sum | cut -d" " -f1`
abbrvhash=${datehash: -8}
echo "Using conn string ${MDBCONNSTR}"
echo "Using key string ${MASTERENCKEYASBASE64}"

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
    docker run -t -i -d -p 8000:8000 --name shepherd -e "MDBCONNSTR=${MDBCONNSTR}" -e "MASTERENCKEYASBASE64=${MASTERENCKEYASBASE64}" --restart unless-stopped graboskyc/shepherd:${abbrvhash}

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