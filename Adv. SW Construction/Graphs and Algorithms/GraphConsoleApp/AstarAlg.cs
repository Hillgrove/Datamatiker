namespace GraphConsoleApp
{
    internal class AstarAlg
    {
        private readonly Graph _graph;

        public AstarAlg(Graph graph)
        {
            _graph = graph;
        }

        public void DoAStar(AStarNode startNode, AStarNode endNode)
        {
            var openSet = new PriorityQueue<AStarNode, double>();
            var cameFrom = new Dictionary<AStarNode, AStarNode>();
            var gScore = new Dictionary<AStarNode, double>();
            var fScore = new Dictionary<AStarNode, double>();

            // TODO: test if .OfType is required
            foreach (var node in _graph.Nodes.OfType<AStarNode>())
            {
                gScore[node] = double.MaxValue;
                fScore[node] = double.MaxValue;
            }

            gScore[startNode] = 0;
            fScore[startNode] = Heuristica.EstimateDistance(startNode, endNode);
            openSet.Enqueue(startNode, fScore[startNode]);

            while (openSet.Count > 0)
            {
                var current = openSet.Dequeue();

                if (current == endNode)
                {
                    Console.WriteLine($"Found path to {endNode.Id} with cost {gScore[current]}.");
                    ReconstructPath(cameFrom, current);
                    return;
                }

                foreach (var edge in _graph.Edges.Where(e => e.Source == current))
                {
                    var neighbor = (AStarNode)edge.Target;
                    double tentative_gScore = gScore[current] + edge.Cost;

                    if (tentative_gScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentative_gScore;
                        fScore[neighbor] = gScore[neighbor] + Heuristica.EstimateDistance(neighbor, endNode);

                        if (!openSet.UnorderedItems.Any(x => x.Element == neighbor))
                        {
                            openSet.Enqueue(neighbor, fScore[neighbor]);
                        }
                    }
                }
            }
        }

        private void ReconstructPath(Dictionary<AStarNode, AStarNode> cameFrom, AStarNode current)
        {
            var path = new List<string> { current.Id };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                path.Add(current.Id);
            }

            path.Reverse();
            Console.WriteLine("Path: " + string.Join(" -> ", path));
        }
    }

    internal class AStarNode: Node
    {
        public int X { get; set; }
        public int Y { get; set; }

        public AStarNode(string id, int x, int y) : base(id)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(AStarNode other)
        {
            return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }
    }

    internal static class Heuristica
    {
        public static double EstimateDistance(AStarNode from, AStarNode to)
        {
            return from.DistanceTo(to);
        }
    }
}
