echo "Deploying PAgination"
echo "Check files count before remove ... "
ls /c/_FLAP03/GBZZBEBJ/Working/PaginationDeployment/*.* | wc -l;

echo "Removing files ..."
rm /c/_FLAP03/GBZZBEBJ/Working/PaginationDeployment/*.*;

echo "Check files count after remove"
ls /c/_FLAP03/GBZZBEBJ/Working/PaginationDeployment/*.* | wc -l;
echo "Clean Project"
dotnet clean $1| grep -i "Done Building Project"
echo "Build project"
dotnet build $1| grep -i \>
echo "Test the project"
dotnet test $1 |grep -i Fail
echo "Building project: $1"
./getProjectPath.sh $1 | while read line; do cp $line*.* /c/_FLAP03/GBZZBEBJ/Working/PaginationDeployment/;done;
echo "Project deployed..."
echo "Check files count:"
ls /c/_FLAP03/GBZZBEBJ/Working/PaginationDeployment/*.* | wc -l;
echo "Create sha256 file: " $1
./sha256gen.sh $1 
echo "Check sha file:"
cat sha256

