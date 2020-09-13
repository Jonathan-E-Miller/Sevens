using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BJSS
{
  public class StandardPlayer : Player
  {
    Random _random;
    public StandardPlayer(string name) : base(name)
    {
      _random = new Random();
    }

    public override Card MakeMove(Board currentBoard, out bool complete)
    {
      Card card = null;
      if (currentBoard.IsEmpty())
      {
        if (Cards.Where(c=>c.Number == Number.eSeven && c.House == House.eDiamonds).Count() == 1)
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
          int index = _random.Next(0, matches.Count);

          card = matches[index];
          Cards.Remove(card);
        }
      }
      complete = Cards.Count == 0;
      return card;
    }
  }
}
