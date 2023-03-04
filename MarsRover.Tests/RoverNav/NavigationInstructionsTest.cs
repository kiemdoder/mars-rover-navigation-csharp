namespace MarsRover.RoverNav.Tests;

[TestClass]
public class NavigationInstructionsTest {
  [TestMethod]
  public void IsInstructionsTextFormat() {
    Assert.IsTrue(NavigationInstructions.IsInstructionsTextFormat("RLMMLRM"));
    Assert.IsFalse(NavigationInstructions.IsInstructionsTextFormat("RLMXMLRM"));
  }

  [TestMethod]
  public void DriveRover() {
    var rover = new Rover(new Coordinates(0, 0), Direction.North);
    var instructions = new NavigationInstructions("MRMLM");
    instructions.DriveRover(rover, new Area(2, 3), new List<Rover>());
    Assert.AreEqual(rover.Coordinates, new Coordinates(1, 2));
  }

  [TestMethod]
  public void DriveRoverWithCollision() {
    var rover = new Rover(new Coordinates(0, 0), Direction.North);
    var instructions = new NavigationInstructions("MRMLMRMLM");
    instructions.DriveRover(rover, new Area(2, 3), Rovers.Of(new Rover(new Coordinates(2, 2), Direction.North)));
    Assert.AreEqual(rover.Coordinates, new Coordinates(1, 2));
  }
}