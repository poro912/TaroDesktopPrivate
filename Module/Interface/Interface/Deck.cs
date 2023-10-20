using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarotLib;

namespace TaroInterface
{
	// internal
	public class Deck
	{
		// 스택, 환영 큐, 등 여러 자료형을 한번에 사용할 수 있도록 설계함
		public List<Card> cards { get; set; }
		public string name { get; set; }
		public List<string> category { get; set; }

		private int idx = 0;

		public Card? this[int index]
		{
			get { 
				if(0 <= index && index < cards.Count)
					return cards[index]; 
				return null;
			}
		}

		public Deck()
		{
			idx = 0;
			cards = new List<Card>();
		}

		public void addCard(Card card)
		{
			cards.Add(card);
		}

		public void addFront(Card card)
		{
			cards.Insert(0, card);
		}

		// 맨 뒤에 있는 카드를 리스트에서 제거하고, 반환한다.
		public Card? pop()
		{
			if (cards.Count == 0) return null;

			Card? result = cards[cards.Count - 1];
			cards.RemoveAt(cards.Count - 1);
			return result;
		}

		// pop에서 삭제 명령 없이 맨 뒤의 요소를 반환
		public Card? peek()
		{
			if (cards.Count == 0) return null;

			return cards[cards.Count - 1];
		}

		// 카드 리스트에 추가
		public void push(Card card)
		{
			cards.Add(card);
		}

		// 2중첩 for문 이용해 셔플
		public void shuffle()
		{
			var shuffledcards = new List<Card>();
			shuffledcards = cards;
			for (int i = 0; i < 3; i++)
			{
				shuffledcards = shuffledcards.OrderBy(a => Guid.NewGuid()).ToList();
			}
			cards.Clear();
			cards.AddRange(shuffledcards);
		}

		// 배열의 리스트에서 랜덤하게 하나를 가져오는거
		public Card? randomPick() // 함수명 변경 (random -> randomPick)
		{
			Random rand = new Random();

			if (cards.Count == 0) return null;

			Card result = cards[rand.Next(cards.Count)];

			return result;
		}

		public Card? next()
		{
			if (cards.Count == 0) return null;

			idx = (idx + 1) % cards.Count;
			return cards[idx];
		}

		// 테스트용
		public string ToString()
		{
			StringBuilder sb = new StringBuilder();

			foreach (Card card in cards)
			{
				sb.Append($"[{card.number}]");
			}
			
			return sb.ToString();
		}
	}
}
