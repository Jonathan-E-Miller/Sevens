using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace BJSS
{
  public class Deck
  {
    private Card[] _cards;

    public Card[] Cards { get => _cards; }

    public Deck()
    {
      _cards = new Card[52];
      CreateDeck();
    }

    /// <summary>
    /// Create a new deck of cards
    /// </summary>
    private void CreateDeck()
    {
      int deckIndex = 0;
      foreach (House h in Enum.GetValues(typeof(House)))
      {
        foreach (Number n in Enum.GetValues(typeof(Number)))
        {
          _cards[deckIndex++] = new Card(h, n);
        }
      }
    }

    public void Shuffle()
    {
      Random r = new Random();
      _cards = _cards.OrderBy(x => r.Next()).ToArray();
    }

    public void Handout(List<Player> players)
    {
      throw new NotImplementedException();
    }
  }
}
