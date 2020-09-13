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
      List<Player> players = new List<Player>()
      {
        // create a automated smart player
        new StandardPlayer("Player 1"),
        // create an automated standard player
        new StandardPlayer("Player 2"),
        // create a manual player
        new ManualPlayer("Player 3")
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
