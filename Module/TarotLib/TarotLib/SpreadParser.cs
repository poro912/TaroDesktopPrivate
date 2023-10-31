
using System.Text.Json;
using TaroInterface;

namespace TarotLib
{
	public class SpreadParser
	{
		private FileStream fs;
		public SpreadParser() { }

		public FileStream? open(string path)
		{
			try
			{
				fs = File.OpenRead(path);
				return fs;
			}
			catch (Exception e)
			{
				Console.WriteLine($"파일 열기 오류: {e.Message}");
				return null;
			}
		}

		public List<Spread> readSpreadList()
		{
			try
			{
				List<Spread> spreads = new();
				using var streamReader = new StreamReader(fs);

				var jsonString = streamReader.ReadToEnd();

				JsonDocument document = JsonDocument.Parse(jsonString);

				JsonElement rootElement = document.RootElement;

				foreach (JsonElement spreadData in rootElement.EnumerateArray())
				{
					spreads.Add(readSpread(spreadData));
				}
				return spreads;
			}
			catch (Exception e)
			{
				Console.WriteLine($"JSON 데이터 읽기 오류: {e.Message}");
				return null;
			}
		}

		// public Spread readSpread()
		// {
		// 	try
		// 	{
		// 		using var streamReader = new StreamReader(fs);
		// 
		// 		var jsonString = streamReader.ReadToEnd();
		// 
		// 		JsonDocument document = JsonDocument.Parse(jsonString);
		// 
		// 		JsonElement rootElement = document.RootElement;
		// 		JsonElement slotsListElement = rootElement.GetProperty("slots");
		// 		return readSpread(rootElement);
		// 	}
		// 	catch (Exception e)
		// 	{
		// 		Console.WriteLine($"JSON 데이터 읽기 오류: {e.Message}");
		// 		return null;
		// 	}
		// }

		private Spread readSpread(JsonElement spreadData)
		{
			JsonElement slotsListElement = spreadData.GetProperty("slots");
			Spread resultSpread = new Spread();
			resultSpread.name = spreadData.GetProperty("name").ToString();
			resultSpread.description = spreadData.GetProperty("description").ToString();
			resultSpread.slots = readSlots(slotsListElement);
			return resultSpread;
		}

		private List<Slot> readSlots(JsonElement slotsListElement)
		{
			List<Slot> slotList = new();
			foreach (JsonElement slotData in slotsListElement.EnumerateArray())
			{
				Slot slot = new Slot
				{
					x = int.Parse(slotData.GetProperty("x").ToString()),
					y = int.Parse(slotData.GetProperty("y").ToString()),
					mean = slotData.GetProperty("mean").ToString()
				};
				slotList.Add(slot);
			}
			return slotList;
		}

		public void close()
		{
			fs.Close();
		}
	}
}
