using System;
using System.Collections.Generic;
using System.Text;

namespace BJSS
{
  public class StandardPlayer : Player
  {
    public StandardPlayer() : base()
    {

    }

    public override Card MakeMove(Board currentBoard, out bool complete)
    {
      throw new NotImplementedException();
    }
  }
}
