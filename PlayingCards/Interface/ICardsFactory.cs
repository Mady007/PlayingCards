using System.Collections.Generic;

namespace PlayingCards.Interface
{
	public interface ICardsFactory
	{
		List<ICard> CreateCards();
		List<ICard> CreateClubs();
		List<ICard> CreateDiamonds();
		List<ICard> CreateHearts();
		List<ICard> CreateSpades();
	}
}