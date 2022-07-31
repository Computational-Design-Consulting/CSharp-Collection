using ConsoleGraphApp.Controller;

var controller = new Controller();

/*
 * "Hello there,"+
 *  "This is an app to create a simple undirected graph in which every pair of distinct vertices is connected by a unique edge."+
 *  "To start creating the graph, please input the unique vertices-ids as in the following example:"+
 *  "\"1,2,4,10,11\" + Enter"+
 *  "Please make sure to use positive integer values only."
 *
 *  // store vertices (build Graph)
 *
 *  "How would you like to connect the provided vertices?"+
 *  "Please enter one connection per line (\"1,4\" + Enter ...)"+
 *  "Hit \"Enter\" again when finished, in order to complete the graph." //-issue 01 addressed
 *  //"(The order of entries has no effect on the graph)"
 *
 *  //-issue 01: 4,2 followed by 11,10 could be read as 4,21 followed by 1,10
 *
 *  // store connections (Complete Graph)
 *
 *  "The creation of the graph has finished successfully!"+
 *  "You can now start editing using:"+
 *  // check efficient implementation order (is time complexity more relevant than space?)
 *  // list following accordingly
 *
 *
 *  ListEdges
 *      (1,2),(4,2),(10,11)
 *
 *  DeleteEdge X,Y
 *  try
 *      delete edge(x,y) to graph
 *  catch (!EdgeExists)
 *      message
 *
 *  GetNeighbours X
 *      1,4,...
 *
 *  AddEdge X,Y
 *  try
 *      add edge(x,y) to graph
 *  catch (EdgeExists)
 *      message
 *  // issue 02: -what if vertices don't exist 
 *
 *  IsCompleteGraph
 *      bool
 *  // TODO graph completeness (every pair of distinct vertices is connected by a unique edge)
 *
 *  DeleteVertice X
 *  try
 *      remove vertices, remove edges
 *  catch (invalid graph)
 *      message
 *  // issue 03: -vertice not found
 *  // TODO define graph validity - 
 *
 *  ListVertices
 *      1,2,4,10,11
 *  catch (no vertices)
 *      message
 *
 *  App:
 *  .Net core
 *  no external dependencies
 *  new data structures and models representing parts of the graph (like vertices, edges etc.)
 *  references for inspiration as comments above class/function
 *  no implementation to be repeated for new front-end (i.e. web app, text files)
 *
 *  Functionality:
 *  create a graph based on inputs
 *  processed by commands
 *
 *  Undirected Graph:
 *  no duplicate edges (=> no looping)
 *  no duplicate vertices
 *  min one edge per vetice -> min 2 vertices and one edge to form a graph
 *
 *  connected - pathes to all nodes are possible
 *  disconnected - nodes or parts cannot be reached
 *  adjacent nodes - nodes that are connected directly
 */