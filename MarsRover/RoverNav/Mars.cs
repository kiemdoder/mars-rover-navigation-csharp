namespace MarsRover.RoverNav;

public static class Mars
{
  private enum States { ReadArea, ReadRover, DriveRover }

  public static List<Rover> DriveRovers(in string instructions)
  { //in string can't be modified
    Rover? currentRover = null;
    List<Rover> rovers = new List<Rover>();
    Area? plateau = null;

    States state = States.ReadArea;

    //TODO: check that lines.length < 3 || (lines.length >= 3 && (lines.length % 2 == 0))

    // foreach(var myString in entireString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
    // interpret(myString);
    var stringReader = new StringReader(instructions);
    for (; ; )
    {
      var line = stringReader.ReadLine();
      if (line == null)
      {
        break;
      }

      if (state == States.ReadArea)
      {
        plateau = Area.Parse(line);
        if (plateau == null)
        {
          Console.WriteLine("Invalid area: " + line);
          return new List<Rover>();
        }
        state = States.ReadRover;
      }
      else if (state == States.ReadRover)
      {
        currentRover = Rover.Parse(line);
        if (currentRover == null)
        {
          Console.WriteLine("Invalid rover: " + line);
          return new List<Rover>();
        }
        rovers.Add(currentRover);
        state = States.DriveRover;
      }
      else if (state == States.DriveRover)
      {
        if (NavigationInstructions.IsInstructionsTextFormat(line))
        {
          var navInstructions = new NavigationInstructions(line);
          if (currentRover == null || plateau == null)
          {
            return new List<Rover>();
          }
          navInstructions.DriveRover(currentRover, plateau, rovers);
          state = States.ReadRover;
        }
      }
    }

    return rovers;
  }
}