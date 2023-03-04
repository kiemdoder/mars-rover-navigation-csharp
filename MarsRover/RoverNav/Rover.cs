namespace MarsRover.RoverNav;

using System.Text.RegularExpressions;

public class Rover
{
  private Coordinates coordinates;
  public Coordinates Coordinates { get => coordinates; }
  private Direction direction;
  public Direction Direction { get => direction; }

  private static Regex roverRx = new Regex(@"(\d+) (\d+) ([NWSE])");

  public Rover(Coordinates coordinates, Direction direction)
  {
    this.coordinates = coordinates;
    this.direction = direction;
  }

  public static bool IsRoverTextFormat(string s) => roverRx.IsMatch(s);

  public static Rover? Parse(string s)
  {
    if (IsRoverTextFormat(s))
    {
      var match = roverRx.Match(s);
      int x = int.Parse(match.Groups[1].Value);
      int y = int.Parse(match.Groups[2].Value);
      var dir = DirectionOperations.DirectionFromSymbol(match.Groups[3].Value[0]);
      return new Rover(new Coordinates(x, y), dir);
    }

    return null;
  }

  public void Turn(TurnDirection turnDirection)
  {
    direction = DirectionOperations.Turn(direction, turnDirection);
  }

  public bool Move(Area area, List<Rover> otherRovers)
  {
    if (!canMove(area, otherRovers)) {
      return false;
    }

    var nextCoordinates = coordinates.Move(direction);
    if (area.CoordinatesOutside(coordinates)) {
      return false;
    }
    coordinates = nextCoordinates;
    return true;
  }

  public bool canMove(Area area, List<Rover> otherRovers)
  {
    var nextCoordinates = coordinates.Move(direction);
    if (area.CoordinatesOutside(nextCoordinates))
    {
      Console.WriteLine("Reached the end of the plateau");
      return false;
    }

    if (otherRovers.Exists(rover => rover.Coordinates.Equals(nextCoordinates)))
    {
      Console.WriteLine("Bumped into another rover");
      return false;
    }

    return true;
  }

  public override string ToString()
  {
    return coordinates + " " + (char)direction;
  }
}

public static class Rovers {
  public static List<Rover> Of(params Rover[] rovers) {
    return new List<Rover>(rovers);
  }
}