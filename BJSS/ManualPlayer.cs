using System;
using System.Collections.Generic;
using System.Text;

namespace BJSS
{
  public class ManualPlayer : Player
  {
    public ManualPlayer() : base()
    {

    }

    public override Card MakeMove(out bool complete)
    {
      throw new NotImplementedException();
    }
  }
}
