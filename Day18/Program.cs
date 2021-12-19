// See https://aka.ms/new-console-template for more information


using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace Day13
{
    class Program
    {
        private const string inputTest = @"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";

        private const string inputTestLight = @"[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
[7,[5,[[3,8],[1,4]]]]
[[2,[2,2]],[8,[8,1]]]
[2,9]
[1,[[[9,3],9],[[9,0],[0,7]]]]
[[[5,[7,4]],7],1]
[[[[4,2],2],6],[8,7]]";
        private const string inputVeryLight = @"[1,1]
[2,2]
[3,3]
[4,4]
[5,5],
[6,6]";

        private const string input =
            @"[[[[2,8],[4,6]],[[2,4],[9,4]]],[[[0,6],[4,6]],[1,6]]]
[7,[[5,7],1]]
[[[[8,8],7],5],[[[5,6],1],6]]
[[[8,5],[[0,0],[4,9]]],[2,8]]
[7,[[5,2],[[3,0],[7,7]]]]
[[6,[6,8]],[3,[5,2]]]
[6,[[[8,9],[9,9]],[3,8]]]
[[[1,[0,2]],[7,[3,0]]],8]
[[9,6],6]
[[[2,3],1],[9,[3,7]]]
[5,[[[5,8],3],9]]
[[[[8,8],3],[2,2]],[2,3]]
[[[4,9],3],[[[7,3],8],5]]
[[[3,5],[3,7]],[[[9,7],9],[9,[7,8]]]]
[[7,1],8]
[0,[[[6,8],[1,1]],[1,[5,8]]]]
[[[[2,2],[9,5]],[0,[1,0]]],[4,[[2,4],4]]]
[[[[2,5],[7,3]],[7,6]],[[6,[4,4]],[3,8]]]
[[3,[[7,9],2]],[[0,[4,4]],[[6,9],9]]]
[[[7,7],[[1,4],[1,6]]],[7,[[6,3],6]]]
[[0,8],[[[1,6],2],4]]
[[0,[[2,7],[0,4]]],[[[3,8],[7,7]],5]]
[[[[9,9],[1,3]],[9,[4,3]]],[[[3,4],[6,4]],1]]
[[[9,[0,9]],[2,[7,6]]],[2,[[1,9],[3,3]]]]
[[4,[5,6]],[[[1,5],6],[[1,5],[5,2]]]]
[1,[[3,[2,1]],5]]
[[4,[3,8]],[3,[6,3]]]
[[7,1],[[3,[6,0]],[5,[1,1]]]]
[[8,7],[[[0,1],[2,6]],[5,[4,7]]]]
[9,[[[1,6],[8,9]],[6,6]]]
[4,9]
[[[[0,8],[8,5]],9],[7,[1,3]]]
[[[[8,5],0],[[4,6],4]],[8,4]]
[[[[8,9],8],[[3,1],[7,6]]],2]
[[[[6,3],0],[2,[4,8]]],[[[0,3],[3,5]],4]]
[0,[[9,[0,6]],5]]
[[[[1,9],[2,7]],[[4,0],[9,9]]],[[8,[3,6]],[3,4]]]
[[[[0,7],[8,4]],1],[[8,3],[[3,5],[8,0]]]]
[[[[3,5],4],[0,9]],[[[1,7],5],[9,[8,0]]]]
[[[8,[6,8]],[[3,7],[0,8]]],[[[5,2],[1,7]],[9,5]]]
[[[[5,1],[0,7]],4],[0,4]]
[[[[9,8],[3,9]],[[0,6],3]],[[[9,1],[8,7]],2]]
[[9,[[0,3],6]],[[3,4],[[8,9],5]]]
[[1,[1,8]],[[6,[4,2]],1]]
[7,[[1,[5,2]],[[9,7],0]]]
[0,[8,6]]
[1,4]
[[8,[4,1]],[[[4,0],[0,0]],[7,[3,4]]]]
[2,[[1,[1,8]],[[3,4],1]]]
[[8,[[1,2],[3,1]]],[[[4,4],[7,9]],1]]
[[4,[0,[6,4]]],[9,[0,[1,2]]]]
[[6,[3,1]],[[7,8],[8,[2,5]]]]
[[[2,[3,3]],[[6,4],[9,4]]],[[[1,5],[7,4]],[0,6]]]
[[[[8,0],3],[[4,0],3]],[[7,5],4]]
[[[2,[4,3]],[[2,1],5]],1]
[[[8,1],[0,4]],[9,[[1,4],[9,0]]]]
[[[5,0],[[7,7],9]],[[6,[6,2]],7]]
[[[[5,9],0],[[4,6],[3,8]]],[6,[6,5]]]
[[[6,[7,8]],[5,3]],[[3,[6,5]],[[8,7],[4,7]]]]
[[9,[[8,7],4]],[[[6,3],0],[[2,3],[5,9]]]]
[[[[1,8],6],1],[[[7,8],4],[7,2]]]
[[[[7,1],[6,2]],[[7,8],2]],0]
[[[4,5],[0,3]],[[2,4],1]]
[[[9,1],7],[[[8,8],[0,7]],[8,0]]]
[[5,[[7,5],[7,5]]],[3,[4,8]]]
[[7,[1,0]],[[3,[1,5]],0]]
[[[5,1],[[5,2],[7,3]]],[[7,[3,9]],9]]
[5,[1,[[9,9],[3,0]]]]
[[2,0],[9,[6,[3,3]]]]
[[[[0,4],[4,8]],[[1,9],[5,8]]],[[[7,0],5],[5,1]]]
[[[[1,5],[9,2]],[6,[3,6]]],[4,[1,[1,5]]]]
[[[[1,4],[4,6]],[[5,5],[3,5]]],[[[7,1],4],[[0,7],4]]]
[[6,[3,5]],1]
[8,[[1,[0,7]],[[2,5],6]]]
[[[[1,6],3],[[9,7],9]],[[7,8],3]]
[[[[9,9],[2,0]],0],[1,4]]
[[[[1,3],[5,1]],[[0,4],2]],0]
[[3,2],[7,[[9,3],8]]]
[[9,0],[4,[[8,7],[5,5]]]]
[[[[7,4],8],[[4,4],1]],9]
[[9,[[7,9],1]],[[[6,5],7],[[2,5],2]]]
[7,2]
[[[6,6],[[9,4],4]],6]
[[1,[[5,0],3]],[5,[4,4]]]
[[[3,2],[[4,6],6]],[[3,[9,5]],[[0,2],[4,6]]]]
[5,[[0,[3,0]],[7,[7,9]]]]
[[[[0,4],[1,5]],4],[8,[[4,7],8]]]
[[[[9,1],0],0],4]
[[[[8,4],[4,2]],[9,[1,7]]],[6,3]]
[2,[[[8,3],2],[[3,1],8]]]
[[[[9,0],[7,8]],[[2,7],[0,3]]],[[[8,5],3],[9,[6,8]]]]
[[[[8,9],[9,1]],[4,[0,1]]],[[[7,8],2],2]]
[[[[2,2],[4,1]],[2,[2,8]]],[[[6,5],1],9]]
[[[[3,0],7],7],[[[9,3],7],4]]
[[[[7,5],1],3],[[[0,7],7],[[2,6],[9,9]]]]
[[[[5,2],8],[9,[8,8]]],[2,[[0,8],[5,6]]]]
[[[[7,7],[1,2]],[6,6]],[8,[5,8]]]
[[7,[4,[8,9]]],[[4,[7,2]],8]]
[[[6,4],[7,7]],[[[3,7],0],[0,1]]]
[[1,[5,9]],[8,[4,6]]]
";


        public abstract class BasePair
        {

            public abstract bool Explode(int level, out int left, out int right, out BasePair newPair);
            public abstract void AddFromLeft(int val);
            public abstract void AddFromRight(int val);

            public abstract bool Split(int level, out BasePair newPair);

            public abstract long Magnitude();

        }
        public static BasePair Reduce( BasePair pair)
        {

            while (true)
            {
                if (pair.Explode(1, out _, out _, out var newPair))
                {

                    pair = newPair;
                   // Console.WriteLine("after explosion : " + pair);
                    continue;
                }

                if (pair.Split(1, out var newPairSplit))
                {
                    pair = newPairSplit;
                    //Console.WriteLine("after split     : " + pair);
                    continue;
                }

                break;
            }

            return pair;
        }

        public static BasePair Add(BasePair l, BasePair r)
        {
            return new Pair(l, r);
        }

        public class Pair : BasePair
        {
            public Pair(BasePair left, BasePair right)
            {
                Left = left;
                Right = right;
            }

            public BasePair Left { get; set; }
            public BasePair Right { get; set; }

            public override bool Explode(int level, out int left, out int right, out BasePair newPair)
            {
                left = 0;
                right = 0;
                newPair = this;

                if (level == 5)
                {

                    left = (Left as Singleton).RegularNumber;
                    right = (Right as Singleton).RegularNumber;
                    newPair = new Singleton(0);

                    return true;
                }

                if (Left.Explode(level + 1, out int ll, out int lr, out BasePair newLeft))
                {
                    Left = newLeft;
                    left = ll;
                    Right.AddFromLeft(lr);

                    return true;
                }
                if (Right.Explode(level + 1, out int rl, out int rr, out BasePair newRight))
                {
                    Right = newRight;
                    right = rr ;
                    Left.AddFromRight(rl);
                    return true;
                }

                return false;
            }

            public override void AddFromLeft(int val)
            {
                Left.AddFromLeft(val);
            }

            public override void AddFromRight(int val)
            {
                Right.AddFromRight(val);
            }

            public override bool Split(int level, out BasePair newPair)
            {
                newPair = this;
                if (Left.Split(level + 1, out var newLeft))
                {
                    Left = newLeft;
                    return true;
                }
                if (Right.Split(level + 1, out var newRight))
                {
                    Right = newRight;
                    return true;
                }

                return false;
            }

            public override long Magnitude()
            {
                return 3 * Left.Magnitude() + 2 * Right.Magnitude();
            }

            public override string ToString()
            {
                return $"[{Left},{Right}]";
            }
        }

        public class Singleton : BasePair
        {
            public Singleton(int regularNumber)
            {
                RegularNumber = regularNumber;
            }

            public int RegularNumber { get; set; }
            public override bool Explode(int level, out int left, out int right, out BasePair newPair)
            {
                left = 0;
                right = 0;
                newPair = this;
                return false;
            }

            public override void AddFromLeft(int val)
            {
                RegularNumber += val;
            }

            public override void AddFromRight(int val)
            {
                RegularNumber += val;
            }

            public override bool Split(int level, out BasePair newPair)
            {
                newPair = this;
                if (RegularNumber > 9)
                {
                    newPair = new Pair(new Singleton(RegularNumber / 2),
                        new Singleton(RegularNumber - (RegularNumber / 2)));
                    return true;
                }

                return false;
            }

            public override long Magnitude()
            {
                return RegularNumber;
            }

            public override string ToString()
            {
                return $"{RegularNumber}";
            }
        }

        static BasePair Parse(string s)
        {
            int index = 0;
            return Parse(s, ref index);
        }
        static BasePair Parse(string s, ref int index )
        {
            if (s[index] == '[')
            {
                index++;
                var left = Parse(s, ref index);
                if (s[index] != ',')
                {
                    throw new ArgumentException("no comma");
                }

                index++;
                var right = Parse(s, ref index);
                if (s[index] != ']')
                {
                    throw new ArgumentException("no closing]");
                }

                index++;
                return new Pair(left, right);
            }

            int val = Int32.Parse(s.Substring(index,1));
            index++;
            return new Singleton(val);

        }




        static void exo1()
        {
            var strings = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                .ToArray();
            int index = 0;
            /*foreach (var s in strings)
            {
                index = 0;
                Console.WriteLine(Parse(s, ref index).ToString());
            }*/



            /*index = 0;
            var test = Parse("[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]", ref index);
            index = 0;
            var test2 = Parse("[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]", ref index);
            test = Add(test, test2);
            Console.WriteLine(test);

            var reducedTest = Reduce(test);
            Console.WriteLine(reducedTest);*/


            var pairs = new List<BasePair>();
            foreach (var s in strings)
            {
                index = 0;
                pairs .Add(Parse(s, ref index));
            }

            var current = pairs[0];
            for (int i = 1; i < pairs.Count; i++)
            {
                Console.WriteLine(current);
                Console.WriteLine(pairs[i]);

                var tmp = Add(current, pairs[i]);
                //Console.WriteLine(tmp);
                current = Reduce(tmp);
                Console.WriteLine(current);
            }
            Console.WriteLine(current);
            Console.WriteLine(current.Magnitude());



        }


        static void exo2()
        {
            var strings = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                .ToArray();
            int index = 0;
            /*foreach (var s in strings)
            {
                index = 0;
                Console.WriteLine(Parse(s, ref index).ToString());
            }*/



            /*index = 0;
            var test = Parse("[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]", ref index);
            index = 0;
            var test2 = Parse("[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]", ref index);
            test = Add(test, test2);
            Console.WriteLine(test);

            var reducedTest = Reduce(test);
            Console.WriteLine(reducedTest);*/
            Console.WriteLine(Parse("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]").Magnitude());


            var pairs = new List<BasePair>();
            foreach (var s in strings)
            {
                index = 0;
                pairs .Add(Parse(s, ref index));
            }
            var tmp1 = Add(pairs[8], pairs[0]);
            Console.WriteLine(tmp1);
            Console.WriteLine(tmp1.Magnitude());
            tmp1 = Reduce(tmp1);
            Console.WriteLine(tmp1.Magnitude());


            long max = 0;
            for (int i = 0; i < pairs.Count; i++)
            {
                /*Console.WriteLine(current);
                Console.WriteLine(pairs[i]);*/
                for (int j = 0; j < pairs.Count; j++) {
                    if (i == j)
                    {
                        continue;
                    }

                    var a = Parse(strings[i]);
                    var b = Parse(strings[j]);
                    var tmp = Add(a,b);
                    //Console.WriteLine(tmp);
                    tmp = Reduce(tmp);
                    //Console.WriteLine(current);

                    max = Math.Max(max, tmp.Magnitude());


                }


            }
            Console.WriteLine(max);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            exo2();
        }
    }
}