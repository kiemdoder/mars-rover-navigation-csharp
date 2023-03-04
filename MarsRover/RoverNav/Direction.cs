namespace MarsRover.RoverNav;

public enum Direction
{
  North = 'N',
  East = 'E',
  South = 'S',
  West = 'W',
  Unknown
}

public static class DirectionOperations
{

  static readonly char[] validSymbols = new char[]{'N', 'E', 'S', 'W'};
  public static Direction DirectionFromSymbol(char symbol) {
    if (validSymbols.Contains(symbol)) {
      return (Direction)symbol;
    }
    return Direction.Unknown;
  }

  public static Direction Turn(Direction direction, TurnDirection turnDirection) {
    if (turnDirection == TurnDirection.Right) {
      return direction switch {
        Direction.North => Direction.East,
        Direction.East => Direction.South,
        Direction.South => Direction.West,
        Direction.West => Direction.North,
        _ => direction
      };
    } else if (turnDirection == TurnDirection.Left) {
      return direction switch {
        Direction.North => Direction.West,
        Direction.East => Direction.North,
        Direction.South => Direction.East,
        Direction.West => Direction.South,
        _ => direction
      };
    }
    return direction;
  }
}