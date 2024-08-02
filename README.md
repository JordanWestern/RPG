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

## TODO
- Test coverage for untested front end code.
- Test coverage for untested back end code (api, domain etc.).
- Resolve muddy domain objects constructors by wrapping primitives and moving value guards there.
