using System.Text;

namespace ConsoleGraphApp.View
{
  public class View<TVertex, TEdges> : IView<int>
                      where TVertex : IComparable<TVertex>
                      where TEdges : IEnumerable<IEnumerable<TVertex>>
  {
    #region graph object creation
    /* ! (first all in one, than extract base class)
     *//*✓ 0. Great User
     * ✓   ► Print string
     */
    /// <summary>
    /// Start App with this string - public so skipping custom graph creation is possible
    /// </summary>
    public string Greeting
    {
      get =>
        "\nHello there," +
        "\nThis is an app to create a simple undirected graph " +
        "\nin which every pair of distinct vertices is connected" +
        "\nby a unique edge.";
    }
    /// <summary>
    /// Vertex input instructions
    /// </summary>
    public string VertPrompt =>
          "\nVertices:\n" +
          "\nTo start creating the graph, please input the unique vertices-ids " +
          "\nas in the following example:" +
          "\n\"1,2,4,10,11\" + Enter" +
          "\nPlease make sure to use positive integer values only.";
    /// <summary>
    /// EdgeList input instructions for graph creation
    /// </summary>
    public string EdgesPrompt =>
      "\nEdge List\n" +
      "\nHow would you like to connect the provided vertices?" +
      "\nPlease enter one connection per line (\"1,4\" + Enter ...)" +
      "\nHit the \"SpaceBar\" when finished, in order to complete the graph.";
    /// <summary>
    /// List explaining the available graph commands to the user 
    /// </summary>
    public string CmdLst =>
      "\n\nCommands\n" +
        "\nListEdges       \tDisplays all edges in a list of pairs separated by commas" +
        "\nDeleteEdge X,Y  \tDeleting the edge between X and Y" +
        "\nGetNeighbours X \tLists all vertex-ids that have edges with vertex X" +
        "\nAddEdge X,Y     \tAdd the edge between X and Y" +
        "\nIsCompleteGraph \tReturns true or false depending whether the graph is fully connected / complete" +
        "\nDeleteVertice X \tDelete the vertex with id X from the graph" +
        "\nListVertices    \tDisplays all vertices in a list separated by commas";

    //public TVertex[] Vertices { get; set; } // ideal format, not used so GetVerticesAsInt method works
    /// <summary>
    /// Public property to be used by Controller to pass read Vertices to Model constructor
    /// (Added Vertices in Methods not considered)
    /// </summary>
    public int[] Vertices { get; set; }
    //public TEdges EdgesT { get; set; } // ideal format
    /// <summary>
    /// Public property to be used by Controller to pass read Edges to Model constructor
    /// (Added Vertices in Methods not considered)
    /// </summary>
    public Tuple<int, int>[] Edges { get; set; }

    /// <summary>
    /// proper constructor with UI functionality to let the User build their own graph
    /// </summary>
    /// <param name="message"></param>
    public View(out string message)
    {
      Vertices = Array.Empty<int>();
      Edges = Array.Empty<Tuple<int, int>>();
      Print(Greeting + "\n");
      string msgEdges = "";
      bool allWorked = GetVerticesAsInt(out string msgVerts);
      if (allWorked)
        allWorked = GetEdgesAsInt(out msgEdges);
      message = $"\n\nCollecting Vertices and Edges worked: {allWorked}\n" +
        $"\nVertices: \n{msgVerts}\n" +
        $"Edges: \n{msgEdges}";
    }
    /// <summary>
    /// contructor for dev without UI
    /// (could also be used to skip the customized graph building)
    /// </summary>
    /// <param name="verts"></param>
    /// <param name="edges"></param>
    public View(int[] verts, Tuple<int, int>[] edges)
    { Vertices = verts; Edges = edges; }

    /* ✓ 1. Build GraphModel Instance
     *//*✓ 1.1. Prompt vertex list as (CSV) "1,2,4,10,11"
     * ✓   ► Print string
     * ✓   • Get Vertices (store as HashSet here already?)
     * ✓   ► ReadLine
     * ✓   ► Split ',' ► Clear Whitespace ► int.TryConvert
     *       |-> Rerequest if fails (extract reprompt pattern)
     *      "Only unique, positive numbers are allowed"
     *       |-> Using HashSet
     *        (assert Structure is taking care of duplicates if comparable)
     * ✓   ► Store Collection as Property
     */
    public bool GetVerticesAsInt(out string message)
    {
      message = "";
      Print(VertPrompt);
      var strArr = Prompt().Split(',', StringSplitOptions.RemoveEmptyEntries);
      Vertices = new int[strArr.Length];
      for (int i = 0, j = 0; i < strArr.Length; i++)
      {
        int vertex;
        if (!int.TryParse(strArr[i], out vertex)) // inserting
          message += $"String section {i} couldn't be read as int.\n";
        if (Vertices.Contains(vertex)) // duplicate check
          message += $"Vertex {i} already exists.\n";
        else
        {
          Vertices[j] = vertex;
          j++; // preventing array from gaps
        }
      }
      if (Vertices.Length <= 1)
      {
        message = "No Vertices Could be interpreted";
        return false;
      }
      message += $"Vertex Count: {Vertices.Count()}";
      return true;
    }

    /* ✓ 1.1. Prompt edge collection, each as (CSV) count 2:
     * ✓   · {"1,2
     *        4,2
     *       11,10
     * ✓   ·  11,10 (not allowed)
     *        1,10"}
     * ✓   · "11,10" is the same as "10,11"
     * ✓   · #Feature: · Each Vertex has to have an edge
     * ✓   ► Print string
     * ✓   • Get Edges
     * ✓   ► ReadLine (multiline?)
     * ✓     - until some special key is hit (i.e. spacebar)
     * ✓   ► Split ',' - Clear Whitespace - int.TryConvert
     * ✓   ✓ Handled by datastructure: ► Sanity Check Inputs
     * ✓   ► Store as Property
     */
    public bool GetEdgesAsInt(out string message)
    {
      message = "";
      /// container
      /// 
      var strB = new StringBuilder();
      /// Get User Entries
      /// 
      Print(EdgesPrompt);
      do { strB.Append(Prompt() + ':'); } while (PromptKey() != ConsoleKey.Spacebar);
      /// Split into multiple lines
      /// 
      var strArr = strB.ToString().Split(':', StringSplitOptions.RemoveEmptyEntries);
      /// try to get integers
      /// 
      var edgelst = new List<int>();
      var lstTuples = new List<Tuple<int, int>>();
      foreach (var str in strArr)
      {
        if (string.IsNullOrEmpty(str))
          continue;
        edgelst = str
               .Split(',', StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x))
               .ToList();
        if (edgelst.Count != 2)
        {
          message += $"Edge {str} could not be read as int";
          continue;
        }
        if (!(Vertices.Contains(edgelst[0]) || Vertices.Contains(edgelst[1])))
        {
          message += $"Vertex {edgelst[0]} or vertex {edgelst[1]}) doesn't exist in graph";
          continue;
        }
        var tup = Tuple.Create(edgelst[0], edgelst[1]);
        if (lstTuples.Contains(tup) ||
          lstTuples.Contains(Tuple.Create(edgelst[1], edgelst[0])))
        {
          message += $"Edge ({edgelst[0]}, {edgelst[1]}) already exists in graph";
          continue;
        }
        lstTuples.Add(tup);
      }
      Edges = lstTuples.ToArray();
      if (Edges.Length < 1)
      {
        message = "Collecting Edges failed, do you want to try collecting again?";
        return false;
      }
      /// Feedback
      /// 
      message = "Edges created, length: " + Edges.Length;
      return true;
    }
    #endregion graph object creation

