// See https://aka.ms/new-console-template for more information



namespace Day1
{
    class Program
    {
        private const string inputTest = @"3,4,3,1,2";

        private const string input = @"4,1,1,1,5,1,3,1,5,3,4,3,3,1,3,3,1,5,3,2,4,4,3,4,1,4,2,2,1,3,5,1,1,3,2,5,1,1,4,2,5,4,3,2,5,3,3,4,5,4,3,5,4,2,5,5,2,2,2,3,5,5,4,2,1,1,5,1,4,3,2,2,1,2,1,5,3,3,3,5,1,5,4,2,2,2,1,4,2,5,2,3,3,2,3,4,4,1,4,4,3,1,1,1,1,1,4,4,5,4,2,5,1,5,4,4,5,2,3,5,4,1,4,5,2,1,1,2,5,4,5,5,1,1,1,1,1,4,5,3,1,3,4,3,3,1,5,4,2,1,4,4,4,1,1,3,1,3,5,3,1,4,5,3,5,1,1,2,2,4,4,1,4,1,3,1,1,3,1,3,3,5,4,2,1,1,2,1,2,3,3,5,4,1,1,2,1,2,5,3,1,5,4,3,1,5,2,3,4,4,3,1,1,1,2,1,1,2,1,5,4,2,2,1,4,3,1,1,1,1,3,1,5,2,4,1,3,2,3,4,3,4,2,1,2,1,2,4,2,1,5,2,2,5,5,1,1,2,3,1,1,1,3,5,1,3,5,1,3,3,2,4,5,5,3,1,4,1,5,2,4,5,5,5,2,4,2,2,5,2,4,1,3,2,1,1,4,4,1,5";

        static void exo1()
            {

                var strings = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                    .ToArray();
                var integers = strings[0].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse ).ToArray();
                long[] PopPerTimer = new long[9];
                long[] PopPerTimerNext = new long[9];

                foreach (var lamp in integers)
                {
                    PopPerTimer[lamp]++;
                }
                Console.WriteLine(string.Join(",", PopPerTimer));
                for (int i = 1; i <= 256; i++) {

                    for (int timer = 0; timer < 8; timer++)
                    {
                        PopPerTimerNext[timer] = PopPerTimer[timer + 1];
                    }

                    PopPerTimerNext[8] = PopPerTimer[0];
                    PopPerTimerNext[6] += PopPerTimer[0];

                    (PopPerTimer, PopPerTimerNext) = (PopPerTimerNext, PopPerTimer);
                    Array.Clear(PopPerTimerNext);
                    Console.WriteLine($"{i} day: {string.Join(",", PopPerTimer)}");

                }

                Console.WriteLine(PopPerTimer.Sum());
                //Console.WriteLine(board.Count(kv => kv.Value >= 2));

            }

            static void exo2()
            {
                var strings = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                    .ToArray();
                var lines = strings.Select(s => new Line(s)).ToArray();
                var board = new Dictionary<(int X, int Y), int>();
                foreach (var line in lines)
                {
                    foreach (var valueTuple in line.Points())
                    {
                        if (!board.TryGetValue(valueTuple, out var count))
                        {
                            count = 0;
                        }

                        board[valueTuple] = count + 1;
                    }
                }

                /*StringBuilder builder = new StringBuilder();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board.TryGetValue((j, i), out var nb))
                        {
                            builder.Append(nb);
                        }
                        else
                        {
                            builder.Append('.');
                        }
                    }

                    builder.AppendLine();
                }

                Console.WriteLine(builder);*/
                Console.WriteLine(board.Count(kv => kv.Value >= 2));



            }

            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                exo1();
            }
    }
}