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


## Customisation
You can change a few inputs for the test execution by modifying the values in the *.env file
```bash
{projectPath}/EnvironmentVariables/
```
Value  | Type | Manipulation
------------- | ------------- | -------------
WebElementTimeout  | int | 30 if value can't be parsed to int or value is lower than 10
ReportFolderName  | string | Only allows alphabetical values, fallback is 'Report'
GoogleMapsBaseUrl  | string | Default Url
ForcedLanguageCode  | string | Language codes must follow the [ISO 3166 standard](https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes) for country codes
HeadlessExecutionFlag  | bool | true if value can't be parsed to bool

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
## Code Documentation
Code documentation can be found here (open the respective index.html file):
```bash
{projectPath}/CodeDocumentation/index.html
```

## 🦾 CMD
```bash
nunit3-console.exe ./bin/Release/GoogleMapsSeleniumCSharp.dll 
```