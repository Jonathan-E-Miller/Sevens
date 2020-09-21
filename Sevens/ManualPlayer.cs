using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sevens
{
  public class ManualPlayer : Player
  {
    public ManualPlayer(string name) : base(name)
    {

    }

    /// <summary>
    /// Make a manual move.
    /// </summary>
    /// <param name="currentBoard">The current board</param>
    /// <param name="complete">true if we have used all our cards</param>
    /// <returns></returns>
    public override Card MakeMove(Board currentBoard, out bool complete)
    {
      Card card = null;

      // if the board is empty, we have to play a 7D if we have it.
      if (currentBoard.IsEmpty())
      {
        if (Cards.Where(c => c.Number == Number.eSeven && c.House == House.eDiamonds).Count() == 1)
        {
          card = Cards.Where(c => c.Number == Number.eSeven && c.House == House.eDiamonds).ToList()[0];
          Cards.Remove(card);
          Output = String.Format("You have automatically played the first card {0}", card.ToString());
        }
      }
      // The game has started...
      else
      {
       // Get a list of all the cards we could play based on the current board state
        List<Card> options = currentBoard.GetOptions();

        // Go through our cards and if it is an option, add it to our matches list.
        List<Card> matches = new List<Card>();
        foreach (Card option in options)
        {
          if (Cards.Contains(option))
          {
            matches.Add(option);
          }
        }

        // if we have a valid card we can play
        if (matches.Count != 0)
        {
          bool cardValid = false;
          // Keep going until we get a valid card
          while (!cardValid)
          {
            // Request user input
            Console.WriteLine("Make Your Move... (type \"cards\" to see your cards or \"matches\" to see matches)");
            String input = Console.ReadLine();
            
            // Parse the input, will return null if invalid
            Card potentialCard = ParseInput(input, matches);

            // Check that the card is valid based on the current board
            if (matches.Contains(potentialCard))
            {
              // card is valid so remove it from our list of Cards and break from the while loop.
              card = potentialCard;
              cardValid = true;
              Cards.Remove(card);
              break;
            }
          }
        }
      }

      // If we do not have any cards left, we are complete.
      complete = (Cards.Count == 0);
      return card;
    }

    /// <summary>
    /// Parse the input provided by the user
    /// </summary>
    /// <param name="input">The string provided by the user</param>
    /// <param name="matches">List of cards that we can play - can be null (for testing)</param>
    /// <returns></returns>
    public Card ParseInput(string input, List<Card> matches = null)
    {
      Card card = null;
      bool stillValid = true;

      bool commandReceived = false;

      // Handle the "cards" command
      if (input.Equals("cards", StringComparison.CurrentCultureIgnoreCase))
      {
        PrintCards(Cards);
        commandReceived = true;
      }

      // Handle the "matches" command
      if (input.Equals("matches", StringComparison.CurrentCultureIgnoreCase))
      {
        PrintCards(matches);
        commandReceived = true;
      }
      
      // If we haven't just processed a command
      if (!commandReceived)
      {
        // Check that the input length is valid
        if (input.Length > 3 || input.Length < 2)
        {
          Console.WriteLine("Invalid Input");
          stillValid = false;
        }

        Number number = Number.eInvalid;
        if (stillValid)
        {
          // Get the card number and ensure that it is valid
          number = GetInputCardNumber(input);
          if (number == Number.eInvalid)
          {
            Console.WriteLine("Invalid Input");
            stillValid = false;
          }

          // Get the house and check that it is valid
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

          // if we have got this far, all is good. Set the value to return.
          if (stillValid)
          {
            card = new Card(house, number);
          }
        }
      }
      return card;
    }

    /// <summary>
    /// Gets the Number of the requested card
    /// </summary>
    /// <param name="input">The string the user has inputted to the Console</param>
    /// <returns>The Number Enum</returns>
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

    /// <summary>
    /// Gets the House of the requested Card
    /// </summary>
    /// <param name="input">The string the user has inputted to the console</param>
    /// <returns>The House Enum</returns>
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

    /// <summary>
    /// Print cards to the console
    /// </summary>
    /// <param name="cards">The cards to print</param>
    private void PrintCards(List<Card> cards)
    {
      Console.WriteLine("Your Cards Are...");
      foreach (Card card in cards)
      {
        Console.Write(" {0} ", card.ToString());
      }
      Console.Write("\n");
    }
  }
}
