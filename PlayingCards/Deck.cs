using PlayingCards.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayingCards
{
	public class Deck
	{
		public List<ICard> AllCards { get; }
		public List<ICard> Spades { get; }
		public List<ICard> Hearts { get; }
		public List<ICard> Diamonds { get; }
		public List<ICard> Clubs { get; }

		public Deck(List<ICard> cards)
		{
			AllCards = cards;
			Spades = cards.Where(x => x.Suit.Name == "Spade")?.ToList();
			Hearts = cards.Where(x => x.Suit.Name == "Heart")?.ToList();
			Diamonds = cards.Where(x => x.Suit.Name == "Diamond")?.ToList();
			Clubs = cards.Where(x => x.Suit.Name == "Club")?.ToList();
		}

		public int TotalCardsCount => Spades.Count + Hearts.Count + Diamonds.Count + Clubs.Count;
	}
}
