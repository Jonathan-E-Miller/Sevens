using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace BJSS
{
  /// <summary>
  /// Enum to represent the different houses
  /// </summary>
  public enum House
  {
    eSpades = 0,
    eClubs,
    eHearts,
    eDiamonds,
    eInvalid
  }

  /// <summary>
  /// Enum to represent the different numbers
  /// </summary>
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

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="house">The house the card belongs to</param>
    /// <param name="number">The number of the card</param>
    public Card(House house, Number number)
    {
      House = house;
      Number = number;
    }

    /// <summary>
    /// Implementation of IEquatable interface for easier comparrisons with List<Card>
    /// </summary>
    /// <param name="other">The card to compare against</param>
    /// <returns></returns>
    public bool Equals([AllowNull] Card other)
    {
      return (this.House == other.House && this.Number == other.Number);
    }

    /// <summary>
    /// Override to string function to return a meaningful string representation of the object
    /// </summary>
    /// <returns>8H for eight of hearts</returns>
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
