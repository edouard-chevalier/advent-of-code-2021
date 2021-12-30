// See https://aka.ms/new-console-template for more information


using System.Diagnostics;
using System.Text;

namespace Day21
{
    class Program
    {

        private static int[] inputTest = new int[] { 3, 7 };


        private static int[] input = new int[]{6,9};

        static int score(int pos)
        {
            return pos + 1;
        }

        static void exo1()
        {

            var start = input;
            var player1Pos = start[0];
            var player2Pos = start[1];
            int score1 = 0;
            int score2 = 0;
            int dice = 0;

            int nbDice = 0;
            int Roll()
            {
                var res = ++dice;
                dice %= 100;
                nbDice++;
                return res;
            }
            int Roll3()
            {
                var res = 0;
                for (int i = 0; i < 3; i++)
                {
                    res += Roll();
                }
                return res;
            }

            while (true)
            {
                int tmp = Roll3();
                player1Pos += tmp;
                player1Pos %= 10;
                score1 += score(player1Pos);
                if (score1 >= 1000)
                {
                    break;
                }
                tmp = Roll3();
                player2Pos += tmp;
                player2Pos %= 10;
                score2 += score(player2Pos);
                if (score2 >= 1000)
                {
                    break;
                }
            }

                Console.WriteLine((score2 < 1000 ? score2 : score1) * nbDice);


            }



            static void exo2() {


            }

            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                exo1();
            }
    }
}