using System.Text;

namespace ConsoleGraphApp.Model
{
  /*internal class GraphModel<TVertex, TEdges>
   *                          where TVertex : IComparable
   *                          where TEdges : IEnumerable<IEnumerable<TVertex>>
   */
  internal class GraphModel<TVertex, TString> : IGraphModel<TVertex>
    where TVertex : notnull //where TString : notnull //cs8714 https://stackoverflow.com/questions/57335449/how-do-i-specify-any-non-nullable-type-as-a-generic-type-parameter-constraint
  {
    public delegate bool CallModelCMD(out object? returnValues, out string errorMessage, TVertex[]? InputArgs = null);

    /* ✓ 1. Get User Inputs
     *    ✓ Handled in ViewInstance
     */
    /// Vertices Property, stored as keys (in dict):
    ///         
    public Dictionary<TVertex, HashSet<TVertex>> AdjacencyList { get; } = new Dictionary<TVertex, HashSet<TVertex>>();
    public int EdgeCount { get; private set; }
    /* ✓ 2. Build Model
     * ✓   ► use contructor (ultimately abstract or interface type)
     * ✓     ► Add unique Vertices (use Comparable Type)
     * ✓       v0, v1, v3, v5, v8, v10
     *//* ✓     ► Build Connections as AdjacencyLists
     * ✓     { {v0 : v1, v5, v8},
     *        {v1 : v0, v10},
     * ✓     · {v2...}, not in Collection
     *        {v3 : v5},
     *        {v5 : v3}, (assumed allowed as subgraph)
     * ✓     · {v5 : v3}, duplicate, not allowed
     * ✓     · }finish ... not allowed, inconsistent! not 1e./vertex!
     *        {v8 : v0, v10},
     *        {v10: v1, v8} }
     */
    /// <summary>
    /// Constructor - using Add-Methods internally
    /// </summary> 
    /// <param name="vertices">Keys to create the dictionary</param>
    /// <param name="edges">Values respectively for each vertex's (keys) adjacent neighbors</param>
    /// <param name="message">Method and parameters, and if failed: the reason why</param>
    public GraphModel(IEnumerable<TVertex> vertices, IEnumerable<Tuple<TVertex, TVertex>> edges, out string message)
    {
      message = $"Graph constructor: \n";
      foreach (var vertex in vertices) AddVertex(vertex, out string messageAddVertex);
      foreach (var edge in edges) AddEdge(edge, out string messageAddEdge);
      foreach (var lst in AdjacencyList)
        if (lst.Value.Count < 1)
        {
          message = $"Vertex {lst.Key} has no edges. \nGraph creation aborted.";
          return;
        }
      message += "Graph successfully created!\n";
      message += " - " + AdjacencyList.Count + " Vertices in Graph Model.\n";
      message += " - " + EdgeCount + " Edges in Graph Model.\n";
      // option to combine Add-Method's out messages and allow feedback could be added
    }
    /// <summary>
    /// Subroutine - adding Vertices (dict-keys) and Hashsets as Adjacency List's (dict-values) 
    /// </summary>
    /// <param name="vertex">Adjacency List's key to be added</param>
    /// <param name="message">Method and parameters, and if failed: as reason it already exists</param>
    /// <returns></returns>
    private bool AddVertex(TVertex vertex, out string message) // (i) used for initialization (thus not accessable by interface and made private) // figure out how to do optional out params
    {
      message = $"\"addVertex {vertex}\" ";
      if (AdjacencyList.ContainsKey(vertex))
      {
        message = $"Vertex {vertex} already exists in graph";
        return false;
      }
      AdjacencyList[vertex] = new HashSet<TVertex>();
      return true;
    }

    /* 4. Work with Model   
     * Create ➕   Read 📋   Update 🗘   Delete 🗑    ("...") = not exposed to ui
     *//*    ►►
     *  ✓ Handled by datastructure: (  ➕ public Graph00(Collection vertices)  )
     * (  ➕ public Graph00(Collection vertices, Collection<Collection> edgeList) : this(vertices)  )
     * 📋  public string ListEdges()
     * 🗑  public bool DeleteEdge(int x, int y)
     * 📋  public string GetNeighbours(int x)
     * 🗘  public void AddEdge(int x, int y)
     * 📋  public bool IsCompleteGraph()
     * 🗑  public void DeleteVertice(int x)
     * 📋  public string ListVertices()
     */
    /* 4.1. Decision on appropiate Method signature:
     * (keeping in Mind:
     *   - Keep all the same to
     *     - allow extension of method list
     *     - provide option for delegates
     *     - make interface / abstract base class simpler to implement
     *   - "returnValues" Database storage: Can't only return string
     *   - "errorMessage" Independency: needs to output message if not working
     *   - "InputArgs"   Diversity: allow differing Parameter length 
     * - public bool MethodName(out object? returnValues, out string errorMessage, string[]? InputArgs = null)
     */

    /// <summary>
    /// Building a string of vertex collection in graph according feture requests
    /// </summary>
    /// <param name="vertexNeighborList"></param>
    /// <param name="message"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public bool ListEdges(out object? edgeListStr, out string message, TVertex[]? args = null)
    {
      message = "ListEdges:\n";
      edgeListStr = "";
      var str = new StringBuilder(" - ");
      if (!ListEdges(out List<Tuple<TVertex, TVertex>> edgeList))
      {
        message += " - Error: check if graph has vertices and edges.";
        return false;
      }
      foreach (var edge in edgeList)
        str.Append($"({edge.Item1},{edge.Item2}),");
      str.Remove(str.Length - 1, 1);
      edgeListStr = str.ToString();
      return true;
    }
    /// <summary>
    /// purely functional subroutine to get "List<Tuple<TVertex, TVertex>> edges"
    /// </summary>
    /// <param name="edges"></param>
    /// <returns></returns>
    private bool ListEdges(out List<Tuple<TVertex, TVertex>> edges)
    {
      edges = new List<Tuple<TVertex, TVertex>>();
      foreach (var vertex in AdjacencyList.Keys)
      {
        foreach (var otherVertex in AdjacencyList[vertex])
        {
          var tuple = Tuple.Create(vertex, otherVertex);
          if (!(edges.Contains(tuple)
              || edges.Contains(Tuple.Create(otherVertex, vertex))))
            edges.Add(tuple);
        }
      }
      return true;
    }
    /// <summary>
    /// Building a string of edge collection in graph according feture requests
    /// </summary>
    /// <param name="vertexNeighborList">Vertex Neighbors as string</param>
    /// <param name="message">containing Name and errors if any</param>
    /// <param name="args">To be left empty</param>
    /// <returns></returns>
    public bool DeleteEdge(out object? returnValues, out string message, TVertex[]? InputArgs)
    {
      message = "";
      int edgeCountBefore = EdgeCount;
      returnValues = null;
      if (InputArgs == null)
      {
        message += "\nError: Vertex (parameter: TVertex[]? InputArg) cannot be null.";
        return false;
      }
      if (!DeleteEdge(Tuple.Create(InputArgs[0], InputArgs[1]), out message))
        return false;
      int edgeCountAfter = EdgeCount;
      returnValues += $"\nDeleting Edge succeded. EdgeCout (before/after): ({edgeCountBefore}/{edgeCountAfter})";
      return true;
    }
    private bool DeleteEdge(Tuple<TVertex, TVertex> edge, out string message)
    {
      message = $"\"DeleteEdge ({edge.Item1},{edge.Item2})\"";
      // feature: validate 1 edge per vertex:
      if (AdjacencyList[edge.Item1].Count < 2 || AdjacencyList[edge.Item2].Count < 2)
      {
        message += "removing this edge would invalidate the graph";
        return false;
      }
      if (!(AdjacencyList[edge.Item1].Remove(edge.Item2) && AdjacencyList[edge.Item2].Remove(edge.Item1)))
      {
        message += "edge not found";
        return false;
      }
      EdgeCount--;
      return true;
    }
    public bool GetNeighbours(out object? vertexNeighborList, out string message, TVertex[]? InputArgs)
    {
      message = "List Neighbor Vertices:\n";
      if (InputArgs == null)
      {
        vertexNeighborList = null;
        message += "\nError: Vertex (parameter: TVertex[]? InputArg) cannot be null.";
        return false;
      }
      TVertex vert = InputArgs[0];
      var str = new StringBuilder(" - ");
      if (!GetNeighbours(vert, out object vertices, out string sth))
      {
        vertexNeighborList = null;
        message += "\nError: check if graph has vertices.";
        return false;
      }
      foreach (var vertex in (HashSet<TVertex>)vertices)
        str.Append($"{vertex},");
      str.Remove(str.Length - 1, 1);
      vertexNeighborList = str.ToString();
      return true;
    }
    private bool GetNeighbours(TVertex vertex, out object vertexNeighborList, out string message)
    {
      message = $"\"GetNeighbours {vertex}\" ";
      vertexNeighborList = new HashSet<TVertex>();
      if (!AdjacencyList.ContainsKey(vertex))
      {
        message += $"vertex {vertex} doesn't eixist";
        return false;
      }
      vertexNeighborList = AdjacencyList[vertex];
      return true;
    }
    /// <summary>
    /// Adding edge to graph instance
    ///  - checks if edge vertices are present
    ///  - checks if edge already exists (#feature)
    ///  (i) for Constructor: Filling each concerned Vertex's HashSet with adjacent Vertices as Values
    /// </summary>
    /// <param name="edge">Generic Tuple, containing Graph Instance Vertices to be made adjacent</param>
    /// <param name="message">Method and parameters, and if failed: the reason why</param>
    /// <returns></returns>
    public bool AddEdge(out object? returnValues, out string errorMessage, TVertex[]? InputArgs)
    {
      int edgeCountBefore = EdgeCount;
      returnValues = null;
      errorMessage = "ListVertices:\n";
      if (InputArgs == null)
      {
        errorMessage += "\nError: Vertex (parameter: TVertex[]? InputArg) cannot be null.";
        return false;
      }
      if (!AddEdge(Tuple.Create(InputArgs[0], InputArgs[1]), out errorMessage))
        return false;
      int edgeCountAfter = EdgeCount;
      returnValues += $"\nInserting Edge succeded. EdgeCout (before/after): ({edgeCountBefore}/{edgeCountAfter})";
      return true;
    }
    private bool AddEdge(Tuple<TVertex, TVertex> edge, out string message) // (i) used for initialization
    {
      message = $"\"AddEdge ({edge.Item1},{edge.Item2})\"";
      // keep parameters, split string in display, check if all after [0] contains more than one integer
      // test if vertices are present in graph
      if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
      {
        if (AdjacencyList[edge.Item1].Contains(edge.Item2))
        {
          message = $"edge ({edge.Item1},{edge.Item2}) already exists in graph"; // #feature
          return false;
        }
        AdjacencyList[edge.Item1].Add(edge.Item2);
        AdjacencyList[edge.Item2].Add(edge.Item1);
        EdgeCount++;
        return true;
      }
      var vertex = !(AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2)) ? $"{edge.Item1},{edge.Item2}" :
                   !AdjacencyList.ContainsKey(edge.Item1) ? $"{edge.Item1}" :
                   !AdjacencyList.ContainsKey(edge.Item2) ? $"{edge.Item2}" : "error with logic occurred"; // get missing Vertex
      message += $"Vertices {vertex} don't exist in the graph";
      return false;
    }
    public bool IsCompleteGraph(out object? result, out string message, TVertex[]? args = null)
    {
      /// Possible Performance boost with simple calculation
      /// since EdgeCount became a Property..
      message = "IsCompleteGraph:\n";
      result = false;
      foreach (var key in AdjacencyList.Keys)
        if (AdjacencyList[key].Count != AdjacencyList.Count - 1)
        {
          message += $" - not complete, Vertex {key} has only " +
            $"{AdjacencyList[key].Count} adjacent neighbors, while " +
            $"the graph has {AdjacencyList.Count} Vertices";
          result = false;
          return true;
        }
      result = true;
      return true;
    }
    public bool DeleteVertice(out object? _, out string message, TVertex[]? InputArgs)
    {
      message = $"\"DeleteVertice:";
      _ = 0; // preventig errors with null in controller..
      if (InputArgs == null)
      {
        message += "\nError: Vertex (parameter: TVertex[]? InputArg) cannot be null.";
        return false;
      }
      TVertex vertex = InputArgs[0];
      message += $" {vertex}\" ";
      if (AdjacencyList.ContainsKey(vertex))
      {
        // feature: validate 1 edge per vertex:
        //if (AdjacencyList[vertex].Count < 2)
        //{
        //  message += "removing this vertex would invalidate the graph";
        //  return false;
        //}
        var str = new StringBuilder("Problems: ");

        int edgeCountBefore = EdgeCount;
        int vertNBefore = AdjacencyList.Count;
        foreach (var vertNeighbor in AdjacencyList[vertex]) // get all neighbors
        {
          if (AdjacencyList[vertNeighbor].Count < 2)
          {
            str.Append($"removing this vertex would invalidate the graph, " +
              $"neighbor {vertNeighbor} has no other neighbors");
            message += str.ToString();
            return false;
          }
          if (!AdjacencyList[vertNeighbor].Remove(vertex)) // delete itself from their lists
          {
            str.Append($" adjacency list of {vertNeighbor} doesn't contain vertex {vertex}"); // (should never happen)
            message += str.ToString();
          }
          else
          {
            //if (!AdjacencyList[vertex].Remove(vertNeighbor)) // delete neighbor from own list
            //{
            //  str.Append($" adjacency list of this vertex:{vertex} doesn't contain " +
            //    $"vertex neighbor: {vertNeighbor}, eventhough it was on their list"); // (should never happen)
            //  message += str.ToString();
            //}
            EdgeCount--;
          }
          AdjacencyList.Remove(vertex); // finally remove own entry
        }
        //message += str.ToString();
        message += "\n Deleting vertex worked!" +
           $"\nVertex count (before/after) ({vertNBefore}/{AdjacencyList.Count})" +
           $"\nDeleting Edge succeded. EdgeCout (before/after): ({edgeCountBefore}/{EdgeCount})";
        return true;
      }
      message += $"Vertex {vertex} doesn't exist";
      return false;
    }
    public bool ListVertices(out object? vertexNeighborList, out string message, TVertex[]? args = null)
    {
      message = "ListVertices:\n";
      var str = new StringBuilder(" - ");
      if (!ListVertices(out HashSet<TVertex> vertices))
      {
        vertexNeighborList = null;
        message += "\nError: check if graph has vertices.";
        return false;
      }
      //vertexNeighborList = vertices;
      foreach (var vertex in vertices)
        str.Append($"{vertex},");
      str.Remove(str.Length - 1, 1);
      vertexNeighborList = str.ToString();
      return true;
    }
    /// <summary>
    /// purely functional subroutine to get "HashSet<TVertex> vertexList"
    /// </summary>
    /// <param name="vertexList"></param>
    /// <returns></returns>
    private bool ListVertices(out HashSet<TVertex> vertexList)
    {
      vertexList = new HashSet<TVertex>();
      if (AdjacencyList.Count < 1)
        return false;
      TVertex[] arr = new TVertex[AdjacencyList.Keys.Count];
      AdjacencyList.Keys.CopyTo(arr, 0);
      vertexList = new HashSet<TVertex>(arr);
      return true;
    }
  }
}
