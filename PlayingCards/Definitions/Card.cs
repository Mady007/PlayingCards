using PlayingCards.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayingCards.Definitions
{
	public class Card : ICard
	{
		public string FaceValue { get; }

		public int PointValue { get; }

		public Suit Suit { get; }

		public Card(string faceValue, int pointValue, Suit suit)
		{
			FaceValue = faceValue;
			PointValue = pointValue;
			Suit = suit;
		}
	}
}
