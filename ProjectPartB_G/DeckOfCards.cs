using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public PlayingCard this[int idx] => null;
        public int Count => cards.Count;
        #endregion

        #region ToString() related
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int sa = 0;
            foreach (var item in cards)
            {
                sb.Append(item.ToString());
                sa++;
                if (sa == 13)
                {
                    sb.Append("\n");
                    sa = 0;
                }
            }          
            return sb.ToString();
        }
        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        {

            for (int i = 0; i < 100; i++)
            {
                Random rand = new Random();
                var r1 = rand.Next(0, cards.Count);
                PlayingCard store1;
                Random rand2 = new Random();
                var r2 = rand.Next(0, cards.Count);
                store1 = cards[r1];
                cards[r1] = cards[r2];
                cards[r2] = store1;
;           }
        }
        public void Sort()
        {
            cards.Sort();
        }
        #endregion

        #region Creating a fresh Deck
        public void Clear()
        { }
        public void CreateFreshDeck()
        {
            foreach (var item in Enum.GetValues(typeof(PlayingCardColor)))
            {
                foreach (var item2 in Enum.GetValues(typeof(PlayingCardValue)))
                {
                    PlayingCard nyttKort = new PlayingCard { Color = (PlayingCardColor)item, Value = (PlayingCardValue)item2};
                    cards.Add(nyttKort);
                }
            }
        }
        #endregion

        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        #endregion
    }
}
