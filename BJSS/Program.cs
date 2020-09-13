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
        new StandardPlayer("Player 3")
      };

      Deck deck = new Deck();
      Game game = new Game(deck, players);

      bool winner = false;

      while (!winner)
      {
        Console.Clear();
        PrintPlayerScores(game.GetPlayerInformation());
        PrintDeck(deck);
        Thread.Sleep(500);
        winner = game.PlayRound();
      }
    }

    private static void PrintPlayerScores(List<Player> players)
    {
      players.ForEach(p => Console.WriteLine("{0}:\t {1} Cards Remaining", p.Name, p.Cards.Count));
    }

    private static void PrintDeck(Deck deck)
    {
      List<List<Card>> toDraw = new List<List<Card>>();
      for (int i = 0; i < 13; i++)
      {
        int temp = i + 2;
        List<Card> toPrint = deck.Cards.Where(d => d.Number == (Number)temp).ToList();

        PrintCard(toPrint.Find(p => p.House == House.eHearts));
        PrintCard(toPrint.Find(p => p.House == House.eDiamonds));
        PrintCard(toPrint.Find(p => p.House == House.eSpades));
        PrintCard(toPrint.Find(p => p.House == House.eClubs));
        Console.Write("\n");
      }
    }

    public static void PrintCard(Card c)
    {
      Console.Write(" ");
      if (c.Played)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(c.ToString());
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(c.ToString());
      }
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write(" ");
    }
  }
}
