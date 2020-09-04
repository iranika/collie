#r "nuget: Selenium.WebDriver"
#r "nuget: canopy"
#r "nuget: Selenium.WebDriver.ChromeDriver, 83.0.0"

open canopy
open canopy.runner.classic
open canopy.configuration
open canopy.classic
open canopy.reporters
open System

let driverDir = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.nuget\\packages\\selenium.chrome.webdriver\\83.0.0\\driver"
canopy.configuration.chromeDir <- driverDir
reporter <- new JUnitReporter("./TestResults.xml")


//start remote
start chrome

"Google検索でボーダーコリーを検索する" &&& fun _ ->
    //検索ページのURLを開く
    url "https://www.google.co.jp/"
    //検索ボックスに文字を入力
    "input[name='q']" << "ボーダーコリー"
    //検索ボタンをクリック
    click "Google 検索"

run()
quit()