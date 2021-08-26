# collie
F#Interactive + canopy( web test framework ) = smart test coding

## Demo

![](./docs/collie.gif)


## How to use?

Note: You will need to rewrite the chrome driver version to match your environment.

in canopy-befor-use-fs5.fsx
```fs
#r "nuget: Selenium.WebDriver"
#r "nuget: canopy"
//this version number.
#r "nuget: Selenium.WebDriver.ChromeDriver, 85.0.4183.8700"

open canopy
open canopy.runner.classic
open canopy.configuration
open canopy.classic
open canopy.reporters
open System

let driverDir = match System.Environment.OSVersion.Platform with
    // this version number //
    | System.PlatformID.Win32NT -> System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.nuget\\packages\\selenium.webDriver.chromedriver\\85.0.4183.8700\\driver\\win32" 
    | System.PlatformID.Unix -> System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/.nuget/packages/selenium.webDriver.chromedriver/85.0.4183.8700/driver/mac64"

canopy.configuration.chromeDir <- driverDir
reporter <- new JUnitReporter("./TestResults.xml")

start chrome
```

I am looking for a good fix, but haven't found one yet.

### using scoop

Note: Scoop is package manager for windows.  
When using Scoop, the dependency dotnet cli will be resolved by Scoop.

```
> scoop install https://raw.githubusercontent.com/iranika/collie/main/collie.json
> collie
```

### using git

You need install dotnet cli.

```
> git clone https://github.com/iranika/collie.git
> cd collie
> ./collie.ps1
```