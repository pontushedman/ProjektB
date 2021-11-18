using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
	public class PlayingCard:IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		#region IComparable Implementation
		//Need only to compare value in the project
		public int CompareTo(PlayingCard card1)
        {
            if (this.Value > card1.Value)
            {
                return 1;
            } else if(this.Value < card1.Value) 
            {
                return -1;
            } else
            {
                return 0;
            }        
        }
		#endregion

        #region ToString() related
		string ShortDescription
		{
			//Use switch statment or switch expression
			//https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
			get
			{
                switch (Color)
                {
                    case PlayingCardColor.Clubs:
                        return "\u2663 " + Value + " ";
                        
                    case PlayingCardColor.Diamonds:
                        return "\u2666 " + Value + " ";

                    case PlayingCardColor.Hearts:
                        return "\u2665 " + Value + " ";

                    case PlayingCardColor.Spades:
                        return "\u2660 " + Value + " ";
                    default:
                        return "";
                }
            }
		}

		public override string ToString() => ShortDescription;
        #endregion

    }
}
