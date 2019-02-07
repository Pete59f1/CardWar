using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWar
{
    public enum Suit
    {
        Clubs,
        Diamonds,
        Spades,
        Hearts
    }
    public class Card
    {
        private string displayName;
        private Suit suit;
        private int value;
        private string picture;
        public string DisplayName { get { return displayName; } set { displayName = value; } }
        public Suit Suit { get { return suit; } set { suit = value; } }
        public int Value { get { return value; } set { this.value = value; } }
        public string Picture { get { return picture; } set { picture = value; } }

        public static string ShortName(int value, Suit suit)
        {
            string shortName = "";

            if (value >= 2 && value <= 10)
            {
                shortName = value.ToString();
            }
            else if (value == 11)
            {
                shortName = "JACK ";
            }
            else if (value == 12)
            {
                shortName = "QUEEN ";
            }
            else if (value == 13)
            {
                shortName = "KING ";
            }
            else if (value == 14)
            {
                shortName = "ACE ";
            }
            return shortName + " " + Enum.GetName(typeof(Suit), suit);
        }

        public static string AddPicture(int value, Suit suit)
        {
            string picture = "";

            if (suit.Equals(Suit.Clubs))
            {
                picture = @"\CardWar\CardPic\Clubs";

                if (value.Equals(2))
                {
                    picture += "2.png";
                }
            }
            return picture;
        }
    }
}
