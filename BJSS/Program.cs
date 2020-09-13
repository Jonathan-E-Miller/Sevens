using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BJSS
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Enter your name...");
      string name = Console.ReadLine();
      Console.Write("\n");

      List<Player> players = new List<Player>()
      {
        // create a automated smart player
        new StandardPlayer("Standard Player"),
        // create an automated standard player
        new SmartPlayer("Smart Player"),
        // create a manual player
        new ManualPlayer(name)
      };

      Deck deck = new Deck();
      Game game = new Game(deck, players);

      bool complete = false;

      while (!complete)
      {
        Thread.Sleep(2000);
        complete = game.Update();
        Console.Clear();
        game.Draw();
      }
    }

   
  }
}
