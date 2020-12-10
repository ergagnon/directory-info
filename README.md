# Directory Info

## Requirements
Using the techs of your choice, develop an application with the following requirements:

* the app should list the folders and files in a source folder. The list should be ordered by size, and it should return the size and the last modification date of each element. Also, a count of the files and the total size should be provided.

* the app should provide a CLI to choose the folder and output the result

* the app should provide an API + UI to choose the folder and show the result

* the app should be production-ready. (no need to do everything,  you could list what left to be prod-ready)

* the app should run on a unix system (i.e. ubuntu)

### Contact
If you have any questions about the test, or you need some help; feel free to contact 
dev.technical.test@qohash.com

dotnet publish DirectoryInfo.Cli -o ./publish -f netcoreapp3.1 -c Release -r linux-x64 -p:PublishSingleFile=true
docker build --tag directory-cli .
