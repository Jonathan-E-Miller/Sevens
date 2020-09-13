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
        new SmartPlayer(),
        // create an automated standard player
        new StandardPlayer(),
        // create a manual player
        new ManualPlayer()
      };

      Deck deck = new Deck();
      deck.Shuffle();
      deck.Handout(_players, 0);
    }

    [TestCase]
    public void TestFindSevenOfDiamonds()
    {
      int found = 0;
      foreach (Player player in _players)
      {

        if (player.HasSevenOfDiamonds())
        {
          found++;
        }
      }
      Assert.AreEqual(1, found);
    }
  }
}
