using BJSS;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BJSSTests
{
  public class PlayerTests
  {
    private List<Player> _players;
    [SetUp]
    public void SetUp()
    {
      _players = new List<Player>()
      {
        // create a automated smart player
        new SmartPlayer("Player 1"),
        // create an automated standard player
        new StandardPlayer("Player 2"),
        // create a manual player
        new ManualPlayer("Player 3")
      };

      Deck deck = new Deck();
      deck.Shuffle();
      deck.Handout(_players, 0);
    }
  }
}
