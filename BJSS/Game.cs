using System;
using System.Collections.Generic;
using System.Text;

namespace BJSS
{
  public class Game
  {
    private Board _board;
    private List<Player> _players;
    private int _startPlayerIndex;

    public Game()
    {
      // create a new board object for our game
      _board = new Board();
      _players = new List<Player>()
      {
        // create a automated smart player
        new SmartPlayer(),
        // create an automated standard player
        new StandardPlayer(),
        // create a manual player
        new ManualPlayer()
      };
      _startPlayerIndex = 0;
    }

    /// <summary>
    ///  Run the game loop
    /// </summary>
    public void Play()
    {
      throw new NotImplementedException();
    }

    public void AssignCards()
    {
      Deck deck = new Deck();
      deck.Shuffle();
      deck.Handout(_players, _startPlayerIndex);
      _startPlayerIndex++;
    }
  }
}
