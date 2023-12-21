using System.Collections.Generic;
using System.Numerics;
using System;

namespace ProjectEuler.Problems
{
    internal class Problem60 : ProblemBase<Problem60>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            PrimeChecker primeChecker = new();
            bool AreConcatenaintable(int prime1, int prime2)
            {
                if (!primeChecker.IsPrime((BigInteger.Pow(10, (int)Math.Log10(prime2) + 1)) * prime1 + prime2)) return false;
                if (!primeChecker.IsPrime((BigInteger.Pow(10, (int)Math.Log10(prime1) + 1)) * prime2 + prime1)) return false;
                return true;
            }
            Graph<int> graph = new();
            int i = 3, answer = int.MaxValue / 2;
            while (i < (answer + 12))
            {
                if (primeChecker.IsPrime(i))
                {
                    Vertex<int> new_vertex = new(i);
                    List<Vertex<int>> neighbours = new();
                    foreach (Vertex<int> v in graph.Vertices)
                    {
                        if (AreConcatenaintable(i, v.Value)) neighbours.Add(v);
                    }
                    new_vertex.AddNeighbours(neighbours);
                    graph.AddVertex(new_vertex);
                    foreach (Vertex<int> v in neighbours) v.AddNeighbour(new_vertex);
                    List<List<Vertex<int>>> cliques = graph.FindCliques(5);
                    if (cliques.Count > 0)
                    {
                        foreach (List<Vertex<int>> clique in cliques)
                        {
                            int sum = 0;
                            foreach (Vertex<int> v in clique)
                            {
                                sum += v.Value;
                            }
                            if (sum < answer) answer = sum;
                        }
                    }
                }
                i++;
            }
            return answer.ToString();
        }
    }
}

