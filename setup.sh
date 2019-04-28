#! /bin/bash

GREEN="\033[01;32m"
RED="\033[01;31m"
RESET="\033[0m"

PREFIX="${RED}[${GREEN}SumpThingApi${RED}]${RESET}:"

IMAGE="$( docker image ls | grep sump-thing/api )"

if [ -z "$IMAGE" ]
then
  docker build -t sump-thing/api .

  echo ""
  echo "${PREFIX} Setup complete."
  echo ""
else
  echo ""
  echo -e "${PREFIX} Image found on system. Setup already completed."
  echo ""
fi