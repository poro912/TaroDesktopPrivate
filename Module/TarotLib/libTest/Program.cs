using TaroInterface;
using TarotLib;

// TarotLib.JsonParser jp = new ();

// jp.open("../../../Universal Waite Major.json");
// jp.readDeck();
// jp.close();


TarotLib.JsonParser jp = new();

jp.open("../../../Universal Waite Major.json");

Deck? deck = jp.readDeck();
Console.WriteLine($"Deck Name : {deck.name}");
Console.WriteLine($"=========== Deck List {deck.cards.Count} ===========");

foreach (Card card in deck.cards)
{
	Console.WriteLine($" Number : {card.number} / Name : {card.name}");
}
jp.close();