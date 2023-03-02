using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace Api.Test;

public class RobotsTest
{
    [Fact]
    public async Task ClosestRobotTest()
    {
        // Arrange
        var mock = new Mock<IRobotsClient>();

        mock.Setup(m => m.GetAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Robot> 
            {
                new Robot("4", 37 , 2, 7),
                new Robot("53", 78 , 26, 26),
                new Robot("54", 46 , 1, 98),
                new Robot("55", 45 , 36, 33)
            });
        var load = new Load(123, 5, 3);
        var closest = new ClosestRobot("4", 37, 5);

        // Act
        var result = (Ok<ClosestRobot>)await ClosestHandler.HandleAsync(load, mock.Object, CancellationToken.None);

        //Assert
        Assert.Equal(200, result.StatusCode);
        var foundClosest = Assert.IsAssignableFrom<ClosestRobot>(result.Value);
        Assert.Equal(closest, foundClosest);
    }

    [Fact]
    public async Task ClosestRobotWithin10UnitsTest()
    {
        // Arrange
        var mock = new Mock<IRobotsClient>();

        mock.Setup(m => m.GetAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Robot>
            {
                new Robot("4", 37 , 2, 7),
                new Robot("5", 78 , 5, 8),
                new Robot("6", 46 , 1, 6),
                new Robot("7", 45 , 36, 33)
            });
        var load = new Load(123, 2, 4);
        var closest = new ClosestRobot("5", 78, 5);

        // Act
        var result = (Ok<ClosestRobot>)await ClosestHandler.HandleAsync(load, mock.Object, CancellationToken.None);

        //Assert
        Assert.Equal(200, result.StatusCode);
        var foundClosest = Assert.IsAssignableFrom<ClosestRobot>(result.Value);
        Assert.Equal(closest, foundClosest);
    }
}
