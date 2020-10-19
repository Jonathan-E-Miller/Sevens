using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sevens
{
  public static class GameUtils
  {
    public static string GetPlayerName()
    {
      // Get the name of the Manual player
      Console.WriteLine("Enter your name...");
      string name = Console.ReadLine();
      Console.Write("\n");

      return name;
    }

    public static bool HasSevenOfDiamonds(List<Card> cards)
    {
      return cards.Where(c => c.Number == Number.eSeven && c.House == House.eDiamonds).Count() == 1;
    }

    public static List<Player> GenerateDefaultPlayers(string name)
    {
      List<Player> players = new List<Player>()
      {
        // create a automated smart player
        new StandardPlayer("Standard Player"),
        // create an automated standard player
        new SmartPlayer("Smart Player"),
        // create a manual player
        new ManualPlayer(name)
      };

      return players;
    }

    /// <summary>
    /// Gets the Number of the requested card
    /// </summary>
    /// <param name="input">The string the user has inputted to the Console</param>
    /// <returns>The Number Enum</returns>
    public static Number GetInputCardNumber(string input)
    {
      Number number;
      string numberStr = "";
      if (input.Length == 3)
      {
        numberStr = input.Substring(0, 2);
      }
      else
      {
        numberStr = input[0].ToString();
      }

      switch (numberStr)
      {
        case "2":
        case "3":
        case "4":
        case "5":
        case "6":
        case "7":
        case "8":
        case "9":
        case "10":
          {
            int intValue = Int32.Parse(numberStr);
            number = (Number)intValue;
          }
          break;
        case "k":
        case "K":
          {
            number = Number.eKing;
          }
          break;
        case "q":
        case "Q":
          {
            number = Number.eQueen;
          }
          break;
        case "j":
        case "J":
          {
            number = Number.eJack;
          }
          break;
        case "a":
        case "A":
          {
            number = Number.eAce;
          }
          break;

        default:
          number = Number.eInvalid;
          break;
      }

      return number;
    }

    /// <summary>
    /// Gets the House of the requested Card
    /// </summary>
    /// <param name="input">The string the user has inputted to the console</param>
    /// <returns>The House Enum</returns>
    public static House GetInputHouse(string input)
    {
      House house;
      string houseStr = "";

      if (input.Length == 3)
      {
        houseStr = input.Substring(2, 1);
      }
      else
      {
        houseStr = input[1].ToString();
      }
      switch (houseStr)
      {
        case "s":
        case "S":
          {
            house = House.eSpades;
          }
          break;
        case "h":
        case "H":
          {
            house = House.eHearts;
          }
          break;
        case "c":
        case "C":
          {
            house = House.eClubs;
          }
          break;
        case "d":
        case "D":
          {
            house = House.eDiamonds;
          }
          break;
        default:
          house = House.eInvalid;
          break;
      }
      return house;
    }
  }
}
