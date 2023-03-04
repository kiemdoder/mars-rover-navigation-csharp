namespace MarsRover.RoverNav.Tests;

using static DirectionOperations;

[TestClass]
public class DirectionTest {
  [TestMethod]
  public void TurnTest() {
    Assert.AreEqual(Direction.East, Turn(Direction.North, TurnDirection.Right));
    Assert.AreEqual(Direction.West, Turn(Direction.North, TurnDirection.Left));
  }
}