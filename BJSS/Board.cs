using System;
using System.Collections.Generic;
using System.Text;

namespace BJSS
{
  public class Board
  {
    private Dictionary<House, CurrentState> _currentBoard;
    public Dictionary<House, CurrentState> CurrentBoard
    {
      get
      {
        return _currentBoard;
      }
    }

    /// <summary>
    /// Create a new intance of our board.
    /// </summary>
    public Board()
    {
      _currentBoard = new Dictionary<House, CurrentState>()
      {
        { House.eClubs, new CurrentState() },
        { House.eDiamonds, new CurrentState() },
        { House.eHearts, new CurrentState() },
        { House.eSpades, new CurrentState() },
      };
    }

    public bool IsEmpty()
    {
      bool isEmpty = true;
      foreach (KeyValuePair<House, CurrentState> kvp in _currentBoard)
      {
        if ((kvp.Value.Max != null) || (kvp.Value.Min != null))
        {
          isEmpty = false;
          break;
        }
      }
      return isEmpty;
    }
  }
}
