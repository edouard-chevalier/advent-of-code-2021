// See https://aka.ms/new-console-template for more information


using System.Diagnostics;

namespace Day12
{
    class Program
    {
        private const string inputTestMini = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";
        private const string inputTest = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";
        private const string inputTestLarge = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";

        private const string input = @"vp-BY
ui-oo
kk-IY
ij-vp
oo-start
SP-ij
kg-uj
ij-UH
SP-end
oo-IY
SP-kk
SP-vp
ui-ij
UH-ui
ij-IY
start-ui
IY-ui
uj-ui
kk-oo
IY-start
end-vp
uj-UH
ij-kk
UH-end
UH-kk
";





        static void exo1()
            {

                var strings = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                    .ToArray();
                var smallCaves = new HashSet<string>();
                var graph = new Dictionary<string, HashSet<string>>();

                void AddEdge(string a, string b)
                {
                    if (a.ToLowerInvariant() == a)
                    {
                        smallCaves.Add(a);
                    }
                    if (b.ToLowerInvariant() == b)
                    {
                        smallCaves.Add(b);
                    }
                    if (!graph.TryGetValue(a, out var e))
                    {
                        e = new HashSet<string>();
                        graph[a] = e;
                    }

                    e.Add(b);
                    if (!graph.TryGetValue(b, out var f))
                    {
                        f = new HashSet<string>();
                        graph[b] = f;
                    }

                    f.Add(a);
                }
                foreach (var s in strings)
                {
                    var tmp = s.Split("-") ;
                    AddEdge(tmp[0], tmp[1]);
                }

                long sum = 0;

                void Visit(string node, HashSet<string> visited )
                {
                    if (node == "end")
                    {
                        sum++;
                        return;
                    }

                    if (visited.Contains(node))
                    {
                        return;
                    }

                    if (smallCaves.Contains(node))
                    {
                        visited.Add(node);
                    }

                    var connected = graph[node].ToArray();
                    foreach (var n in connected)
                    {
                        var newVisited = new HashSet<string>( visited);

                        Visit(n, newVisited);
                    }

                }

                Visit("start", new HashSet<string>());



                Console.WriteLine(sum);


            }

            static void exo2()
            {  var strings = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                    .ToArray();
                var smallCaves = new HashSet<string>();
                var graph = new Dictionary<string, HashSet<string>>();

                void AddEdge(string a, string b)
                {
                    if (a.ToLowerInvariant() == a)
                    {
                        smallCaves.Add(a);
                    }
                    if (b.ToLowerInvariant() == b)
                    {
                        smallCaves.Add(b);
                    }
                    if (!graph.TryGetValue(a, out var e))
                    {
                        e = new HashSet<string>();
                        graph[a] = e;
                    }

                    e.Add(b);
                    if (!graph.TryGetValue(b, out var f))
                    {
                        f = new HashSet<string>();
                        graph[b] = f;
                    }

                    f.Add(a);
                }
                foreach (var s in strings)
                {
                    var tmp = s.Split("-") ;
                    AddEdge(tmp[0], tmp[1]);
                }

                long sum = 0;

                void Visit(string node, HashSet<string> visited, string? extra, List<string> path )
                {
                    if (node == "end")
                    {
                        Console.WriteLine(string.Join(",", path));
                        sum++;
                        return;
                    }



                    var connected = graph[node].ToArray();
                    var newPath = new List<string>(path);
                    newPath.Add( node);

                    if (smallCaves.Contains(node))
                    {
                        if (visited.Contains(node))
                        {
                            // we try with it as extra if possible
                            if (extra == null && node != "start") {
                                foreach (var n in connected) {
                                    var newVisited = new HashSet<string>( visited);
                                    var newnewPath = new List<string>(newPath);

                                    Visit(n, newVisited, node, newnewPath );
                                }
                            }
                            return;
                        }
                            visited.Add(node);
                    }

                    foreach (var n in connected)
                    {
                        var newVisited = new HashSet<string>( visited);
                        var newnewPath = new List<string>(newPath);

                        Visit(n, newVisited, extra, newnewPath);
                    }

                }

                Visit("start", new HashSet<string>(), null, new List<string>());



                Console.WriteLine(sum);

            }

            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                exo2();
            }
    }
}