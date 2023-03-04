namespace MarsRover.RoverNav;

public class Coordinates
{
  public int X { get; }
  public int Y { get; }

  public Coordinates(int x, int y)
  {
    X = x;
    Y = y;
  }

  public Coordinates Move(Direction direction) => direction switch
  {
    Direction.North => new Coordinates(X, Y + 1),
    Direction.East => new Coordinates(X + 1, Y),
    Direction.South => new Coordinates(X, Y - 1),
    Direction.West => new Coordinates(X - 1, Y),
    _ => new Coordinates(X, Y)
  };

  public override bool Equals(object? obj)
  {
    return obj is Coordinates coordinates &&
           X == coordinates.X &&
           Y == coordinates.Y;
  }

  public override int GetHashCode()
  {
    return HashCode.Combine(X, Y);
  }

  public override string ToString()
  {
    return X + " " + Y;
  }
}