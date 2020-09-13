using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BJSS
{
  public abstract class Player
  {
    private List<Card> _cards;
    private string _name;
    private string _output;

    /// <summary>
    /// Create a new player
    /// </summary>
    /// <param name="auto">true if controller by the "AI"</param>
    /// <param name="clever">true if the player should make intelligent moves</param>
    public Player(string name)
    {
      Cards = new List<Card>();
      Name = name;
    }

    public List<Card> Cards { get => _cards; set => _cards = value; }
    public string Name { get => _name; set => _name = value; }
    public string Output { get => _output; set => _output = value; }

    /// <summary>
    /// Abstract method because all subclasses will have a seperate implementation.
    /// </summary>
    /// <param name="currentBoard">The current state of the board</param>
    /// <param name="complete">True if the Player has used all their cards</param>
    /// <returns>The card the Player wishes to play</returns>
    public abstract Card MakeMove(Board currentBoard, out bool complete);

    /// <summary>
    /// Returns and resets the Output text.
    /// </summary>
    /// <returns></returns>
    public string GetPlay()
    {
      string toReturn = _output;
      _output = "";
      return toReturn;
    }
  }
}
