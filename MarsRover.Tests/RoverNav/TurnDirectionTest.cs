namespace MarsRover.RoverNav.Tests;

using static TurnDirectionOperations;

[TestClass]
public class TurnDirectionTest {
  [TestMethod]
  public void FromSymbolTest() {
    var turnDir = FromSymbol('L');
    Assert.AreEqual(TurnDirection.Left, turnDir);
    var unknownTurnDir = FromSymbol('X');
    Assert.AreEqual(TurnDirection.Unknown, unknownTurnDir);
  }
} 