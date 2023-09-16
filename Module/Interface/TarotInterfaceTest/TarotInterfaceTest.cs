using System.Windows.Forms;
using TaroInterface;

namespace TarotInterfaceTest
{
    internal class TarotInterfaceTest
    {
        static Deck deck = new Deck();

        static void Main(string[] args)
        {
            // for (int i = 0; i < 10; i++)
            // {
            //     Console.WriteLine($"{i + 1} 번째 결과");
            //     randomTest();
            // }

            shuffleTest();
        }

        // pop 테스트
        static void popTest()
        {
            Card card1 = new Card("가나다", 1);
            Card card2 = new Card("라마바", 2);
            deck.push(card1);
            deck.push(card2);
            Card result_pop = deck.pop();
            Console.WriteLine($"{result_pop.name}, {result_pop.number}");
        }


        // peek 테스트
        static void pickTest()
        {
            Card card3 = new Card("ABC", 3);
            Card card4 = new Card("DEF", 4);
            deck.push(card3);
            deck.push(card4);
            Card result_peek = deck.peek();
            Console.WriteLine($"{result_peek.name}, {result_peek.number}");
        }

        // random 테스트
        static void randomTest()
        {
            Card card5 = new Card("A", 5);
            Card card6 = new Card("B", 6);
            Card card7 = new Card("C", 7);
            Card card8 = new Card("D", 8);
            Card card9 = new Card("E", 9);
            Card card10 = new Card("F", 10);
            Card card11 = new Card("G", 11);
            Card card12 = new Card("H", 12);
            Card card13 = new Card("I", 13);
            Card card14 = new Card("J", 14);
            deck.push(new Card("J", 14));
            deck.push(card5);
            deck.push(card6);
            deck.push(card7);
            deck.push(card8);
            deck.push(card9);
            deck.push(card10);
            deck.push(card11);
            deck.push(card12);
            deck.push(card13);
            deck.push(card14);
            for (int i = 0; i < 10; i++)
            {
                Card result_random = deck.randomPick();
                Console.WriteLine($"{result_random.name}, {result_random.number}");
            }
            Console.WriteLine("\n");
        }


        // shuffle 테스트
        static void shuffleTest()
        {
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