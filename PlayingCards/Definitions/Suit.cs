using System;
using System.Collections.Generic;
using System.Text;

namespace PlayingCards.Definitions
{
	public class Suit
	{
		public string Name { get; }

		public string Color { get; }

		public Suit(string name, string color)
		{
			Name = name;
			Color = color;
		}
	}
}
