using System;
using System.Collections.Generic;
using System.Text;

namespace BJSS
{
  public class Game
  {
    public Card[,] _board;
    public List<Player> _players;

    public Game()
    {
      // create a 4x2 array for the 4 houses and current min and max card.
      _board = new Card[4,2];
      _players = new List<Player>()
      {
        // create a automated smart player
        new SmartPlayer(),
        // create an automated standard player
        new StandardPlayer(),
        // create a manual player
        new ManualPlayer()
      };
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
      deck.Handout(_players);
    }
  }
}
