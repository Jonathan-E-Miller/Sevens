using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace BJSS
{
  public enum House
  {
    eSpades = 0,
    eClubs,
    eHearts,
    eDiamonds,
    eInvalid
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
    eTen,
    eJack,
    eQueen,
    eKing,
    eAce,
    eInvalid
  }
  public class Card : IEquatable<Card>
  {
    private House _house;
    private Number _number;
    private bool _played;


    public bool Played { get => _played; set => _played = value; }
    public House House { get => _house; set => _house = value; }
    public Number Number { get => _number; set => _number = value; }

    public Card(House house, Number card)
    {
      House = house;
      Number = card;
    }

    public bool Equals([AllowNull] Card other)
    {
      return (this.House == other.House && this.Number == other.Number);
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();

      string numberStr = "";

      switch (Number)
      {
        case Number.eTwo:
        case Number.eThree:
        case Number.eFour:
        case Number.eFive:
        case Number.eSix:
        case Number.eSeven:
        case Number.eEight:
        case Number.eNine:
        case Number.eTen:
          numberStr = ((int)_number).ToString();
          break;
        case Number.eJack:
          numberStr = "J";
          break;
        case Number.eQueen:
          numberStr = "Q";
          break;
        case Number.eKing:
          numberStr = "K";
          break;
        case Number.eAce:
          numberStr = "A";
          break;
      }

      stringBuilder.Append(numberStr);
      
      string house = "";
      switch (House)
      {
        case House.eClubs:
          house = "C";
          break;
        case House.eDiamonds:
          house = "D";
          break;
        case House.eHearts:
          house = "H";
          break;
        case House.eSpades:
          house = "S";
          break;
        default:
          break;
      }
      stringBuilder.Append(house);
      return stringBuilder.ToString();
    }
  }
}
