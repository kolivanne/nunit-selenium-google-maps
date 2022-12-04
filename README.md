# nunit-selenium-google-maps
UI test strategy demo

## 🔎 Documentation
Documentation of code
```bash
{projectPath}/Documentation/code/index.html
```
Test strategy
```bash
{projectPath}/Documentation/testStrategy.pdf
```
Reporting
```bash
{projectPath}/Reports/
```
## 🦾 CMD
```bash
nunit3-console.exe ./bin/Release/xxx.dll 
```
The tests are executed in headless mode by default
## 🚀 Troubleshooting
- You might have to adjust the paths in FilePaths.cs when using MacOS in order to run the project successfully
- Visit https://www.selenium.dev/downloads/ and add fitting browser version to 
```bash
{projectPath}/webDriver/
```
