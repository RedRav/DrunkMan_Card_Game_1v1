using System;
using System.Collections.Generic;
using System.Linq;
public class MainClass
{
    public static void Main()
    {
        string[] s = Console.ReadLine()!.Split(" ");

        var player1 = new Queue<string>();
        var player2 = new Queue<string>();
        for (int i = 0; i < s.Length; i += 2)
        {
            player1.Enqueue(s[i]);
            player2.Enqueue(s[i + 1]);
        }
        var nominal = new Dictionary<string, int>()
        {
            {"В", 11},
            {"Д", 12},
            {"К", 13},
            {"Т", 14}
        };
        var suit = new Dictionary<char, int>()
        {
            {'\u0006', 0},
            {'\u0005', 1},
            {'\u0004', 2},
            {'\u0003', 3}
        };
        while (player1.Count > 0 && player2.Count > 0)
        {
            string nominalP1Value = player1.Peek().Substring(0, player1.Peek().Length - 1);
            string nominalP2Value = player2.Peek().Substring(0, player2.Peek().Length - 1);

            int nominalP1 = (nominal.ContainsKey(nominalP1Value)) ? nominal[nominalP1Value] : int.Parse(nominalP1Value);
            int nominalP2 = (nominal.ContainsKey(nominalP2Value)) ? nominal[nominalP2Value] : int.Parse(nominalP2Value);
            char suitP1 = Convert.ToChar(player1.Peek().Substring(player1.Peek().Length - 1));
            char suitP2 = Convert.ToChar(player2.Peek().Substring(player2.Peek().Length - 1));

            Console.WriteLine($"Player1 {player1.Peek()} - Player2 {player2.Peek()}");

            if (nominalP1 == nominalP2)
            {

                if (suit[suitP1] > suit[suitP2])
                {
                    player1.Enqueue(player1.Dequeue());
                    player1.Enqueue(player2.Dequeue());
                }
                else
                {
                    player2.Enqueue(player2.Dequeue());
                    player2.Enqueue(player1.Dequeue());
                }
            }
            else
            {
                if ((nominalP1 == 6 && nominalP2 == 14) || (nominalP1 > nominalP2 && !(nominalP2 == 6 && nominalP1 == 14)))
                {
                    player1.Enqueue(player1.Dequeue());
                    player1.Enqueue(player2.Dequeue());
                }
                else if ((nominalP2 == 6 && nominalP1 == 14) || nominalP2 > nominalP1)
                {
                    player2.Enqueue(player2.Dequeue());
                    player2.Enqueue(player1.Dequeue());
                }
            }
        }
        Console.WriteLine(player1.Count == 0 ? "Player2" : "Player1");
    }
}

