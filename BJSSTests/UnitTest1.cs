using BJSS;
using NUnit.Framework;
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

      Card[] cards = deck.Cards;

      Card card = cards.ToList().Find(c => c.Number == number && c.House == house);

      Assert.IsNotNull(card);

    }
  }
}