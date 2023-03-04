namespace MarsRover.RoverNav.Tests;

[TestClass]
public class MarsTest {
  [TestMethod]
  public void DriveRovers() {
        string instructions =
                "5 5\n" +
                "1 2 N\n" +
                "LMLMLMLMM\n" +
                "3 3 E\n" +
                "MMRMMRMRRM";
        var rovers = Mars.DriveRovers(instructions);
        Assert.IsTrue(rovers.Count > 0);
        rovers.ForEach(Console.WriteLine);
        Assert.AreEqual("1 3 N", rovers[0].ToString());
        Assert.AreEqual("5 1 E", rovers[1].ToString());

        string instructions2 =
                "3 3\n" +
                "0 0 N\n" +
                "MRMLMRMLM\n" +
                "3 3 S\n" +
                "MMMLM";
        var rovers2 = Mars.DriveRovers(instructions2);
        Assert.IsTrue(rovers2.Count > 0);
        Assert.AreEqual("2 3 N", rovers2[0].ToString());
        Assert.AreEqual("3 0 E", rovers2[1].ToString());
  }
}