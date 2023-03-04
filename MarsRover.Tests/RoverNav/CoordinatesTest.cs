namespace MarsRover.RoverNav.Tests;

[TestClass]
public class CoordinatesTest {
  [TestMethod]
  public void EqualsTest() {
    var c1 = new Coordinates(1, 2);
    var c2 = new Coordinates(1, 2);
    Assert.IsTrue(c1.Equals(c2));
  }

  [TestMethod]
  public void MoveTest() {
    var start = new Coordinates(15, 5);
    Assert.AreEqual(start.Move(Direction.North), new Coordinates(15, 6));
    Assert.AreEqual(start.Move(Direction.East), new Coordinates(16, 5));
    Assert.AreEqual(start.Move(Direction.South), new Coordinates(15, 4));
    Assert.AreEqual(start.Move(Direction.West), new Coordinates(14, 5));
  }
}