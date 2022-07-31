## Goals:
  [x] use graph interface or abstract class  
    - to enable easy change of model  
  [x] keep different vertices in mind  
    - (vectors, users, locations...)  

  [x] use abstract view class for console  
    - to prepare the model strings  
   [ ]- make Console functions virtual

  <img src=images/ClassDiagram_final.png height=300></img>

## Steps:
 -1. Start Program
    - Hadled in Main Method as Entry Point

### 1. Greet User
    - Halded in View during construction of instance

### 2. Get User Inputs
    - Create ViewInstance
      - Handle Rest there
    ```
    Vertices:

    To start creating the graph, please input the unique vertices-ids
    as in the following example:
    "1,2,4,10,11" + Enter
    Please make sure to use positive integer values only.
    1,2,4,10,11

    Edge List

    How would you like to connect the provided vertices?
    Please enter one connection per line ("1,4" + Enter ...)
    Hit the "SpaceBar" when finished, in order to complete the graph.
    1,2
    2,4
    10,11


    Collecting Vertices and Edges worked: True

    Vertices:

    Edges:
    Edges created, length: 3
    ```    

### 3. Build Model
    - Create ModelInstance
      - using ViewInstance Properties

    ```
    ...
    1,2,4,10,11
    ...
    1,2
    2,4
    10,4
    11,4
    1,11
    2,10
    ...
    Collecting Vertices and Edges worked: True
    Vertices:
    Vertex Count: 5
    Edges:
    Edges created, length: 6
    Graph constructor:
    Graph successfully created!5Vertices in Graph Model.
    6Edges in Graph Model.
    ```

### 4. Work with Model
   (- Maybe use while loop here to keep runing
      - Control by ViewInstance Property check)
    - Get User Requests
      - using ViewInstance Function
    - Match string to ModelInstance Cmd
      - Automatically call while matching
    - Convert Result to string
    - Call Print function from ViewInstance

###    4.1. Get Vertex List to inform user CMD argument selection
      - Decision on appropiate Method signature:
        (keeping in Mind:
        - Keep all the same to
          - allow extension of method list
          - provide option for delegates
          - make interface / abstract base class simpler to implement
        - "returnValues" Database storage: Can't only return string
        - "errorMessage" Independency: needs to output message if not working
        - "InputArgs"   Diversity: allow differing Parameter length 
      - public bool MethodName(out object? returnValues, out string errorMessage, string[]? InputArgs = null)
      ```    
      Graph constructor:
      Graph successfully created!
      - 5 Vertices in Graph Model.
      - 4 Edges in Graph Model.

      ListVertices:
      - 1,2,4,10,11


      Use one of the following Commands:


      Commands

      ListEdges               Displays all edges in a list of pairs separated by commas
      DeleteEdge X,Y          Deleting the edge between X and Y
      GetNeighbours X         Lists all vertex-ids that have edges with vertex X
      AddEdge X,Y             Add the edge between X and Y
      IsCompleteGraph         Returns true or false depending whether the graph is fully connected / complete
      DeleteVertice X         Delete the vertex with id X from the graph
      ListVertices            Displays all vertices in a list separated by commas
      ```    
###      4.2 AddEdge X,Y  
###      4.3 IsCompleteGraph  
###      4.4 DeleteEdge X Y
      ```
      ListVertices:
      - 1,2,4,10,11
      ListEdges:
      - (1,2),(1,10),(2,4),(10,11)
      ...
      "DeleteEdge (1,2)"
      Deleting Edge succeded. EdgeCout (before/after): (4/4)
      Enter another Command to continue, or click Escape to end the application?
      ListEdges
      Pattern Matches:  ListEdges 0 0

      ListEdges:
      - (1,10),(2,4),(10,11)
      Enter another Command to continue, or click Escape to end the application?
      DeleteEdge 2,4
      Pattern Matches:  DeleteEdge 2 4

      "DeleteEdge (2,4)"removing this edge would invalidate the graph
      Enter another Command to continue, or click Escape to end the application?
      ```
###      4.5 GetNeighbours  
###      4.6 ListVertices - done earlier to help user with selection  
###      4.7 DeleteVertice:
      ```
      ListVertices:
      - 1,2,4,10,11
      ListEdges:
      - (1,2),(1,10),(2,4),(10,11)
      ...
      DeleteVertice 2
      Pattern Matches:  DeleteVertice 2 0

      "DeleteVertice 2" Problems: removing this vertex would invalidate the graph, neighbor 4 has no other neighbors
      Enter another Command to continue, or click Escape to end the application?
      DeleteVertice 1
      Pattern Matches:  DeleteVertice 1 0

      "DeleteVertice 1"
      Deleting vertex worked!
      Vertex count (before/after) (4/3)
      Deleting Edge succeded. EdgeCout (before/after): (3/2)0
      Enter another Command to continue, or click Escape to end the application?
      ListVertices
      Pattern Matches:  ListVertices 0 0

      ListVertices:
      - 4,10,11
      Enter another Command to continue, or click Escape to end the application?
      ListEdges
      Pattern Matches:  ListEdges 0 0

      ListEdges:
      - (4,2),(10,11)
      Enter another Command to continue, or click Escape to end the application?
      ```

  Added improvement ideas while working on it:
   - when time use unit testing!
   - could be directly calling the delegate instead of matching
   - console could use command pattern
   - graph coud use builder pattern
   - error checking too cumbersome
     - better to introduce common approach (ruleset?)
   - generic Types not extensive
   - too much going on in controller