using System;
using System.IO;
using MarsRover.RoverNav;

namespace MarsRover;
public static class MarsRover
{
  public static void Main(string[] args)
  {
    var instructions = File.ReadAllText("./test-files/rover-instructions.txt");
    var rovers = Mars.DriveRovers(instructions);
    if (rovers.Count == 0) {
      System.Console.WriteLine("Invalid instructions");
      return;
    }
    System.Console.WriteLine("Final rover positions:");
    rovers.ForEach(System.Console.WriteLine);
  }
}
