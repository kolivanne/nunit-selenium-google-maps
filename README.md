# nunit-selenium-google-maps
Dear visitor,
thanks for checking out my code!
This demo implements an automation strategy for Google maps.com, using .Net6.0 Selenium C# with NUnit.
The code runs Chrome and Firefox in --headless mode.

Additional NuGet Packages:
- ExtentReports.Core
- SeleniumExtras.WaitHelpers
- Selenium.WebDriver
- coverlet.collector


## CI
The project uses GitHub action which executes the end-to-end tests and generates reports when creating push and pull requests on the main branch.

## Local Test Execution
Each local test execution generates a report file. You can open each report by opening the index.html file.
Failed test cases have a screenshot attached:
```bash
{projectPath}/Report/
```
In addition, other exceptions are stored in a log file:
```bash
{projectPath}/Report/ExceptionLog
```

## 🦾 CMD
```bash
nunit3-console.exe ./bin/Release/GoogleMapsSeleniumCSharp.dll 
```
## Wiki
Feel free to visit the [Wiki section](https://github.com/kolivanne/nunit-selenium-google-maps/wiki) for more in-depth information.
