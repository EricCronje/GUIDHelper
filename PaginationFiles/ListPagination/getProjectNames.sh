dotnet build $1 | grep -i ">" | awk '{print $1}'| sed 's/C:/\/c/g'| sed 's/\\/\//g'
