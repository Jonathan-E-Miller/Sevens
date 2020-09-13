using System;
using System.Collections.Generic;
using System.Text;

namespace BJSS
{
  public enum House
  {
    eSpades = 0,
    eClubs,
    eHearts,
    eDiamonds
  }

  public enum Number
  {
    eTwo = 2,
    eThree,
    eFour,
    eFive,
    eSix,
    eSeven,
    eEight,
    eNine,
    eJack,
    eQueen,
    eKing,
    eAce
  }
  public class Card
  {
    private House _house;
    private Number _number;
    public Card(House house, Number card)
    {
      _house = house;
      _number = card;
    }
  }
}
