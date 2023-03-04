namespace MarsRover.RoverNav;

public enum TurnDirection { Right = 'R', Left = 'L', Unknown }

public static class TurnDirectionOperations
{
  public static TurnDirection FromSymbol(char symbol)
  {
    char[] validSymbols = new char[] { 'R', 'L' };
    if (validSymbols.Contains(symbol))
    {
      return (TurnDirection)symbol;
    }
    return TurnDirection.Unknown;
  }
}