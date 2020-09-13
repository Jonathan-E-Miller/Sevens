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

    public override Card MakeMove(Board currentBoard, out bool complete)
    {
      Card card = null;
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
        // get a list of cards I could play if I had them
        List<Card> options = currentBoard.GetOptions();

        List<Card> matches = new List<Card>();

        foreach (Card option in options)
        {
          if (Cards.Contains(option))
          {
            matches.Add(option);
          }
        }
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

          if (matches.Count > 0)
          {
            int index = _random.Next(0, matches.Count);

            card = matches[index];
            Cards.Remove(card);
          }
          else
          {
            int index = _random.Next(0, toKeep.Count);

            card = toKeep[index];
            Cards.Remove(card);
          }
        }
      }
      complete = Cards.Count == 0;
      return card;
    }

    public int CheckCount(Card card)
    {
      return Cards.Where(c => c.House == card.House).Count();
    }
  }
}
