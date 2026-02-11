using UnityEngine;

public class Card
{
    private Suit suit;
    private CardRank cardRank;

    public Card(Suit suit, CardRank cardRank)
    {
        this.suit = suit;
        this.cardRank = cardRank;
    }

    public Suit GetSuit() { return this.suit; }
    public CardRank GetCardRank() { return this.cardRank; }
}
public enum Suit
{
    SPADES,
    CLOVERS,
    HEARTS,
    DIAMONDS
}

public enum CardRank
{
    THREE = 3,
    FOUR = 4,
    FIVE = 5,
    SIX = 6,
    SEVEN = 7,
    EIGHT = 8,
    NINE = 9,
    TEN = 10,
    JACK = 11,
    QUEEN = 12,
    KING = 13,
    ACE = 14,
    TWO = 15
}
