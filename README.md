# RPG

## Local execution

Navigate to the root directory of the UI project -

```
cd .\rpg-ui\ 
```
Run npm install - 

```
npm install
```

Run the script to start the UI and API defined in package.json -

```json
"scripts": {
  "start": "npm-run-all --parallel start-ui start-api",
  "start-ui": "electron-forge start",
  "start-api": "dotnet run --project ../API/RPG.Api/RPG.Api.csproj"
```

```
npm run start
```
