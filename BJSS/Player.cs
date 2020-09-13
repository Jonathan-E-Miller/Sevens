using System;
using System.Collections.Generic;
using System.Text;

namespace BJSS
{
  public class Player
  {
    private bool _auto;

    /// <summary>
    /// Create a new player
    /// </summary>
    /// <param name="auto">true if controller by the "AI"</param>
    public Player(bool auto)
    {
      _auto = auto;
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
