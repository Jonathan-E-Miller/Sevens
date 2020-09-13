using System;
using System.Collections.Generic;
using System.Text;

namespace BJSS
{
  public class Game
  {
    private Deck _deck;
    private Board _board;
    private List<Player> _players;
    private int _startPlayerIndex;

    public Game(Deck deck, List<Player> players)
    {
      // create a new board object for our game
      _board = new Board();
      
      // assign our deck of cards and player list
      _deck = deck;
      _players = players;
      _startPlayerIndex = 0;
      AssignCards();
    }

    /// <summary>
    ///  Run the game loop
    /// </summary>
    public bool PlayRound()
    {
      int moves = 0;
      bool winner = false;
      foreach (Player p in _players)
      {
        Card card = p.MakeMove(_board, out winner);          // if the player has a card to play, add it to the board.
        if (card != null)
        {
          moves++;
          _board.AddCard(card);
          _deck.UpdateCard(card);
        }

        if (winner)
        {
          break;
        }
      }
      return winner;
    }

    public void AssignCards()
    {
      _deck.Shuffle();
      _deck.Handout(_players, _startPlayerIndex);
      _startPlayerIndex++;
    }

    public List<Player> GetPlayerInformation()
    {
      return _players;
    }

    public Board GetBoard()
    {
      return _board;
    }
  }
}
