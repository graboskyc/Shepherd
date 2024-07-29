#!/bin/bash

echo
echo "+================================"
echo "| START: Shepard"
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
docker build -t graboskyc/shepard:latest -t graboskyc/shepard:${abbrvhash} --platform=linux/amd64 .

EXITCODE=$?

if [ $EXITCODE -eq 0 ]
    then

    echo 
    echo "Starting container"
    echo
    docker stop shepard
    docker rm shepard
    docker run -t -i -d -p 8000:8000 --name shepard -e "MDBCONNSTR=${MDBCONNSTR}" -e "MASTERENCKEYASBASE64=${MASTERENCKEYASBASE64}" --restart unless-stopped graboskyc/shepard:${abbrvhash}

    echo
    echo "+================================"
    echo "| END:  Shepard"
    echo "+================================"
    echo
else
    echo
    echo "+================================"
    echo "| ERROR: Build failed"
    echo "+================================"
    echo
fi