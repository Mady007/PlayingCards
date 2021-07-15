using PlayingCards.Definitions;
using PlayingCards.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayingCards.Factory
{
	public class CardsFactory : ICardsFactory
	{
		public List<ICard> CreateCards()
		{
			var cards = new List<ICard>();
			cards.AddRange(CreateSpades());
			cards.AddRange(CreateHearts());
			cards.AddRange(CreateDiamonds());
			cards.AddRange(CreateClubs());

			return cards;
		}

		public List<ICard> CreateSpades()
		{
			return GetCards("Spade", "Black");
		}

		public List<ICard> CreateHearts()
		{
			return GetCards("Heart", "Red");
		}

		public List<ICard> CreateClubs()
		{
			return GetCards("Club", "Black");
		}

		public List<ICard> CreateDiamonds()
		{
			return GetCards("Diamond", "Red");
		}

		private List<ICard> GetCards(string suitName, string suitColor)
		{
			Card Ace = new Card("Ace", 1, new Suit(suitName, suitColor));
			Card Two = new Card("2", 2, new Suit(suitName, suitColor));
			Card Three = new Card("3", 3, new Suit(suitName, suitColor));
			Card Four = new Card("4", 4, new Suit(suitName, suitColor));
			Card Five = new Card("5", 5, new Suit(suitName, suitColor));
			Card Six = new Card("6", 6, new Suit(suitName, suitColor));
			Card Seven = new Card("7", 7, new Suit(suitName, suitColor));
			Card Eight = new Card("8", 8, new Suit(suitName, suitColor));
			Card Nine = new Card("9", 9, new Suit(suitName, suitColor));
			Card Ten = new Card("10", 10, new Suit(suitName, suitColor));
			Card Jack = new Card("Jack", 10, new Suit(suitName, suitColor));
			Card Queen = new Card("Queen", 10, new Suit(suitName, suitColor));
			Card King = new Card("King", 10, new Suit(suitName, suitColor));

			return new List<ICard>() { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
		}
	}
}
