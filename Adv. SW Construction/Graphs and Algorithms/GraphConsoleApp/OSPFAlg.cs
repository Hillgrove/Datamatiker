namespace GraphConsoleApp
{
    internal class OSPFAlg
    {
        private Graph _graph;
        
        public OSPFAlg(Graph graph)
        {
            _graph = graph;
        }

        public void DoOSPF(Node startNode)
        {
            var distances = new Dictionary<Node, int>();
            var previousNodes = new Dictionary<Node, Node?>();
            var priorityQueue = new PriorityQueue<Node, int>();

            foreach (var node in _graph.Nodes)
            {
                distances[node] = int.MaxValue;
                previousNodes[node] = null;
            }

            distances[startNode] = 0;
            priorityQueue.Enqueue(startNode, 0);

            while (priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.Dequeue();
                int currentDistance = distances[currentNode];

                foreach (var edge in _graph.Edges.Where(e => e.Source == currentNode))
                {
                    var neighbor = edge.Target;
                    int newDistance = currentDistance + edge.Cost;

                    if (newDistance < distances[neighbor])
                    {
                        distances[neighbor] = newDistance;
                        previousNodes[neighbor] = currentNode;
                        priorityQueue.Enqueue(neighbor, newDistance);
                    }
                }
            }

            Console.WriteLine($"\nShortest paths from {startNode.Id} to:");
            foreach (var node in _graph.Nodes)
            {
                if (distances[node] == int.MaxValue)
                {
                    Console.WriteLine($"Node {node.Id} is unreachable");
                    continue;
                }

                Console.Write($"\nNode {node.Id} \n- Distance: {distances[node]} \n- Path: ");
                var path = new List<string>();
                for (var at = node; at != null; at = previousNodes[at])
                {
                    path.Add(at.Id);
                }
                path.Reverse();
                Console.WriteLine(string.Join(" -> ", path));
            }
        }
    }
}
