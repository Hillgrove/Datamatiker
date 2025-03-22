namespace GraphConsoleApp
{
    internal class Edge
    {
        public Node Source { get; set; }
        public Node Target { get; set; }
        public int Cost { get; set; }

        public Edge(Node source, Node target, int cost)
        {
            Source = source;
            Target = target;
            Cost = cost;
        }
    }
}
