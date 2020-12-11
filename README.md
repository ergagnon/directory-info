# Directory Info
[Requirements](Requirements.md)

## Technologies and Tools used
I used languages and technologies that i'm comfortable with to focus mostly on the requirements and deliver the product faster. The actual solution can run on Windows, Linux and Mac but I only published the Linux version.

* Built with [.Net core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

* Writen in [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)

* Code hosted on [Github](https://github.com/egagnon77/directory-info)

* CI/CD [Github Actions](https://github.com/egagnon77/directory-info/actions)

* Command-line interface (Cli) demo with [Docker](https://hub.docker.com/r/dbw4452/directory-info.cli)

## Setup

### .Net core
[Install .Net core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1)

### Source code
```
git clone https://github.com/egagnon77/directory-info.git
cd directory-info
dotnet restore
```

## How to use the Cli

### Docker (hassle-free)
The application run in a Ubuntu Docker container. A demo script is exectuted to show the result of the cli application. 
See the files **Dockerfile** and **demo.sh** for more details.

[Install Docker](https://docs.docker.com/get-docker/)

``` 
docker pull dbw4452/directory-info.cli
docker run dbw4452/directory-info.cli
```

### Publish
```
dotnet publish DirectoryInfo.Cli -o ./publish -f netcoreapp3.1 -c Release -r linux-x64 -p:PublishSingleFile=true
```

### Use the cli
```
cd publish
./DirectoryInfo.Cli --help
./DirectoryInfo.Cli directory <path>
```

## How to use the UI

### Publish
```
dotnet publish DirectoryInfo.UI -o ./publish -f netcoreapp3.1 -c Release -r linux-x64 -p:PublishSingleFile=true
```

### Use the UI
```
cd publish
./DirectoryInfo.UI
```

## Development choices

* Use of a simple DDD architecture to create a rich domain.
* Use of Composite Design pattern for the directory tree structure.
* Use of recursion function to build the directory tree and to print it in the console.

## Quality

* Use of unit tests.
* CI to build / test before deployment.

## Todo for production ready

* Add more unit tests (like Infrastructure with System.IO.Abstractions).
* Add Acceptation testing and End-To-End testing.
* Versionning (semver).
* Better error handling with descriptive message.
* Make code more robust.
* Add logging system.
* Better UI.
* Deployment of binaries on Artifactory or equivalent.
* Provide a Windows and Mac version.
* Add pull request pipeline to validate quality before merging with master/main.
* Add vulnerabilities detection in build pipeline [OWASP Dependency-Check](https://owasp.org/www-project-dependency-check/).
  