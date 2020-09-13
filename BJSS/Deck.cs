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
        if (h == House.eInvalid)
        {
          continue;
        }
        foreach (Number n in Enum.GetValues(typeof(Number)))
        {
          if (n == Number.eInvalid)
          {
            continue;
          }
          _cards[deckIndex++] = new Card(h, n);
        }
      }
    }

    /// <summary>
    /// Shuffle the array of cards using a Random number generator
    /// </summary>
    public void Shuffle()
    {
      Random r = new Random();
      _cards = _cards.OrderBy(x => r.Next()).ToArray();
    }

    /// <summary>
    /// Hands out cards equally amonst players
    /// </summary>
    /// <param name="players">The list of players</param>
    /// <param name="startPlayerIndex">The index of the first player</param>
    public void Handout(List<Player> players, int startPlayerIndex)
    {
      int cardNumber = 0;

      // while we still have cards to hand out
      while (cardNumber < DECKLEN)
      {
        // get the index of the next player
        int playerN = startPlayerIndex++ % players.Count;

        // assign the player the next card
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
