using PlayingCards.Definitions;

namespace PlayingCards.Interface
{
	public interface ICard
	{
		string FaceValue { get; }
		int PointValue { get; }
		Suit Suit { get; }
	}
}