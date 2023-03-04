namespace MarsRover.RoverNav.Tests;

[TestClass]
public class RoverTest
{
  [TestMethod]
  public void IsRoverTextFormat()
  {
    Assert.IsTrue(Rover.IsRoverTextFormat("4 33 S"));
    Assert.IsFalse(Rover.IsRoverTextFormat("4 33S"));
    Assert.IsFalse(Rover.IsRoverTextFormat("4 33"));
  }

  [TestMethod]
  public void Parse() {
    var rover = Rover.Parse("5 12 E");
    Assert.IsNotNull(rover);
    Assert.AreEqual(rover.Coordinates, new Coordinates(5, 12));
    Assert.AreEqual(rover.Direction, Direction.East);
  }

  [TestMethod]
  public void Turn() {
    var rover = new Rover(new Coordinates(0, 0), Direction.North);
    rover.Turn(TurnDirection.Right);
    Assert.AreEqual(rover.Direction, Direction.East);
    rover.Turn(TurnDirection.Right);
    Assert.AreEqual(rover.Direction, Direction.South);
    rover.Turn(TurnDirection.Left);
    Assert.AreEqual(rover.Direction, Direction.East);
  }

  [TestMethod]
  public void CanMove() {
    var rover = new Rover(new Coordinates(0, 0), Direction.North);
    var otherRovers = Rovers.Of(new Rover(new Coordinates(0, 1), Direction.North));
    var area = new Area(10, 10);
    Assert.IsFalse(rover.canMove(area, otherRovers));

    Assert.IsFalse(rover.Move(area, otherRovers));
    Assert.AreEqual(rover.Coordinates, new Coordinates(0, 0));
  }

  [TestMethod]
  public void Move() {
    var area = new Area(1, 1);
    var rover = new Rover(new Coordinates(0, 0), Direction.North);
    var otherRovers = new List<Rover>();
    
    Assert.IsTrue(rover.Move(area, otherRovers));
    Assert.AreEqual(rover.Coordinates, new Coordinates(0, 1));

    rover.Turn(TurnDirection.Right);
    Assert.IsTrue(rover.Move(area, otherRovers));
    Assert.AreEqual(rover.Coordinates, new Coordinates(1, 1));

    Assert.IsFalse(rover.Move(area, otherRovers)); //cannot move outside area
  }
}