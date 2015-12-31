using System;
using System.Diagnostics;
using PlayingCards;

// ReSharper disable once CheckNamespace
namespace PlayingCards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                var deck = new Deck();
                foreach (var card in deck.Cards)
                {
                    Console.Write(card.ToString()+ ", ");
                }
            }
            stopWatch.Stop();

            var ts = stopWatch.Elapsed;

            var elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds/10);

            Console.WriteLine("RunTime " + elapsedTime);

            Console.ReadKey();
        }
    }
}