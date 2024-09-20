# Remove the extention - keep the .
dotnet build ListPagination.sln | grep -i ">" | awk '{print $3}'| sed 's/C:/\/c/g'| sed 's/\\/\//g' | sed 's/["dll"]\+$//g'
