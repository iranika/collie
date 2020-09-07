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
let driverDir = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.nuget\\packages\\selenium.webDriver.chromedriver\\85.0.4183.8700\\driver\\win32"
//
//
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