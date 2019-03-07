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
                shortName = "JACK";
            }
            else if (value == 12)
            {
                shortName = "QUEEN";
            }
            else if (value == 13)
            {
                shortName = "KING";
            }
            else
            {
                shortName = "ACE";
            }
            return shortName + " of " + Enum.GetName(typeof(Suit), suit);
        }

        public static string AddPicture(int value, Suit suit)
        {
            string picture = "";

            if (suit.Equals(Suit.Clubs))
            {
                picture = @"\CardWar\CardImages\Clubs";
            }
            else if (suit.Equals(Suit.Spades))
            {
                picture = @"\CardWar\CardImages\Spades";
            }
            else if (suit.Equals(Suit.Hearts))
            {
                picture = @"\CardWar\CardImages\Hearts";
            }
            else
            {
                picture = @"\CardWar\CardImages\Diamonds";
            }
            return picture + PictureHelper(value);
        }
        private static string PictureHelper(int value)
        {
            string picture = "";
            if (value >= 2 && value <= 10)
            {
                picture += value + ".png";
            }
            else if (value == 11)
            {
                picture += "JACK.png";
            }
            else if (value == 12)
            {
                picture += "QUEEN.png";
            }
            else if (value == 13)
            {
                picture += "KING.png";
            }
            else
            {
                picture += "ACE.png";
            }
            return picture;
        }
    }
}
