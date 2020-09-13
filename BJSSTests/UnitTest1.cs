using BJSS;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BJSSTests
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(House.eDiamonds, Number.eAce)]
    [TestCase(House.eHearts, Number.eFour)]
    [TestCase(House.eSpades, Number.eNine)]
    [TestCase(House.eClubs, Number.eKing)]
    [TestCase(House.eDiamonds, Number.eJack)]
    [TestCase(House.eHearts, Number.eThree)]
    public void TestDeck(House house, Number number)
    {
      Deck deck = new Deck();

      if (deck.Cards.Contains(null))
      {
        Assert.Fail("Deck contains null elements");
      }

      Card[] cards = deck.Cards;

      Card card = cards.ToList().Find(c => c.Number == number && c.House == house);

      Assert.IsNotNull(card);
    }

    [TestCase]
    public void TestShuffle()
    {
      Deck deck = new Deck();
      Card[] cards = deck.Cards;
      deck.Shuffle();

      bool match = true;
      for (int i = 0; i < cards.Length; i++)
      {
        if ((cards[i].House != deck.Cards[i].House) && (cards[i].Number != deck.Cards[i].Number))
        {
          match = false;
          break;
        }
      }

      Assert.IsFalse(match);
    }

    [TestCase]
    public void TestHandOut()
    {
      List<Player> players = new List<Player>()
      {
        new Player(false),
        new Player(false),
        new Player(true)
      };

      Deck deck = new Deck();
      deck.Shuffle();
      deck.Handout(players);

      double numberOfCards = ((double)52) / (double)players.Count;

      if (numberOfCards % 1 != 0)
      {
        int[] possibleValues = new int[2];
        possibleValues[0] = (int)numberOfCards;
        possibleValues[1] = (int)numberOfCards + 1;

        foreach(Player player in players)
        {
          bool match = possibleValues.Contains(player.Cards.Count);
          Assert.IsTrue(match);
        }
      }
      else
      {
        players.ForEach(p => Assert.AreEqual(p.Cards.Count, (int)numberOfCards));
      }
    }
  }
}