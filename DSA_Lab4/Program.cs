using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Lab4 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("\n!!!TASK 1!!!\n");
            Console.WriteLine("\n!!!GRAPH!!!\n");
            List<List<int>> adjGraph = new List<List<int>> {
                new List<int>() { 1, 3 },
                new List<int>() { 0, 2 },
                new List<int>() { 1, 3, 4 },
                new List<int>() { 0, 2 },
                new List<int>() { 2 }
            };

            foreach (var component in adjGraph) {
                Console.Write($"Node {adjGraph.IndexOf(component)}\nLinks: ");
                foreach (var link in component) {
                    Console.Write(link + " ");
                }
                Console.WriteLine("\n");
            }

            GraphTools graphTools = new GraphTools(adjGraph);
            List<bool> visited = new List<bool>();
            visited.AddRange(Enumerable.Repeat(false, adjGraph.Count));

            Console.WriteLine("\n!!!There is any cycles in a Graph!!!\n");
            Console.WriteLine(graphTools.HasCycle_DFS(0, visited, -1));

            Console.WriteLine("\n!!!TASK 2!!!\n");

            Console.WriteLine("\n!!!CITIES!!!\n");

            List<List<int>> citiesGraph = new List<List<int>> {
                new List<int>() { 1, 3 },
                new List<int>() { 0, 2, 4 },
                new List<int>() { 1, 5 },
                new List<int>() { 0, 4 },
                new List<int>() { 1, 3, 6 },
                new List<int>() { 2, 7 },
                new List<int>() { 4, 7 },
                new List<int>() { 5, 6 },
            };

            foreach (var city in citiesGraph) {
                Console.Write($"City {citiesGraph.IndexOf(city)}\nConnected with: ");
                foreach (var roadTo in city) {
                    Console.Write(roadTo + " ");
                }
                Console.WriteLine("\n");
            }

            GraphTools cityTools = new GraphTools(citiesGraph);
            List<int> path = cityTools.GetShortestPath(0, 7);

            Console.WriteLine("Shortest path between 0 and 7: ");
            foreach (var city in path) {
                Console.Write(city + " ");
            }
            Console.WriteLine("\n");

            for (int i = 0; i < citiesGraph.Count; i++) {
                path = cityTools.GetShortestPath(0, i);
                Console.WriteLine($"Minimal road amount to reach from 0 to {i}: {path.Count - 1}");
                path = null;
            }

            path = cityTools.FindPathWithDFS(0, 7);
            Console.WriteLine("Shortest path between 0 and 7 (DFS): ");
            foreach (var city in path) {
                Console.Write(city + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("\n!!!TASK 3a!!!\n");

            Console.WriteLine("Graph: \n");

            List<List<int>> directedGraph = new List<List<int>> {
                new List<int>() { 1 },    // 0 вказує на 1
                new List<int>() { 2 },    // 1 вказує на 2
                new List<int>() { }       // 2 нікуди не вказує
            };

            foreach (var component in directedGraph) {
                Console.Write($"Node {directedGraph.IndexOf(component)}\nLinks: ");
                foreach (var link in component) {
                    Console.Write(link + " ");
                }
                Console.WriteLine("\n");
            }

            GraphTools dirTools = new GraphTools(directedGraph);

            List<List<int>> transponsedGraph = dirTools.TransponGraph();

            Console.WriteLine("Results: \n");

            foreach (var component in transponsedGraph) {
                Console.Write($"Node {transponsedGraph.IndexOf(component)}\nLinks: ");
                foreach (var link in component) {
                    Console.Write(link + " ");
                }
                Console.WriteLine("\n");
            }


            Console.WriteLine("\n\nPress Enter to exit...\n");
            Console.ReadLine();

        }
    }
}
