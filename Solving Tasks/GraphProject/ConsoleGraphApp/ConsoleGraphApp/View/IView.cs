
namespace ConsoleGraphApp.View
{
  public interface IView<TVertex> where TVertex : IComparable<TVertex>
  {
    string CmdLst { get; }
    Tuple<int, int>[] Edges { get; set; }
    string EdgesPrompt { get; }
    string Greeting { get; }
    //int[] Vertices { get; set; }
    TVertex[] Vertices { get; set; } // ideal format
    string VertPrompt { get; }

    bool GetCMD(bool instructions, out string message, out string cmd, out int[]? args);
    bool GetEdgesAsInt(out string message);
    bool GetVerticesAsInt(out string message);
    void Print(string str);
    string? Prompt();
    ConsoleKey PromptKey();
  }
}
