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
				// 열고자 하는 JSON 파일을 FileStream으로 엽니다.
				return fs;
			}
			catch (Exception e)
			{
				// 파일을 열다가 오류가 발생한 경우 예외 처리
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
				resultDeck.cards = JsonToCards(cardListElement);

				return resultDeck;
			}
			catch (Exception e)
			{
				// JSON 데이터를 읽다가 오류가 발생한 경우 예외 처리
				Console.WriteLine($"JSON 데이터 읽기 오류: {e.Message}");
				return null;
			}
		}

		// json 데이터 card 리스트 형식으로 변환
		private List<Card> JsonToCards(JsonElement cardsElement)
		{
			List<Card> cardList = new();
			foreach (JsonElement cardData in cardsElement.EnumerateArray())
			{
				string cardName = cardData.GetProperty("name").ToString();
				string number = cardData.GetProperty("number").ToString();
				string cardCategory = cardData.GetProperty("category").ToString();
				string[] forward = cardData.GetProperty("forward").ToString().Split(',');
				string[] reverse = cardData.GetProperty("forward").ToString().Split(',');

				Card card = new Card(cardName, int.Parse(number), cardCategory);
				card.forward = forward.ToList();
				card.reverse = reverse.ToList();

				cardList.Add(card);
			}
			return cardList;
		}

		// public List<Card>? readCards()
		// {
		// 	try
		// 	{
		// 		using (var streamReader = new StreamReader(fs))
		// 		{
		// 			// fs의 모든 글자를 읽는다.
		// 			var jsonString = streamReader.ReadToEnd();
		// 
		// 			// JSON 데이터를 읽어서 Card 객체로 역직렬화.
		// 			JsonDocument document = JsonDocument.Parse(jsonString);
		// 
		// 			JsonElement root_element = document.RootElement;
		// 			//Console.WriteLine(document.RootElement);
		// 			JsonElement deck_name = root_element.GetProperty("name");
		// 			JsonElement cards = root_element.GetProperty("cards");
		// 			//JsonElement deck_name = root_element.GetProperty("name");
		// 
		// 			for (int i = 0; i < cards.GetArrayLength(); i++)
		// 			{
		// 				cards[i].GetProperty("category");
		// 				cards[i].GetProperty("number");
		// 				cards[i].GetProperty("number");
		// 				cards[i].GetProperty("forward");
		// 				cards[i].GetProperty("reverse");
		// 			}
		// 			Console.WriteLine(cards[0].ToString());
		// 
		// 			return null;
		// 		}
		// 	}
		// 	catch (Exception e)
		// 	{
		// 		// JSON 데이터를 읽다가 오류가 발생한 경우 예외 처리
		// 		Console.WriteLine($"JSON 데이터 읽기 오류: {e.Message}");
		// 		return null;
		// 	}
		// }

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


