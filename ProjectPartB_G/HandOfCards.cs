using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        #region Pick and Add related

        private PlayingCard _Highest;
        private PlayingCard _Lowest;

        public void Add(PlayingCard card)
        {
            if (_Highest == null && _Lowest == null)
            {
                _Highest = card;
                _Lowest = card;
            }

            if (card.Value > _Highest.Value)
            {
                _Highest = card;
            } else if (card.Value < _Highest.Value)
            {
                _Lowest = card;
            }
        }
        #endregion

        #region Highest Card related
        public PlayingCard Highest
        {
            get
            {
               return _Highest;
            }
         }
        public PlayingCard Lowest
        {
            get
            {
               return _Lowest;
            }
        }
        #endregion
    }
}
