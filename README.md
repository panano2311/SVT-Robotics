# SVT Robotics Assessment

## Build and Run

- Clone the repository
- Open solution `SVT Robotics.sln` with Visual studio and run project `src\SVTRobotics.Api` or 
- Using the cli, navigate to `.\src\SVTRobotics.Api\` and run `dotnet run`

## Test

### Unit Tests
- Run tests in `src\test` in Visual Studio or
- Run `dotnet test` from the cli.

- You can 

### Postman

- Open postman
- Create a new POST request with URL `http://localhost:5000/api/robots/closest`
- Change body type to Raw JSON and paste 
`{
    "loadId": 231,
    "x": 5, 
    "y": 3
}` in the body
- Result should be
`{
    "robotId": "4",
    "batteryLevel": 37,
    "distanceToGoal": 5
}`

# What To Do Next

- Group endpoint maps by resource like `robots` for easy definiton of related enpoints
- Move routes to a constant
- Improve error handling
- Improve logging
- Add health checks
- Add telemetry
- Add more unit tests