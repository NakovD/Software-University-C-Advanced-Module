using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cardsUnparsed = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var validCards = new List<Card>();

            foreach (var cardDataUnparsed in cardsUnparsed)
            {
                var cardDataCollection = cardDataUnparsed.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var cardFace = cardDataCollection[0];
                var cardSuit = cardDataCollection[1];
                try
                {
                    var card = new Card(cardFace, cardSuit);
                    validCards.Add(card);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", validCards));
        }
    }

    public class Card
    {
        private static string[] validFaces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        private static string[] validSuits = new string[] { "S", "H", "D", "C" };

        private string face;

        public string Face
        {
            get => face;

            private set
            {
                if (!validFaces.Contains(value)) throw new ArgumentException("Invalid card!");
                face = value;
            }
        }

        private string suit;

        public string Suit
        {
            get => suit;

            private set
            {
                if (!validSuits.Contains(value)) throw new ArgumentException("Invalid card!");
                suit = value;
            }
        }

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"[{Face}{GetSuitSign()}]";
        }

        private string GetSuitSign()
        {
            switch (Suit)
            {
                case "S": return "\u2660";
                case "H": return "\u2665";
                case "D": return "\u2666";
                default: return "\u2663";
            }
        }
    }
}
