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
		public FileStream fs;
		public JsonObject obj;
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

		public List<Deck>? readCards()
		{
			try
			{
				using (var streamReader = new StreamReader(fs))
				{
					// fs의 모든 글자를 읽는다.
					var jsonString = streamReader.ReadToEnd();

					// JSON 데이터를 읽어서 Card 객체로 역직렬화합니다.
					JsonDocument document = JsonDocument.Parse(jsonString);

					JsonElement root_element = document.RootElement;
					//Console.WriteLine(document.RootElement);
					JsonElement deck_name = root_element.GetProperty("name");
					JsonElement cards = root_element.GetProperty("cards");
					JsonElement category = root_element.GetProperty("category");
					//JsonElement deck_name = root_element.GetProperty("name");

					for( int i = 0; i < cards.GetArrayLength(); i++)
					{
						cards[i].GetProperty("category");
						cards[i].GetProperty("number");
						cards[i].GetProperty("name");
						cards[i].GetProperty("forward");
						cards[i].GetProperty("reverse");
					}
					Console.WriteLine(cards[0].ToString());

					return null;
				}
			}
			catch (Exception e)
			{
				// JSON 데이터를 읽다가 오류가 발생한 경우 예외 처리
				Console.WriteLine($"JSON 데이터 읽기 오류: {e.Message}");
				return null;
			}
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


