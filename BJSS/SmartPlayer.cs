using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BJSS
{
  public class SmartPlayer : Player
  {
    public SmartPlayer(string name) : base(name)
    {

    }

    public override Card MakeMove(Board currentBoard, out bool complete)
    {
      throw new NotImplementedException();
    }
  }
}
