using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Lab4 {
    public class GraphTools {
        private readonly List<List<int>> Graph;

        public GraphTools(List<List<int>> s1) {
            this.Graph = s1;
        }

        public bool HasCycle_DFS(int v, List<bool> visited, int parent) {
            visited[v] = true;
            foreach (var u in Graph[v]) {
                if (!visited[u]) {
                    if (HasCycle_DFS(u, visited, v)) {
                        return true;
                    }
                }
                else if (u != parent) {
                    return true;
                }
            }
            return false;
        }


        public List<int> GetShortestPath(int start, int end) {

            if (start >= Graph.Count || start < 0 || end >= Graph.Count || end < 0) {
                Console.WriteLine("Invalid starting or ending vertices.");
                return null;
            }

            Queue<int> Q = new Queue<int>();
            List<bool> visited = new List<bool>();
            visited.AddRange(Enumerable.Repeat(false, Graph.Count));

            int[] parent = new int[Graph.Count];
            for (int i = 0; i < parent.Length; i++) {
                parent[i] = -1;
            }

            visited[start] = true;
            Q.Enqueue(start);

            bool isFound = false;

            while (Q.Count != 0) {
                var v = Q.Dequeue();

                if (v == end) {
                    isFound = true;
                    break;
                }

                foreach (var item in Graph[v]) {
                    if (!visited[item]) {
                        visited[item] = true;
                        parent[item] = v;
                        Q.Enqueue(item);
                    }
                }
            }

            List<int> path = new List<int>();
            if (isFound) {
                int current = end;
                while (current != -1) {
                    path.Add(current);
                    current = parent[current];
                }
                path.Reverse();
            }
            else {
                Console.WriteLine("Path isn't found");
            }

            return path;
        }

        public List<int> FindPathWithDFS(int start, int end) {
            if (start >= Graph.Count || start < 0 || end >= Graph.Count || end < 0) {
                Console.WriteLine("Invalid starting or ending vertices.");
                return null;
            }

            Stack<int> S = new Stack<int>();
            List<bool> visited = new List<bool>();

            visited.AddRange(Enumerable.Repeat(false, Graph.Count));

            int[] parent = new int[Graph.Count];
            for (int i = 0; i < parent.Length; i++) {
                parent[i] = -1;
            }

            bool isFound = false;

            S.Push(start);
            while (S.Count != 0) {
                var v = S.Pop();

                if (v == end) {
                    isFound = true;
                    break;
                }

                if (!visited[v]) {
                    visited[v] = true;
                    foreach (var x in Graph[v]) {
                        if (!visited[x]) {
                            parent[x] = v;
                            S.Push(x);
                        }
                    }
                }
            }

            List<int> path = new List<int>();
            if (isFound) {
                int current = end;
                while (current != -1) {
                    path.Add(current);
                    current = parent[current];
                }
                path.Reverse();
            }
            else {
                Console.WriteLine("Path isn't found");
            }

            return path;
        }

        public List<List<int>> TransponGraph() {
            List<List<int>> transponsedGraph = new List<List<int>>();

            for (int i = 0; i < Graph.Count; i++) {
                transponsedGraph.Add(new List<int>());
            }


            foreach (var vertex in Graph) {
                foreach (int item in vertex) {
                    transponsedGraph[item].Add(Graph.IndexOf(vertex));
                }
            }
            return transponsedGraph;
        }

    }
}
