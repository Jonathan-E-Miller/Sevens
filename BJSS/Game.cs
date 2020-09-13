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
    private bool PlayCard()
    {
      IncrementPlayer();
      bool winner = false;
      Player p = _players[_currentPlayerIndex];
      Card card = p.MakeMove(_board, out winner);          // if the player has a card to play, add it to the board.
      if (card != null)
      {
        _board.AddCard(card);
        _deck.UpdateCard(card);
        p.Output = String.Format("{0} has played {1}", p.Name, card.ToString());
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
    private void PrintPlayerScores(List<Player> players)
    {
      players.ForEach(p => Console.WriteLine("{0}:\t {1} Cards Remaining", p.Name, p.Cards.Count));
    }

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

    private void PrintPlayerOutput()
    {
      Console.WriteLine(_players[_currentPlayerIndex].GetPlay());
    }

    private void PrintCard(Card c)
    {
      Console.Write("\t");
      if (c.Played)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(c.ToString());
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(c.ToString());
      }
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("\t");
    }
    #endregion
  }
}