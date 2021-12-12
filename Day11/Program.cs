// See https://aka.ms/new-console-template for more information


using System.Diagnostics;

namespace Day7
{
    class Program
    {
        private const string inputTest = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

        private const string input = @"4341347643
5477728451
2322733878
5453762556
2718123421
4237886115
5631617114
2217667227
4236581255
4482627641
";





        static void exo1()
            {

                var strings = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                    .ToArray();
                var digits = strings.Select(s => s.ToCharArray().Select(c => (int)(c - '0')).ToArray()).ToArray();
                int maxR = digits.Length -1   ;
                int maxC = digits[0].Length - 1;

                void IncreaseByOne()
                {
                    for (int i = 0; i <= maxR; i++)
                    {
                        for (int j = 0; j <=maxC; j++)
                        {
                            digits![i][j]++;
                        }
                    }
                }

                (int r, int c) AnyToFlash()
                {
                    for (int i = 0; i <= maxR; i++)
                    {
                        for (int j = 0; j <=maxC; j++)
                        {
                            if (digits![i][j] > 9)
                            {
                                return (i,j);
                            }
                        }
                    }

                    return (-1, -1);
                }
                void IncreaseAdjacent(int r, int c)
                {

                    for (int i = r-1; i <= r+1; i++)
                    {
                        for (int j = c-1; j <= c+1; j++)
                        {
                            if (!IsValid(i,j) || (i == r && j == c) || digits![i][j] == 0) continue;
                            digits![i][j]++;
                        }
                    }
                }

                bool IsValid(int i, int j)
                {
                    return i >= 0 && i <= maxR && j >= 0 && j <= maxC;
                }
                long sum = 0;

                void Flash(int r, int c)
                {

                    digits![r][c] = 0;
                    sum++;
                }

                for (int step = 0; step < 100; step++)
                {
                    IncreaseByOne();
                    (int i, int j) = AnyToFlash();
                    while (i != -1)
                    {
                        Flash(i,j);
                        IncreaseAdjacent(i,j);
                        (i, j) = AnyToFlash();
                    }
                    Console.WriteLine($"after step {step+1}.");
                    Console.WriteLine(string.Join("\n", digits.Select(l=>string.Join("", l))));
                }

                Console.WriteLine(sum);


            }

            static void exo2()
            {
var strings = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                    .ToArray();
                var digits = strings.Select(s => s.ToCharArray().Select(c => (int)(c - '0')).ToArray()).ToArray();
                int maxR = digits.Length -1   ;
                int maxC = digits[0].Length - 1;

                void IncreaseByOne()
                {
                    for (int i = 0; i <= maxR; i++)
                    {
                        for (int j = 0; j <=maxC; j++)
                        {
                            digits![i][j]++;
                        }
                    }
                }

                (int r, int c) AnyToFlash()
                {
                    for (int i = 0; i <= maxR; i++)
                    {
                        for (int j = 0; j <=maxC; j++)
                        {
                            if (digits![i][j] > 9)
                            {
                                return (i,j);
                            }
                        }
                    }

                    return (-1, -1);
                }
                void IncreaseAdjacent(int r, int c)
                {

                    for (int i = r-1; i <= r+1; i++)
                    {
                        for (int j = c-1; j <= c+1; j++)
                        {
                            if (!IsValid(i,j) || (i == r && j == c) || digits![i][j] == 0) continue;
                            digits![i][j]++;
                        }
                    }
                }

                bool IsValid(int i, int j)
                {
                    return i >= 0 && i <= maxR && j >= 0 && j <= maxC;
                }
                long sum = 0;

                void Flash(int r, int c)
                {

                    digits![r][c] = 0;
                    sum++;
                }

                int winingstep = 0;
                for (int step = 0; step < 100000; step++)
                {
                    long currentSum = sum;
                    IncreaseByOne();
                    (int i, int j) = AnyToFlash();
                    while (i != -1)
                    {
                        Flash(i,j);
                        IncreaseAdjacent(i,j);
                        (i, j) = AnyToFlash();
                    }
                    Console.WriteLine($"after step {step+1}.");
                    Console.WriteLine(string.Join("\n", digits.Select(l=>string.Join("", l))));
                    if (sum == currentSum + 100)
                    {
                        winingstep = step;
                        break;
                    }
                }

                Console.WriteLine($"step {winingstep +1}");


            }

            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                exo2();
            }
    }
}