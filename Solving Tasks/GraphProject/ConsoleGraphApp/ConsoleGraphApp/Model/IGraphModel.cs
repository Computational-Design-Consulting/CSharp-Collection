
namespace ConsoleGraphApp.Model
{
  internal interface IGraphModel<TVertex> where TVertex : notnull
  {
    Dictionary<TVertex, HashSet<TVertex>> AdjacencyList { get; }
    int EdgeCount { get; }

    bool ListEdges(out object? vertexNeighborList, out string message, TVertex[]? args = null);
    bool DeleteEdge(out object? vertexNeighborList, out string message, TVertex[]? args);
    bool GetNeighbours(out object? vertexNeighborList, out string message, TVertex[]? args = null);
    bool AddEdge(out object? vertexNeighborList, out string message, TVertex[]? args = null);
    bool IsCompleteGraph(out object? vertexNeighborList, out string message, TVertex[]? args = null);
    bool DeleteVertice(out object? vertexNeighborList, out string message, TVertex[]? args = null);
    bool ListVertices(out object? vertexNeighborList, out string message, TVertex[]? args = null);
  }
}