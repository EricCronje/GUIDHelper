dotnet build $1 | grep -i ">" | awk '{print $3}'| sed 's/C:/\/c/g'| sed 's/\\/\//g'
