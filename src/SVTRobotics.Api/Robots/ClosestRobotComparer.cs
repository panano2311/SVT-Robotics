
public class ClosestRobotComparer : IComparer<ClosestRobot>
{
    public int Compare(ClosestRobot? x, ClosestRobot? y)
    {
        if (x == null || y == null) return 0;

        if (x.DistanceToGoal <= 10 && y.DistanceToGoal <= 10 && x.BatteryLevel != y.BatteryLevel)
        {
            if(x.BatteryLevel > y.BatteryLevel)
            {
                return - 1;
            }
            return 1;
        }
        return x.DistanceToGoal.CompareTo(y.DistanceToGoal);
    }
}