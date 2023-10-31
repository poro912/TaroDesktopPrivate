using System;
using TaroInterface;
using TarotLib;

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

while (true)
{
	Console.Write("원하는 카드의 번호 입력(0 ~ 21) : ");
	int idx;
	bool isNum = int.TryParse(Console.ReadLine(), out idx);
	if (!isNum) continue;
	if (idx < 0 || idx > 21) break;

	Console.WriteLine($"카드이름 : {deck.cards[idx].name}");
	Console.WriteLine("기본설명 : ");
	Console.WriteLine("========== forward ==========");
	foreach (string meen in deck.cards[idx].forward)
	{
		Console.WriteLine(meen);
	}
	Console.WriteLine("========== reverse ==========");
	foreach (string meen in deck.cards[idx].reverse)
	{
		Console.WriteLine(meen);
	}
	Console.WriteLine();
}
