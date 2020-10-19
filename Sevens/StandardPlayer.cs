using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sevens
{
  public class StandardPlayer : Player
  {
    Random _random;
    public StandardPlayer(string name) : base(name)
    {
      _random = new Random();
    }

    /// <summary>
    /// StandardPlayer Implementation. Gets a list of cards that can be played and selects a random Card.
    /// </summary>
    /// <param name="currentBoard">The current state of the board</param>
    /// <param name="complete">True if all users cards have been used</param>
    /// <returns></returns>
    public override Card MakeMove(Board currentBoard, out bool complete)
    {
      Card card = null;
      if (currentBoard.IsEmpty())
      {
        if (GameUtils.HasSevenOfDiamonds(Cards))
        {
          card = Cards.Where(c => c.Number == Number.eSeven && c.House == House.eDiamonds).ToList()[0];
          Cards.Remove(card);
        }
      }
      else
      {
        // get a list of cards I could play if I had them
        List<Card> options = currentBoard.GetPlayableCards();

        List<Card> matches = MatchCards(options);

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
