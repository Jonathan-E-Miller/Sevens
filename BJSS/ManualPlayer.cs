using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BJSS
{
  public class ManualPlayer : Player
  {
    public ManualPlayer(string name) : base(name)
    {

    }

    public override Card MakeMove(Board currentBoard, out bool complete)
    {
      throw new NotImplementedException();
    }
  }
}
