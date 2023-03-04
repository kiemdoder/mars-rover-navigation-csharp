namespace MarsRover.RoverNav.Tests;

[TestClass]
public class DirectionTest {
  [TestMethod]
  public void TurnTest() {
    Assert.AreEqual(Direction.East, Direction.North.Turn(TurnDirection.Right));
    Assert.AreEqual(Direction.West, Direction.North.Turn(TurnDirection.Left));
  }
}