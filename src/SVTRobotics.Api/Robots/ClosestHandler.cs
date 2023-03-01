
public static class ClosestHandler
{    
    public static async Task<ClosestRobot> HandleAsync(Load load, IRobotsClient client, CancellationToken cancellation)
    {
        var robots = await client.GetAsync(cancellation);

        //TODO: Implement
        return new ClosestRobot("1", 33, 25.0);
    }
}
