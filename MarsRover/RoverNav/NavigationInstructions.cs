namespace MarsRover.RoverNav;

using System.Text.RegularExpressions;

public class NavigationInstructions {

  private static Regex instructionsRx = new Regex(@"[RLM]+");

  private string instructions;

  public NavigationInstructions(string instructions) {
    this.instructions = instructions;
  }

  public static bool IsInstructionsTextFormat(string s) => instructionsRx.IsMatch(s);

  public bool DriveRover(Rover rover, Area area, List<Rover> otherRovers) {
    foreach(char c in instructions) {
      switch (c) {
        case 'R':
        case 'L':
          rover.Turn(TurnDirectionOperations.FromSymbol(c));
          break;
        case 'M':
          if (!rover.Move(area, otherRovers)) {
            return false;
          }
          break;
        default:
          return false;
      }
    }
    return true;
  }

}