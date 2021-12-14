// See https://aka.ms/new-console-template for more information


using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace Day13
{
    class Program
    {

        private const string inputTest = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";


        private const string input = @"CNBPHFBOPCSPKOFNHVKV

CS -> S
FB -> F
VK -> V
HO -> F
SO -> K
FK -> B
VS -> C
PS -> H
HH -> P
KH -> V
PV -> V
CB -> N
BB -> N
HB -> B
HV -> O
NC -> H
NF -> B
HP -> B
HK -> S
SF -> O
ON -> K
VN -> V
SB -> H
SK -> H
VH -> N
KN -> C
CC -> N
BF -> H
SN -> N
KP -> B
FO -> N
KO -> V
BP -> O
OK -> F
HC -> B
NH -> O
SP -> O
OO -> S
VC -> O
PC -> F
VB -> O
FF -> S
BS -> F
KS -> F
OV -> P
NB -> O
CF -> F
SS -> V
KV -> K
FP -> F
KC -> C
PF -> C
OS -> C
PN -> B
OP -> C
FN -> F
OF -> C
NP -> C
CK -> N
BN -> K
BO -> K
OH -> S
BH -> O
SH -> N
CH -> K
PO -> V
CN -> N
BV -> F
FV -> B
VP -> V
FS -> O
NV -> P
PH -> C
HN -> P
VV -> C
NK -> K
CO -> N
NS -> P
VO -> P
CP -> V
OC -> S
PK -> V
NN -> F
SC -> P
BK -> F
BC -> P
FH -> B
OB -> O
FC -> N
PB -> N
VF -> N
PP -> S
HS -> O
HF -> N
KK -> C
KB -> N
SV -> N
KF -> K
CV -> N
NO -> P
";





        static void exo1()
            {

                var strings = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                    .ToArray();

                var elements = strings[0].ToList();
                Dictionary<(char a, char b), char> pairs = strings.Skip(1)
                    .Select(s => s.Split("->", StringSplitOptions.TrimEntries))
                    .ToDictionary(a => (a[0][0], a[0][1]), a => a[1][0]);

                var newElements = new List<char>();
                for (int step = 0; step < 10; step++)
                {
                    newElements.Add(elements[0]);
                    for (int i = 1; i < elements.Count; i++) {
                        if (pairs.TryGetValue((elements[i - 1], elements[i]), out var newEl))
                        {
                            newElements.Add(newEl);
                        }
                        newElements.Add(elements[i]);
                    }
                    elements.Clear();
                    elements.AddRange(newElements);
                    newElements.Clear();
                }

                Dictionary<char, int> count = new Dictionary<char, int>();
                foreach (var element in elements)
                {
                    if (count.TryGetValue(element, out var c))
                    {
                        count[element] = c + 1;
                    }
                    else
                    {
                        count[element] = 1;
                    }
                }


                Console.WriteLine(count.Values.Max() - count.Values.Min());


            }



            static void exo2() {
                var strings = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                    .ToArray();

                var startingElements = strings[0].ToList();
                Dictionary<(char a, char b), char> pairs = strings.Skip(1)
                    .Select(s => s.Split("->", StringSplitOptions.TrimEntries))
                    .ToDictionary(a => (a[0][0], a[0][1]), a => a[1][0]);
                int nbSteps = 40;
                var alphabets = pairs.Values.Distinct().ToArray();

                Dictionary<(char a, char b), Dictionary<char, long>[]> cache =
                    new Dictionary<(char a, char b), Dictionary<char, long>[]>();
                foreach (var pair in pairs.Keys)
                {
                    var occurences = new Dictionary<char, long>[nbSteps];

                    occurences[0] = new Dictionary<char, long>();
                    foreach (var alphabet in alphabets)
                    {
                        occurences[0][alphabet] = 0L;
                    }

                    occurences[0][pair.a]++;
                    occurences[0][pairs[(pair.a,pair.b)]]++;
                    cache[pair] = occurences;

                }

                Dictionary<char, Dictionary<char, long>> NoPairs = new Dictionary<char, Dictionary<char, long>>();
                foreach (var alphabet in alphabets)
                {
                    var noPair = new Dictionary<char, long>();
                    foreach (var c in alphabets)
                    {
                        noPair[c] = 0;
                    }

                    noPair[alphabet] = 1;
                    NoPairs[alphabet] = noPair;
                }

                Dictionary<char, long> Merge(Dictionary<char, long> left, Dictionary<char, long> right)
                {
                    Dictionary<char, long> res = new Dictionary<char, long>();
                    foreach (var alphabet in alphabets) {
                        res[alphabet] = left[alphabet] + right[alphabet];
                    }

                    return res;
                }
                Dictionary<char, long> GetOccurences(char a, char b, int noStep) {
                    if (!cache.TryGetValue((a, b), out var resPerStep))
                    {
                        return NoPairs[a];
                    }

                    if (resPerStep[noStep] != null)
                    {
                        return resPerStep[noStep];
                    }

                    char mid = pairs[(a, b)];
                    var res = Merge(GetOccurences(a, mid, noStep - 1), GetOccurences(mid, b, noStep - 1));
                    resPerStep[noStep] = res;
                    return res;
                }

                Dictionary<char, long> count = null;
                for (int i = 1; i < startingElements.Count; i++) {
                    var tmp = GetOccurences(startingElements[i-1], startingElements[i], nbSteps -1);
                    if (count == null)
                    {
                        count = tmp;
                    }
                    else
                    {
                        count = Merge(count, tmp);
                    }

                }

                count[startingElements.Last()]++;

                Console.WriteLine(count.Values.Max() - count.Values.Min());
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                exo2();
            }
    }
}