    /* ✓ 2. Model building
     * ✓    ► Handled in ModelInstance usng this.Properties
     */


    #region commands
    /* 3. Work on GraphModel Instance
     *//* 3.1. Introduce UI Cmds
     *    ► Print string:
     *      string _cmdLst
     */

    /* 3.2. Get Cmd and Parameters:
     *    ► Match strings to Method Names
     *    ► Collect and check Parameter Arguments if applicable
     *       |-> Rerequest if fails (extract reprompt pattern)
     *    ► Store as Properties
     * 
     */

    /// <summary>
    /// Lists the available Methods and Prompts/ tries to interprete a matching response
    /// </summary>
    /// <param name="instructions">If false, the User Instructions will be skipped</param>
    /// <param name="message"></param>
    /// <param name="cmd">The successfully matched Method Name</param>
    /// <param name="args">Method Parameter if applicable</param>
    /// <returns></returns>
    public bool GetCMD(bool instructions, out string message, out string cmd, out int[]? args)
    {
      if (instructions) // only the first time
        Print($"\n\nUse one of the following Commands:{CmdLst}");
      cmd = "";
      string? line = Prompt();
      string[] parts;
      args = new int[2];
      message = "";
      if (!string.IsNullOrEmpty(line))
      {
        // Prepare:
        parts = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        //var command = parts[0];
        int a, b, length = 0;
        bool vInGraph = false;// = 0;
        if (parts.Length > 2)
        {
          if (int.TryParse(parts[2], out b) && int.TryParse(parts[1], out a))
          {
            args[0] = a;
            args[1] = b;
            if (args[0] == args[1])
              args = null;
            if (args != null)
              vInGraph = Vertices.Contains(args[0]) && Vertices.Contains(args[1]);
            length = 2;
          }
        }
        else if ((parts.Length > 1) && int.TryParse(parts[1], out a))
        {
          args[0] = a;
          vInGraph = (Vertices.Contains(args[0]));
          length = 1;
        }
        else length = 0;
        // Feedback:
        var error = "Command not found";
        string preCmdText = "Pattern Matches: ";
        cmd =
          (parts[0], length, vInGraph) switch
          {
            ("ListEdges", _, _) => ("ListEdges"),
            ("DeleteEdge", 2, true) => ("DeleteEdge"),
            ("GetNeighbours", 1, true) => ("GetNeighbours"),
            ("AddEdge", 2, true) => ("AddEdge"),
            ("IsCompleteGraph", _, _) => ("IsCompleteGraph"),
            ("DeleteVertice", 1, true) => ("DeleteVertice"),
            ("ListVertices", _, _) => ("ListVertices"),
            _ => (error)
          };
        if (args != null)
          Print($"{preCmdText} {cmd} {args[0]} {args[1]}");
        else
          Print($"{preCmdText} {cmd} none found");
        if (cmd.Equals(error))
        {
          if (length > 0 && !vInGraph)
            message = "Vertex not present in Graph.";
          return false;
        }
        else
          return true;
      }
      message = "Input cannot be empty.";
      return false;
    }
    #endregion commands

    #region UI Methods (Console)
    /// <summary>
    /// Prints a string to the console
    /// </summary>
    /// <param name="str"></param>
    public void Print(string str) => Console.WriteLine(str);
    /// <summary>
    /// Reads a line from Console
    /// </summary>
    /// <returns></returns>
    public string Prompt()
    {
      string? str; int count = 0;
      do { str = count++ < 5 ? Console.ReadLine() : "5 Mismatches and counting"; }
      while (str == null && count < 6);
      return str != null ? str : "";
    }
    /// <summary>
    /// Gets the entered key to compare to
    /// </summary>
    /// <returns></returns>
    public ConsoleKey PromptKey() => Console.ReadKey(true).Key;
    #endregion UI Methods (Console)
  }
}