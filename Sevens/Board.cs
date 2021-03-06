﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sevens
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

    /// <summary>
    /// Check to see if the board is empty
    /// </summary>
    /// <returns>True if the board is empty</returns>
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
      // if this is a new house being played, add the card to the max parameter.
      if (_currentBoard[card.House].Max == null && _currentBoard[card.House].Min == null)
      {
        _currentBoard[card.House].Max = card.Number;
      }
      // We already have some cards for this house.
      else
      {
        // get the new number for the card.
        int newValue = (int)card.Number;

        // if the new value is greater than the current maximum update the max value
        if (newValue > (int)_currentBoard[card.House].Max)
        {
          _currentBoard[card.House].Max = card.Number;
        }
        
        // The minimum value might not yet be set.
        if (!_currentBoard[card.House].Min.HasValue)
        {
          // as it is not set, we need to check against the max value
          if (newValue < (int)_currentBoard[card.House].Max)
          {
            _currentBoard[card.House].Min = card.Number;
          }
        }
        else
        {
          // check against the minimum value and update.
          if (newValue < (int)_currentBoard[card.House].Min)
          {
            _currentBoard[card.House].Min = card.Number;
          }
        }
      }
    }

    public List<Card> GetPlayableCards()
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
