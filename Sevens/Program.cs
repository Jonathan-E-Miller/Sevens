using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sevens
{
  class Program
  {
    static void Main(string[] args)
    {
      // Get the name of the Manual player
      Console.WriteLine("Enter your name...");
      string name = Console.ReadLine();
      Console.Write("\n");

      // Create three players
      List<Player> players = new List<Player>()
      {
        // create a automated smart player
        new StandardPlayer("Standard Player"),
        // create an automated standard player
        new SmartPlayer("Smart Player"),
        // create a manual player
        new ManualPlayer(name)
      };

      // Create a card deck and Game.
      Deck deck = new Deck();
      Game game = new Game(deck, players);

      // while we do not have a winner, continue.
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
