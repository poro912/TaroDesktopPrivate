using TaroInterface;
using TarotLib;

TarotLib.SpreadParser jp2 = new();

jp2.open("D:/6_C#project/data/Spread.json");

List<Spread> spreads = jp2.readSpreadList();

foreach (Spread spread in spreads)
{
	Console.WriteLine($"Spread Name : {spread.name}");
	Console.WriteLine($"=========== Slot List {spread.slots.Count} ===========");

	foreach (Slot slot in spread.slots)
	{
		Console.WriteLine($"	" + slot.ToString());
	}
}

jp2.close();