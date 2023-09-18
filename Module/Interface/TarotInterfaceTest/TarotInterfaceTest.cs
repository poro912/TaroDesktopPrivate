using System.Windows.Forms;
using TaroInterface;

namespace TarotInterfaceTest
{
    internal class TarotInterfaceTest
    {
        static Deck deck = new Deck();

        static void Main(string[] args)
        {
            // popTest();

            // peekTest();

            // for (int i = 0; i < 10; i++)
            // {
            //     Console.WriteLine($"{i + 1} 번째 결과");
            //     randomTest();
            // }

            // nextTest();
        }

        // pop 테스트
        static void popTest()
        {
            Card card1 = new Card("가나다", 1);
            Card card2 = new Card("라마바", 2);
            deck.push(card1);
            deck.push(card2);
            Card result_pop = deck.pop();
            
            if (result_pop == null)
            {
                Console.WriteLine("null입니다.");
            }
            else
            {
                Console.WriteLine($"{result_pop.name}, {result_pop.number}");
            }
        }


        // peek 테스트
        static void peekTest()
        {
            Card card3 = new Card("ABC", 3);
            Card card4 = new Card("DEF", 4);
            deck.push(card3);
            deck.push(card4);
            Card result_peek = deck.peek();

            if (result_peek == null)
            {
                Console.WriteLine("null입니다.");
            }
            else
            {
                Console.WriteLine($"{result_peek.name}, {result_peek.number}");
            }
        }

        // random 테스트
        static void randomTest()
        {
            deck.push(new Card("A", 5));
            deck.push(new Card("B", 6));
            deck.push(new Card("C", 7));
            deck.push(new Card("D", 8));
            deck.push(new Card("E", 9));
            deck.push(new Card("F", 10));
            deck.push(new Card("G", 11));
            deck.push(new Card("H", 12));
            deck.push(new Card("I", 13));
            deck.push(new Card("J", 14));

            for (int i = 0; i < 10; i++)
            {
                Card result_random = deck.randomPick();

                if (result_random == null)
                {
                    Console.WriteLine("null입니다.");
                }
                else
                {
                    Console.WriteLine($"{result_random.name}, {result_random.number}");
                }
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

        // next 테스트
        static void nextTest()
        {
            deck.push(new Card("A", 15));
            deck.push(new Card("B", 16));
            deck.push(new Card("C", 17));
            deck.push(new Card("D", 18));
            deck.push(new Card("E", 19));
            deck.push(new Card("F", 20));

            for (int i = 0; i < 5; i++)
            {
                Card result_next = deck.next();
                Console.WriteLine($"{result_next.name}, {result_next.number}");
            }
        }
    }
}