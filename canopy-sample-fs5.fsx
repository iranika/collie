#r "nuget: FSharp.Compiler"
#r "nuget: Selenium.WebDriver"
#r "nuget: canopy"
#r "nuget: Selenium.WebDriver.ChromeDriver, 83.0.0"

open canopy
open canopy.runner.classic
open canopy.configuration
open canopy.classic
open canopy.reporters
open OpenQA.Selenium
open System.IO
open System

let chromeDir = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.nuget\\packages\\selenium.chrome.webdriver\\83.0.0\\driver"
canopy.configuration.chromeDir <- chromeDir
reporter <- new JUnitReporter("./TestResults.xml")


//start remote
start chrome

"Google検索でLAJのHPにアクセス" &&& fun _ ->
    //検索ページのURLを開く
    url "https://www.google.co.jp/"
    //検索ボックスに文字を入力
    "input[name='q']" << "ボーダーコリー"
    //検索ボタンをクリック
    click "Google 検索"

run()
quit()