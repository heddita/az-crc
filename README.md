# az-crc
My Azure Resume - Cloud Resume Challenge

## First Steps

- Created this lovely repo in Github.
- Added the frontend folder with HTML template and modified to fit.  
- Added folder structure for future.
- Added counter.js for visitor counter in the front end folder. (Fixed folder structure for consistency.)
- https://youtu.be/ieYrBWmkfno?si=BEDXeH6gO4yql7UB&t=1436 up to this part of the tutorial from Made by GPS.
  
## Second Steps

- Created resource group in Azure, along with Cosmos DB NoSQL.
- Created db and the counter container and created the /id item inside the counter counter.  This starts the counter off at 0.
- Created the Azure Function by using the Azure extension on VS Code.  I was able to create a new function on the local project, which ran from the root project folder az-crc\backend\api.
- This created some issues while installing the dotnet8 and dotnet6 dependencies.
- I had to do some T&S and in the end the following command inside the backend\api folder saved the day.
`` dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org ``
- Created a Counter.cs file in the backend folder to begin binding the CosmosDB to the counter function.
- Modified the GetResumeCounters.cs

