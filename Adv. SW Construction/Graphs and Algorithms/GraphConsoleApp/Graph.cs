namespace GraphConsoleApp
{
    internal class Graph
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<Edge> Edges { get; set; } = new List<Edge>();

        public void AddNode(Node node)
        {
            if (Nodes.Any(n => n.Id == node.Id))
                Console.WriteLine($"Node {node.Id} already added.");
            
            else
                Nodes.Add(node);
                Console.WriteLine($"Node {node.Id} added.");
        }

        public void AddBidirectionalEdge(Node node1, Node node2, int cost)
        {
            AddEdge(new Edge(node1, node2, cost));
            AddEdge(new Edge(node2, node1, cost));
        }

        public Node? GetNode(string id)
        {
            return Nodes.FirstOrDefault(n => n.Id == id);
        }

        private void AddEdge(Edge edge)
        {
            if (Edges.Any(e => e.Source == edge.Source && e.Target == edge.Target))
                Console.WriteLine($"Edge ({edge.Source.Id}, {edge.Target.Id}) already added.");
            
            else
                Edges.Add(edge);
                Console.WriteLine($"Edge ({edge.Source.Id}, {edge.Target.Id}) added.");
        }
    }
}
