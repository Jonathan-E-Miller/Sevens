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
        if (GameUtils.HasSevenOfDiamonds(Cards))
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
        List<Card> options = currentBoard.GetPlayableCards();

        // Go through our cards and if it is an option, add it to our matches list.
        List<Card> matches = MatchCards(options);

        // if we have a valid card we can play
        if (matches.Count != 0)
        {
          card = SelectCard(matches);
        }
        complete = (Cards.Count == 0);
        return card;
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
          number = GameUtils.GetInputCardNumber(input);
          if (number == Number.eInvalid)
          {
            Console.WriteLine("Invalid Input");
            stillValid = false;
          }

          // Get the house and check that it is valid
          House house = House.eInvalid;
          if (stillValid)
          {
            house = GameUtils.GetInputHouse(input);
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

    private Card SelectCard(List<Card> matches)
    {
      Card card = null;
      bool cardValid = false;
      // Keep going until we get a valid card
      while (!cardValid)
      {
        // Request user input
        Console.WriteLine("Make Your Move... (type \"cards\" to see your cards or \"matches\" to see matches)");
        String input = Console.ReadLine();

        // Parse the input, will return null if invalid
        card = ParseInput(input, matches);

        // Check that the card is valid based on the current board
        if (matches.Contains(card))
        {
          // card is valid so remove it from our list of Cards and break from the while loop.
          cardValid = true;
          Cards.Remove(card);
        }
      }
      return card;
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
