using System;
using System.Collections.Generic;
using System.Text;

namespace BJSS
{
  public class Player
  {
    private bool _auto;
    private bool _clever;
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
    public Player(bool auto, bool clever=false)
    {
      _auto = auto;
      _clever = clever;
      _cards = new List<Card>();
    }

    /// <summary>
    /// Make an intelligent move
    /// </summary>
    /// <returns>The card to play</returns>
    public Card MakeSmartMove()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>The card to play</returns>
    public Card MakeFirstMove()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Make a manual move
    /// </summary>
    /// <returns>The card to play</returns>
    public Card MakePlayerMove()
    {
      throw new NotImplementedException();
    }
  }
}
