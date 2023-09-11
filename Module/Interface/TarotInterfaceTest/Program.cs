using System.Windows.Forms;
using TaroInterface;

namespace TarotInterfaceTest
{
    internal class Program
    {
        static Deck deck = new Deck();

        static void Main(string[] args)
        {
            // pop 테스트
            Card card1 = new Card("가나다", 1);
            Card card2 = new Card("라마바", 2);
            deck.push(card1);
            deck.push(card2);
            Card result = deck.pop();
            Console.WriteLine($"{result.Name}, {result.Number}");


            // shuffle 테스트
            for (int j = 1; j <= 20; j++)
            {
                CreateNewCardDeck();
                deck.shuffle();
                string deckView = deck.ToString();
                Console.WriteLine(deckView);
            }
        }

        // shuffle 테스트
        static void CreateNewCardDeck()
        {
            deck = new Deck();

            for (int i = 0; i < 20; i++)
            {
                Card card = new Card($"{i}번 카드", i);
                deck.push(card);
            }
        }
    }
}