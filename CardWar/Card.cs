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
                else if (value.Equals(3))
                {
                    picture += "3.png";
                }
                else if (value.Equals(4))
                {
                    picture += "4.png";
                }
                else if (value.Equals(5))
                {
                    picture += "5.png";
                }
                else if (value.Equals(6))
                {
                    picture += "6.png";
                }
                else if (value.Equals(7))
                {
                    picture += "7.png";
                }
                else if (value.Equals(8))
                {
                    picture += "8.png";
                }
            }
            return picture;
        }
    }
}
