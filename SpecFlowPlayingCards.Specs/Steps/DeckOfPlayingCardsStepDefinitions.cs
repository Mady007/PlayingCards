using FluentAssertions;
using PlayingCards;
using PlayingCards.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowPlayingCards.Specs.Steps
{
	[Binding]
    public class DeckOfPlayingCardsSteps
    {
        private Deck Deck;
        private int actualTotalCardsCount = 0;
        private List<ICard> actualCardsInDeck;
        private ICard CardInHand;

        [Given(@"a deck of cards")]
        public void GivenADeckOfCards()
        {
            var cardFactory = new CardsFactory();
            Deck = new Deck(cardFactory.CreateCards());
        }
        
        [When(@"I count each card")]
        public void WhenICountEachCard()
        {
            actualTotalCardsCount = Deck.TotalCardsCount;
        }
        
        [When(@"I check for suits")]
        public void WhenICheckForSuits()
        {
            actualCardsInDeck = Deck.AllCards;
        }
        
        [When(@"I count all the cards in a single suit")]
        public void WhenICountAllTheCardsInASingleSuit()
        {
            actualCardsInDeck = Deck.AllCards;
        }
        
        [When(@"I have a card with (.*)")]
        public void WhenIHaveACardWith(string face_value)
        {
            CardInHand = Deck.AllCards.First(x => string.Equals(x.FaceValue, face_value, StringComparison.OrdinalIgnoreCase));
        }
        
        [Then(@"I have a total of (.*) cards")]
        public void ThenIHaveATotalOfCards(int expectedCount)
        {
            expectedCount.Should().Equals(actualTotalCardsCount);
        }
        
        [Then(@"I see hearts, clubs, spades, and diamonds")]
        public void ThenISeeHeartsClubsSpadesAndDiamonds()
        {
            //actualCardsInDeck are the total cards in the dec, please see respective when. Checking if all suits are present.
            actualCardsInDeck.Any(x => string.Equals(x.Suit.Name, "Heart", StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
            actualCardsInDeck.Any(x => string.Equals(x.Suit.Name, "club", StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
            actualCardsInDeck.Any(x => string.Equals(x.Suit.Name, "spade", StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
            actualCardsInDeck.Any(x => string.Equals(x.Suit.Name, "diamond", StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
        }
        
        [Then(@"I have (.*) cards: ace, (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), Jack, Queen, King")]
        public void ThenIHaveCardsAceJackQueenKing(int totalCardsInOneSuit, int two, int three, int four, int five, int six, int seven, int eight, int nine, int ten)
        {
            //actualCardsInDeck has all suits, segregating them based on suit
            var hearts = actualCardsInDeck.Where(x => string.Equals(x.Suit.Name, "Heart", StringComparison.OrdinalIgnoreCase));
            var clubs = actualCardsInDeck.Where(x => string.Equals(x.Suit.Name, "club", StringComparison.OrdinalIgnoreCase));
            var spades = actualCardsInDeck.Where(x => string.Equals(x.Suit.Name, "spade", StringComparison.OrdinalIgnoreCase));
            var diamonds = actualCardsInDeck.Where(x => string.Equals(x.Suit.Name, "diamond", StringComparison.OrdinalIgnoreCase));

            hearts.Should().HaveCount(totalCardsInOneSuit); //count should match the totalCardsInOneSuit(13) passed in from feature file
            AssertEachCard(hearts);

            clubs.Should().HaveCount(totalCardsInOneSuit);
            AssertEachCard(clubs);

            spades.Should().HaveCount(totalCardsInOneSuit);
            AssertEachCard(spades);

            diamonds.Should().HaveCount(totalCardsInOneSuit);
            AssertEachCard(diamonds);

            //Checking if all the cards are present in the given suit
            void AssertEachCard(IEnumerable<ICard> cardsOfSingleSuit)
            {
                //Unlike 2,3...10 Ace,Jack,Queen,King did not transformed into parameters on step definition generation
                cardsOfSingleSuit.Any(x => x.FaceValue == "Ace").Should().BeTrue();
                cardsOfSingleSuit.Any(x => x.PointValue == two).Should().BeTrue();
                cardsOfSingleSuit.Any(x => x.PointValue == three).Should().BeTrue();
                cardsOfSingleSuit.Any(x => x.PointValue == four).Should().BeTrue();
                cardsOfSingleSuit.Any(x => x.PointValue == five).Should().BeTrue();
                cardsOfSingleSuit.Any(x => x.PointValue == six).Should().BeTrue();
                cardsOfSingleSuit.Any(x => x.PointValue == seven).Should().BeTrue();
                cardsOfSingleSuit.Any(x => x.PointValue == eight).Should().BeTrue();
                cardsOfSingleSuit.Any(x => x.PointValue == nine).Should().BeTrue();
                cardsOfSingleSuit.Any(x => x.PointValue == ten).Should().BeTrue();
                cardsOfSingleSuit.Any(x => x.FaceValue == "Jack").Should().BeTrue();
                cardsOfSingleSuit.Any(x => x.FaceValue == "Queen").Should().BeTrue();
                cardsOfSingleSuit.Any(x => x.FaceValue == "King").Should().BeTrue();
            }
        }
        
        [Then(@"the card is worth (.*)")]
        public void ThenTheCardIsWorth(string pointValue)
        {
            //CardInHand is first card retrieved from the deck based on face_Value, please see when
            CardInHand.PointValue.Should().Equals(pointValue);
        }
        
        [Then(@"the face cards are ordered Jack, Queen, King")]
        public void ThenTheFaceCardsAreOrderedJackQueenKing()
        {
            int jackPosition = 11;
            int queenPosition = jackPosition + 1;
            int kingPosition = queenPosition + 1;

            //Since list index is a zero based index we have to substract 1 from the actual position,jackPosition - 1 
            Deck.Spades[jackPosition - 1].FaceValue.Should().Equals("Jack");
            Deck.Spades[jackPosition - 1].PointValue.Should().Equals(10);
            Deck.Spades[queenPosition - 1].FaceValue.Should().Equals("Queen");
            Deck.Spades[queenPosition - 1].PointValue.Should().Equals(10);
            Deck.Spades[kingPosition - 1].FaceValue.Should().Equals("King");
            Deck.Spades[kingPosition - 1].PointValue.Should().Equals(10);
        }
    }
}
