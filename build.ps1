cd src/API
dotnet tool install --global dotnet-sonarscanner
dotnet "SonarScanner begin /k:pmozola_FifaLeague /d:sonar.organization=pmozola-github /d:sonar.language=cs /d:sonar.host.url=https://sonarcloud.io /d:sonar.login=9f60fa7128dc42b1d1c750143dbc19f030de056e"
dotnet restore
dotnet build
dotnet SonarScanner end /d:sonar.login="9f60fa7128dc42b1d1c750143dbc19f030de056e"