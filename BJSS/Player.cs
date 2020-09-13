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

    public abstract Card MakeMove(Board currentBoard, out bool complete);
  }
}
