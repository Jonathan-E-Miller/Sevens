using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BJSS
{
  public class Board
  {
    private Dictionary<House, CurrentState> _currentBoard;
    public Dictionary<House, CurrentState> CurrentBoard
    {
      get
      {
        return _currentBoard;
      }
    }

    /// <summary>
    /// Create a new intance of our board.
    /// </summary>
    public Board()
    {
      _currentBoard = new Dictionary<House, CurrentState>()
      {
        { House.eClubs, new CurrentState() },
        { House.eDiamonds, new CurrentState() },
        { House.eHearts, new CurrentState() },
        { House.eSpades, new CurrentState() },
      };
    }

    public bool IsEmpty()
    {
      bool isEmpty = true;
      foreach (KeyValuePair<House, CurrentState> kvp in _currentBoard)
      {
        if ((kvp.Value.Max != null) || (kvp.Value.Min != null))
        {
          isEmpty = false;
          break;
        }
      }
      return isEmpty;
    }

    /// <summary>
    /// Algorirthm for adding a card to the board.
    /// </summary>
    /// <param name="card"></param>
    public void AddCard(Card card)
    {
      if (_currentBoard[card.House].Max == null && _currentBoard[card.House].Min == null)
      {
        _currentBoard[card.House].Max = card.Number;
      }
      else
      {
        int newValue = (int)card.Number;

        if (newValue > (int)_currentBoard[card.House].Max)
        {
          _currentBoard[card.House].Max = card.Number;
        }

        if (!_currentBoard[card.House].Min.HasValue)
        {
          if (newValue < (int)_currentBoard[card.House].Max)
          {
            _currentBoard[card.House].Min = card.Number;
          }
        }
        else
        {
          if (newValue < (int)_currentBoard[card.House].Min)
          {
            _currentBoard[card.House].Min = card.Number;
          }
        }
      }
    }

    public List<Card> GetOptions()
    {
      List<Card> options = new List<Card>();

      GetHouseOptions(House.eDiamonds).ForEach(o => options.Add(o));
      GetHouseOptions(House.eHearts).ForEach(o => options.Add(o));
      GetHouseOptions(House.eSpades).ForEach(o => options.Add(o));
      GetHouseOptions(House.eClubs).ForEach(o => options.Add(o));

      return options;
    }

    /// <summary>
    /// Get a list of cards that we can play for a specific house
    /// </summary>
    /// <param name="house"></param>
    /// <returns></returns>
    private List<Card> GetHouseOptions(House house)
    {
      List<Card> options = new List<Card>();

      CurrentState state = _currentBoard[house];
      bool cardsBeingPlayed = true;

      if (state.Max == null && state.Min == null)
      {
        options.Add(new Card(house, Number.eSeven));
        cardsBeingPlayed = false;
      }

      if (cardsBeingPlayed)
      {
        // a card has been played for this house.
        int minValue = state.Min.HasValue ? (int)state.Min : (int)Number.eSeven;
        int maxValue = (int)state.Max;

        minValue -= 1;
        maxValue += 1;
        Number nextMin = (Number)minValue;
        Number nextMax = (Number)maxValue;
        
        if (minValue >= (int)Number.eTwo)
        {
          options.Add(new Card(house, nextMin));
        }
        
        if (maxValue <= (int)Number.eAce)
        {
          options.Add(new Card(house, nextMax));
        }
      }

      return options;
    }
  }
}
