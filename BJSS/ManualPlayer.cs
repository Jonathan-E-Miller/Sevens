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
      Card card = null;
      if (currentBoard.IsEmpty())
      {
        if (Cards.Where(c => c.Number == Number.eSeven && c.House == House.eDiamonds).Count() == 1)
        {
          card = Cards.Where(c => c.Number == Number.eSeven && c.House == House.eDiamonds).ToList()[0];
          Cards.Remove(card);
          Output = String.Format("You have automatically played the first card {0}", card.ToString());
        }
      }
      else
      {
        // get a list of cards I could play if I had them
        List<Card> options = currentBoard.GetOptions();

        List<Card> matches = new List<Card>();

        foreach (Card option in options)
        {
          if (Cards.Contains(option))
          {
            matches.Add(option);
          }
        }

        if (matches.Count != 0)
        {
          bool cardValid = false;
          while (!cardValid)
          {
            Console.WriteLine("Make Your Move... (type \"cards\" to see your cards");
            String input = Console.ReadLine();
            Card potentialCard = ParseInput(input);

            if (matches.Contains(potentialCard))
            {
              card = potentialCard;
              cardValid = true;
              Cards.Remove(card);
              break;
            }
          }
        }
      }

      complete = (Cards.Count == 0);
      return card;
    }

    public Card ParseInput(string input)
    {
      Card card = null;
      bool stillValid = true;

      if (input.Equals("cards", StringComparison.CurrentCultureIgnoreCase))
      {
        PrintCards();
      }
      else
      {
        if (input.Length > 3 || input.Length < 2)
        {
          Console.WriteLine("Invalid Input");
          stillValid = false;
        }

        Number number = Number.eInvalid;
        if (stillValid)
        {
          string numberStr = input.Substring(0, 2);
          
          number = GetInputCardNumber(input);
          if (number == Number.eInvalid)
          {
            Console.WriteLine("Invalid Input");
            stillValid = false;
          }

          House house = House.eInvalid;
          if (stillValid)
          {
             house = GetInputHouse(input);
            if (house == House.eInvalid)
            {
              Console.WriteLine("Invalid Input");
              stillValid = false;
            }
          }

          if (stillValid)
          {
            card = new Card(house, number);
          }
        }
      }
      return card;
    }

    private Number GetInputCardNumber(string input)
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

    private House GetInputHouse(string input)
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

    private void PrintCards()
    {
      Console.WriteLine("Your Cards Are...");
      foreach (Card card in Cards)
      {
        Console.Write(" {0} ", card.ToString());
      }
      Console.Write("\n");
    }
  }
}
