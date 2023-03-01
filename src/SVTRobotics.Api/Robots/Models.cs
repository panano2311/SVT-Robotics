
public record Robot(string RobotId, int BatteryLevel, int X, int Y);
public record Load(int LoadId, int X, int Y);
public record ClosestRobot(string RobotId, int BatteryLevel, double DistanceToGoal);
