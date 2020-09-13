using System;
using System.Collections.Generic;
using System.Text;

namespace BJSS
{
  /// <summary>
  /// A simple class to represent the current state of a Card collection on the board.
  /// </summary>
  public class CurrentState
  {
    // The smallest number on the board
    public Number? Min;
    // The largest number on the board
    public Number? Max;

    public CurrentState()
    {
      Min = null;
      Max = null;
    }
  }
}
