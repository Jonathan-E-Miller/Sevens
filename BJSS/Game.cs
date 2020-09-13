using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BJSS
{
  public class Game
  {
    private Deck _deck;
    private Board _board;
    private List<Player> _players;
    private int _currentPlayerIndex;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="deck">The deck of cards being used for the game</param>
    /// <param name="players">The players</param>
    public Game(Deck deck, List<Player> players)
    {
      // create a new board object for our game
      _board = new Board();

      // assign our deck of cards and player list
      _deck = deck;
      _players = players;
      _currentPlayerIndex = 0;
      AssignCards();
    }

    /// <summary>
    /// The games update method
    /// </summary>
    /// <returns></returns>
    public bool Update()
    {
      return PlayCard();
    }

    /// <summary>
    /// The games draw method.
    /// </summary>
    public void Draw()
    {
      PrintPlayerScores(GetPlayerInformation());
      PrintDeck();
      PrintPlayerOutput();
    }

    /// <summary>
    ///  Run the game loop
    /// </summary>
    /// <returns>True if the player has won</returns>
    private bool PlayCard()
    {
      IncrementPlayer();
      bool winner = false;
      Player p = _players[_currentPlayerIndex];
      Card card = p.MakeMove(_board, out winner);
      // if the player has a card to play, add it to the board.
      if (card != null)
      {
        _board.AddCard(card);
        // update the card so we know it has been played
        _deck.UpdateCard(card);
        // set any output for the player
        p.Output = String.Format("{0} has played {1}", p.Name, card.ToString());
        
        // if we have won append to the output
        if (winner)
        {
          p.Output += " and was won the game";
        }
      }
      else
      {
        p.Output = String.Format("{0} has passed", p.Name);
      }
      return winner;
    }
    
    #region Public Methods
    /// <summary>
    /// Gets the current player in the game
    /// </summary>
    /// <returns>The current player</returns>
    public Player GetCurrentPlayer()
    {
      return _players[_currentPlayerIndex];
    }
    #endregion

    #region Private Methods
    private void AssignCards()
    {
      _deck.Shuffle();
      _deck.Handout(_players, _currentPlayerIndex);
      IncrementPlayer();
    }

    private void IncrementPlayer()
    {
      _currentPlayerIndex = ++_currentPlayerIndex % _players.Count;
    }

    private List<Player> GetPlayerInformation()
    {
      return _players;
    }
    #endregion

    #region Draw Methods
    /// <summary>
    /// Prints the current player scores to the Console.
    /// </summary>
    /// <param name="players"></param>
    private void PrintPlayerScores(List<Player> players)
    {
      players.ForEach(p => Console.WriteLine("{0}:\t {1} Cards Remaining", p.Name, p.Cards.Count));
    }

    /// <summary>
    /// Prints the deck being used for the game
    /// </summary>
    private void PrintDeck()
    {
      List<List<Card>> toDraw = new List<List<Card>>();
      for (int i = 0; i < 13; i++)
      {
        int temp = i + 2;
        List<Card> toPrint = _deck.Cards.Where(d => d.Number == (Number)temp).ToList();

        PrintCard(toPrint.Find(p => p.House == House.eHearts));
        PrintCard(toPrint.Find(p => p.House == House.eDiamonds));
        PrintCard(toPrint.Find(p => p.House == House.eSpades));
        PrintCard(toPrint.Find(p => p.House == House.eClubs));
        Console.Write("\n");
      }
    }

    /// <summary>
    /// Print the output for the current player
    /// </summary>
    private void PrintPlayerOutput()
    {
      Console.WriteLine(_players[_currentPlayerIndex].GetPlay());
    }

    /// <summary>
    /// Print a specific Card to the Console
    /// </summary>
    /// <param name="c">The card to print</param>
    private void PrintCard(Card c)
    {
      Console.Write("\t");
      // if the card has been played, set the output to green.
      if (c.Played)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(c.ToString());
      }
      else
      {
        // if the card is yet to be played, set the output to red.
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(c.ToString());
      }
      // go backt to white console output.
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("\t");
    }
    #endregion
  }
}