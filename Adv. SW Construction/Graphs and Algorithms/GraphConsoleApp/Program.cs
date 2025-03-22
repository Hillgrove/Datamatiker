using GraphConsoleApp;

//Graph graph = new Graph();

//Node nodeV = new Node("V");
//Node nodeW = new Node("W");
//Node nodeU = new Node("U");
//Node nodeX = new Node("X");
//Node nodeY = new Node("Y");
//Node nodeZ = new Node("Z");

//graph.AddNode(nodeV);
//graph.AddNode(nodeW);
//graph.AddNode(nodeU);
//graph.AddNode(nodeX);
//graph.AddNode(nodeY);
//graph.AddNode(nodeZ);

//graph.AddBidirectionalEdge(nodeV, nodeW, 3);
//graph.AddBidirectionalEdge(nodeV, nodeU, 2);
//graph.AddBidirectionalEdge(nodeV, nodeX, 2);
//graph.AddBidirectionalEdge(nodeW, nodeU, 5);
//graph.AddBidirectionalEdge(nodeW, nodeX, 3);
//graph.AddBidirectionalEdge(nodeW, nodeY, 1);
//graph.AddBidirectionalEdge(nodeW, nodeZ, 5);
//graph.AddBidirectionalEdge(nodeU, nodeX, 1);
//graph.AddBidirectionalEdge(nodeX, nodeY, 1);
//graph.AddBidirectionalEdge(nodeY, nodeZ, 2);

//OSPFAlg ospf = new OSPFAlg(graph);
//ospf.DoOSPF(nodeV);

//======================================================

Graph graph = new Graph();

AStarNode nodeA = new AStarNode("A", 0, 0);
AStarNode nodeB = new AStarNode("B", 1, 1);
AStarNode nodeC = new AStarNode("C", 2, 0);
AStarNode nodeD = new AStarNode("D", 3, 1);

graph.AddNode(nodeA);
graph.AddNode(nodeB);
graph.AddNode(nodeC);
graph.AddNode(nodeD);

graph.AddBidirectionalEdge(nodeA, nodeB, 1);
graph.AddBidirectionalEdge(nodeA, nodeC, 2);
graph.AddBidirectionalEdge(nodeB, nodeD, 3);
graph.AddBidirectionalEdge(nodeC, nodeD, 1);

AstarAlg astar = new AstarAlg(graph);
astar.DoAStar(nodeA, nodeD);