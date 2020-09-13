using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BJSS
{
  public class SmartPlayer : Player
  {
    private Random _random;
    public SmartPlayer(string name) : base(name)
    {
      _random = new Random();
    }

    /// <summary>
    /// SmartPlayer Implementaion. Will try and hold onto "seven" cards for as long as possible
    /// providing it does not have more than 3 cards within that house.
    /// </summary>
    /// <param name="currentBoard">The state of the current board</param>
    /// <param name="complete">True if all Player cards have been used</param>
    /// <returns></returns>
    public override Card MakeMove(Board currentBoard, out bool complete)
    {
      Card card = null;

      // if the board is empty, we have to play 7D
      if (currentBoard.IsEmpty())
      {
        if (Cards.Where(c => c.Number == Number.eSeven && c.House == House.eDiamonds).Count() == 1)
        {
          card = Cards.Where(c => c.Number == Number.eSeven && c.House == House.eDiamonds).ToList()[0];
          Cards.Remove(card);
        }
      }
      else
      {
        // Get a list of cards I could play if I had them
        List<Card> options = currentBoard.GetOptions();

        // If we have an option card in our personal deck, then add to matches list
        List<Card> matches = new List<Card>();
        foreach (Card option in options)
        {
          if (Cards.Contains(option))
          {
            matches.Add(option);
          }
        }

        // if we have a card to play
        if (matches.Count > 0)
        {
          List<Card> toKeep = new List<Card>();
          for (int i = matches.Count-1; i >= 0; i--)
          {
            // If we have a seven but not many other cards in that house, then save it to delay other players.
            if ( (matches[i].Number == Number.eSeven) && CheckCount(matches[i]) >= 3)
            {
              toKeep.Add(matches[i]);
              matches.RemoveAt(i);
            }
          }

          // Use matches first.
          if (matches.Count > 0)
          {
            int index = _random.Next(0, matches.Count);

            card = matches[index];
            Cards.Remove(card);
          }
          else
          {
            // We do not have any matches so we will have to use our keeper cards.
            int index = _random.Next(0, toKeep.Count);

            card = toKeep[index];
            Cards.Remove(card);
          }
        }
      }
      complete = Cards.Count == 0;
      return card;
    }

    /// <summary>
    /// Counts how many cards we have in the suite.
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    private int CheckCount(Card card)
    {
      return Cards.Where(c => c.House == card.House).Count();
    }
  }
}
