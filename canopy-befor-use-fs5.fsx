#r "nuget: Selenium.WebDriver"
#r "nuget: canopy"
#r "nuget: Selenium.WebDriver.ChromeDriver, 85.0.4183.8700"

open canopy
open canopy.runner.classic
open canopy.configuration
open canopy.classic
open canopy.reporters
open System

//TODO: Win/Mac/Linuxによってディレクトリが変わるようなので、その分岐処理を実装
let driverDir = match System.Environment.OSVersion.Platform with
    | System.PlatformID.Win32NT -> System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.nuget\\packages\\selenium.webDriver.chromedriver\\85.0.4183.8700\\driver\\win32"
    | System.PlatformID.Unix -> System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/.nuget/packages/selenium.webDriver.chromedriver/85.0.4183.8700/driver/mac64"
    // System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.nuget\\packages\\selenium.webDriver.chromedriver\\85.0.4183.8700\\driver\\linux64"
    // System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.nuget\\packages\\selenium.webDriver.chromedriver\\85.0.4183.8700\\driver\\mac64"

canopy.configuration.chromeDir <- driverDir
reporter <- new JUnitReporter("./TestResults.xml")

start chrome

