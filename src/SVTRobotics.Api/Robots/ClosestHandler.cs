
public static class ClosestHandler
{    
    public static async Task<IResult> HandleAsync(Load load, IRobotsClient client, CancellationToken cancellation)
    {
        var robots = await client.GetAsync(cancellation);

        var closest = robots
            .Select(robot => new ClosestRobot(robot.RobotId, robot.BatteryLevel, CalculateDistance(load.X, load.Y, robot.X, robot.Y)))
            .Min(new ClosestRobotComparer());
        
        return closest != null ? TypedResults.Ok(closest) : TypedResults.NotFound();
    }

    private static double CalculateDistance(int X1, int Y1, int X2, int Y2)
    {
        return Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
    }
}
