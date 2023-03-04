namespace MarsRover.RoverNav;

using System.Text.RegularExpressions;

public class Area
{
  private int width;
  private int height;

  private static Regex areaRx = new Regex(@"(\d+) (\d+)");

  public Area(int maxX, int maxY)
  {
    width = maxX + 1;
    height = maxY + 1;
  }

  public static bool IsAreaTextFormat(string s) => areaRx.IsMatch(s);

  public static Area? Parse(string s) {
    if (IsAreaTextFormat(s)) {
      var match = areaRx.Match(s);
      int maxX = int.Parse(match.Groups[1].Value);
      int maxY = int.Parse(match.Groups[2].Value);
      return new Area(maxX, maxY);
    }
    return null;
  }

  public bool CoordinatesOutside(Coordinates coordinates)
  {
    int x = coordinates.X;
    int y = coordinates.Y;

    return x < 0 || y < 0 || x >= width || y >= height;
  }

}