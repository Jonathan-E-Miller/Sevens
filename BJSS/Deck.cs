using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace BJSS
{
  public class Deck
  {
    private const int DECKLEN = 52;
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

    public void Handout(List<Player> players, int startPlayerIndex)
    {
      int cardNumber = 0;

      while (cardNumber < DECKLEN)
      {
        int playerN = startPlayerIndex++ % players.Count;

        players[playerN].Cards.Add(_cards[cardNumber++]);
      }
    }

    public void UpdateCard(Card card)
    {
      for (int i = 0; i < _cards.Count(); i++)
      {
        if (_cards[i].ToString() == card.ToString())
        {
          _cards[i].Played = true;
          break;
        }
      }
    }
  }
}
