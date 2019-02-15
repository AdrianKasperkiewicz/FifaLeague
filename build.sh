cd src/API
SonarScanner.MSBuild.exe begin /k:"pmozola_FifaLeague" /d:sonar.organization="pmozola-github" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login=${SONAR_TOKEN}
dotnet restore
dotnet build
SonarScanner.MSBuild.exe end /d:sonar.login=${SONAR_TOKEN}