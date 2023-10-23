using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using TaroInterface;

namespace TarotLib
{
	public class JsonParser
	{
		private FileStream fs;
		// public JsonObject obj;
		public JsonParser() { }
		

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

		public Deck readDeck()
		{
			try
			{
				//해당방식으로 선언시 메서드 안에서만 해당 변수 사용후 자동으로 해제
				using var streamReader = new StreamReader(fs);

				var jsonString = streamReader.ReadToEnd();

				JsonDocument document = JsonDocument.Parse(jsonString);

				JsonElement rootElement = document.RootElement;
				JsonElement cardListElement = rootElement.GetProperty("cards");

				Deck resultDeck = new Deck();
				resultDeck.name = rootElement.GetProperty("name").ToString();
				resultDeck.category = rootElement.GetProperty("category").ToString().Split(',').ToList();
				resultDeck.cards = readCards(cardListElement);

				return resultDeck;
			}
			catch (Exception e)
			{
				Console.WriteLine($"JSON 데이터 읽기 오류: {e.Message}");
				return null;
			}
		}

		// json 데이터 card 리스트 형식으로 변환
		private List<Card> readCards(JsonElement cardsElement)
		{
			List<Card> cardList = new();
			foreach (JsonElement cardData in cardsElement.EnumerateArray())
			{
				List<string> fowards = cardData.GetProperty("forward").EnumerateArray().Select(forwardData => forwardData.ToString()).ToList();
				List<string> reverse = cardData.GetProperty("reverse").EnumerateArray().Select(reverseData => reverseData.ToString()).ToList();

				Card card = new Card {
					name = cardData.GetProperty("name").ToString(),
					number = int.Parse(cardData.GetProperty("number").ToString()),
					category = cardData.GetProperty("category").ToString(),
					forward = fowards,
					reverse = reverse
				};
				cardList.Add(card);
			}
			return cardList;
		}

		public List<Card>? readSpread()
		{
			return null;
		}

		public void close()
		{
			fs.Close();
		}
	}
}


