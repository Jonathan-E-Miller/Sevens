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
      string name = GameUtils.GetPlayerName();
      // Create three players
      List<Player> players = GameUtils.GenerateDefaultPlayers(name);
      
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
