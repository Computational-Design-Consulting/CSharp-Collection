using ConsoleGraphApp.Model;
using ConsoleGraphApp.View;

namespace ConsoleGraphApp.Controller
{
  /// <summary>
  /// Class for managing View Requests, Model CRUD and View Responses
  /// by controlling Program Control Flow
  /// </summary>
  internal class Controller
  {
    /// Goals:
    /// 
    /* use graph interface or abstract class
       *  - to enable easy change of model
       *  * keep different vertices in mind
       *    (vectors, users, locations...)
       */
    /* use abstract view class for console
       *  - to prepare the model strings
       *  - make Console functions virtual
       */

    //private View<int, IEnumerable<IEnumerable<int>>> _view;
    //private readonly IView _view;
    private readonly IView<int>_view;
    //private readonly GraphModel<IEnumerable<int>, IEnumerable<Tuple<int, int>>> _graphModel;
    //private GraphModel<int, string> _graphModel;
    private readonly IGraphModel<int> _graphModel;
    /// Steps:
    /// 
    /* ✓ -1. Start Program
    *  ✓  ► Hadled in Main Method as Entry Point
    */
    /* ✓  0. Greet User
      * ✓   ► Halded in View during construction of instance
      *//*✓  1. Get User Inputs
      * ✓   ► Create ViewInstance
      * ✓     ► Handle Rest there
      */
    /* ✓ 2. Build Model
    *  ✓  ► Create ModelInstance
    *  ✓    ► using ViewInstance Properties
    */

    /// creating an instance runs the Program in Main Method
    ///
    internal Controller()
    {

      /* UI dependent workflow:
       * string feedback;
       * _view = new View<int, IEnumerable<IEnumerable<int>>>(out feedback);
       * _view.Print(feedback);
       * _graphModel = new GraphModel<int, string>(_view.Vertices, _view.Edges, out feedback);
       * _view.Print(feedback);
       */

      /// -- using built graph for dev: --
      /// 
      var vertices = new[] { 1, 2, 4, 10, 11 };
      var edges = new[]{
                Tuple.Create(1,2),
                Tuple.Create(4,2),
                Tuple.Create(11,10),
                Tuple.Create(1,10)};
      _graphModel = new GraphModel<int, string>(vertices, edges, out string feedbackGraph);
      /// building view object to access methods:
      /// 
      _view = new View<int, IEnumerable<IEnumerable<int>>>(vertices, edges);
      _view.Print(feedbackGraph);
      /// Get Vertex List to inform user CMD argument selection
      /// 
      _graphModel.ListVertices(out object? vertexList, out string msgListVertices);
      _view.Print($"{msgListVertices}{vertexList}");
      /// Get EdgeList
      /// 
      _graphModel.ListEdges(out object? vertexNeighborList, out string msgListEdges);
      _view.Print($"{msgListEdges} + {vertexNeighborList}");
      /// --- developing CMD Interface: ---
      /// 
      int i = 0;
      do
      {
        _view.GetCMD(i < 1, out string message, out string cmd, out int[]? args);
        _view.Print(message);

        // TODO implement Model Methods
        //_graphModel. Method or Delegate <== (string cmd, int[]? args)
        object? returnValues = null;
        string errorMessage = "";

        int argsLength = (args ?? (Array.Empty<int>())).Length;
        int cmdExecuted =
          (cmd, argsLength) switch
          {
            ("ListEdges", _) => _graphModel.ListEdges(out returnValues, out errorMessage, args) ? 1 : 0,
            ("DeleteEdge", 2) => _graphModel.DeleteEdge(out returnValues, out errorMessage, args) ? 1 : 0,
            ("AddEdge", 2) => _graphModel.AddEdge(out returnValues, out errorMessage, args) ? 1 : 0,
            ("ListVertices", _) => _graphModel.ListVertices(out returnValues, out errorMessage, args) ? 1 : 0,
            ("GetNeighbours", 2) => _graphModel.GetNeighbours(out returnValues, out errorMessage, args) ? 1 : 0,
            ("IsCompleteGraph", _) => _graphModel.IsCompleteGraph(out returnValues, out errorMessage, args) ? 1 : 0,
            ("DeleteVertice", 2) => _graphModel.DeleteVertice(out returnValues, out errorMessage, args) ? 1 : 0,
            (_, _) => -1
          };
        if (cmdExecuted < 0)
          _view.Print("Command did not run, because Name couldn't be matched" +
                      "\n(try and type space before the command)");
        else
        {
          if (cmdExecuted < 1)
            _view.Print(errorMessage);
          else
            _view.Print(errorMessage + (returnValues ?? "").ToString());
        }

        _view.Print("Enter another command to continue, or click Escape to end the application?");
        i++;
      } while (_view.PromptKey() != ConsoleKey.Escape);


      _view.Print("Thank you for using the GraphApp! Until next time;) ");
    }

    /* 3. Work with Model
    *   (► Maybe use while loop here to keep runing
    *      ► Control by ViewInstance Property check)
    *//* ► Get User Requests
    *      ► using ViewInstance Function
    *    ► Match string to ModelInstance Cmd
    *      ► Automatically call while matching
    *    ► Convert Result to string
    *    ► Call Print function from ViewInstance
    */
  }
}
