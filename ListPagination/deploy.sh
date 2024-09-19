echo "Deploying PAgination"
echo "Removing files ..."
rm /c/_FLAP03/GBZZBEBJ/Working/PaginationDeployment/*.*;
echo "Building project: $1"
./getProjectPath.sh $1 | while read line; do cp $line*.* /c/_FLAP03/GBZZBEBJ/Working/PaginationDeployment/;done;
echo "Project deployed..."
