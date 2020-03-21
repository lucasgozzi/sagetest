#!/bin/bash

set -e

cd ./Api
until dotnet ef database update; do
>&2 echo "SQL Server is starting up"
sleep 1
done


>&2 echo "SQL Server is up - executing command"
run_cmd="dotnet /app/publish/Api.dll"
exec $run_cmd