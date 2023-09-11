using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaroInterface
{
	// internal
	public class Deck
	{
		// 스택, 환영 큐, 등 여러 자료형을 한번에 사용할 수 있도록 설계함
		public List<Card> cards;

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

		// 맨 뒤에 있는 카드를 리스트에서 제거하고, 반환한다. (완)
		public Card? pop()
		{
			Card result = null;
			result = cards[cards.Count - 1];
			cards.Remove(result);
			return result;
		}

		// 
		public Card? peek()
		{
			return null;
		}

		// (완)
		public void push(Card card)
		{
			cards.Add(card);
		}

		// 2중첩 for문 이용해 셔플
		public void shuffle()
		{
			// Linq의 OrderBy 메소드를 이용해 각 요소를 GUID 기반으로 정렬하여 무작위 순서로 섞음.
			var shuffledcards = cards.OrderBy(a=>Guid.NewGuid()).ToList();
			cards.Clear();
			cards.AddRange(shuffledcards);

			// 단순 2중첩 for문
			//for (int i = 0; i < cards.Count; i++)
			//{
			//	for (int j = 0; j < cards.Count; j++)
			//	{
			//		// 랜덤이 들어가야 하는거 아닌가..?
			//	}
			//}
		}

		// 
		public Card? random()
		{
			return null;
		}

		public Card? Next()
		{
			if(++idx >= cards.Count) idx %= cards.Count;
			return cards[idx];
		}

        // 테스트용
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Card card in cards)
            {
				sb.Append($"[{card.Number}]");
            }
            
			return sb.ToString();
        }
    }
}
