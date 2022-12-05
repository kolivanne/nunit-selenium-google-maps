# nunit-selenium-google-maps
Dear visitor,
thanks for checking out my code!
This demo implements an automation strategy for google maps.com, using .Net6.0 Selenium C# with NUnit.
The code runs Chrome and Firefox in --headless and generates report files in the project folder *Reports*. You can open each report by opening the index.html file.
Failed test cases have a screenshot attached.

Additional NuGet Packages:
- ExtentReports.Core
- SeleniumExtras.WaitHelpers
- Selenium.WebDriver

Number of test cases to execute: 54

Since the code was developed under Windows, you will have to touch a few files to make it work on a Mac.

## 💜 Getting it ready under Mac for local test executions
- Download Geckodriver and Chromedriver for your system and put them into the project folder *webdriver* 
- in src/Utils/FilePaths.cs:</br>
- Please adjust the paths for your Firefox executable (I had to add the property *BrowserExecutableLocation* due to issues with my geckodriver)
- Please adjust other variables in the class file if needed
- Clean and build the project

## 🔎 Documentation
```
Reporting
```bash
{projectPath}/Reports/
```
## 🦾 CMD
```bash
nunit3-console.exe ./bin/Release/GoogleMapsSeleniumCSharp.dll 
```
The tests are executed in headless mode by default
## 🚀 Troubleshooting
- You might have to adjust the paths in FilePaths.cs when using MacOS in order to run the project successfully
- Visit https://www.selenium.dev/downloads/ and add fitting browser version to 
```bash
{projectPath}/webDriver/
```
