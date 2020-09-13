using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BJSS
{
  public abstract class Player
  {
    private List<Card> _cards;

    public List<Card> Cards
    {
      get
      {
        return _cards;
      }
    }

    /// <summary>
    /// Create a new player
    /// </summary>
    /// <param name="auto">true if controller by the "AI"</param>
    /// <param name="clever">true if the player should make intelligent moves</param>
    public Player()
    {
      _cards = new List<Card>();
    }

    public abstract Card MakeMove(out bool complete);

    public bool HasSevenOfDiamonds()
    {
      return _cards.Where(c => c.House == House.eDiamonds && c.Number == Number.eSeven).Count() == 1;
    }
  }
}
