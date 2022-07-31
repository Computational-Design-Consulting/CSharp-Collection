
# Technical Assignment

evaluate understanding of fundamentals of:
 - **OOP** and other **programming principles**,  
   - **many concepts from our Automation team**.
   - often **write** **plugins**
   - **similar ways of interacting with the user**
     - **readability**
     - **choice of data structures**
     - **way the application is designed**

## Assignment

 - building a **small console application in .Net core**.
 - The App should 
   - **create a graph based on inputs**
   - can be **processed by commands**.
 - **if new front-end** added (web app / text files)      
   - **no implementation** has **to be repeated**
 - **should not have external dependencies**
   - All **data structures and models**
      representing graph parts (like vertices, edges etc.)
     - should be created  
 - If *reference or inspire* from code on the internet,
   - ***reference*** inspiration or stackoverflow post
     - in comments above class/function
     - After the assignment
     - discuss how to get to that answer
     - how the reference was used  

### Inputs

#### The application
 - **greets** the **user** and
 - **requests** the **input of vertices**
   - Each **vertex** is **represented by**
     - a **unique positive number** and
     - will be **provided in a comma separated list**. For example:
       - `1,2,4,10,11`

#### Afterwards, the application should
 - **request** the user to
   - **input** the **edges** of the graph
   - The edges are **also** provided in a **comma separated list**, however,
     - **each edge is it’s own list**. Which means that
       - **all** of them are of **size 2**.
     - For **example**, the user should be able to provide:
      ```csharp
      1,2
      4,2
      11,10
      1,10
      ```

#### Note that
 - this application is intended to produce an **undirected graph**
   - (so an edge `11,10` is **the same as** `10,11`) and
 - **no duplicate edges** should be allowed.
 - Each **vertice** should have **at least one edge**.

The following inputs should
 - connect vertice 1 with vertice 2, vertice 4 with vertice 2, .. etc.  

When **enter** is **pressed**,
 - **stop reading** the edges provided by the user and
 - **notify** the user that the graph **creation was successfully finished**, and
   - that the application is **ready to execute commands on the graph**.  

### Commands
Now that we have specified the inputs, the application should be ready to
 - execute various **commands on the graph.**
 - The commands are **listed in priority order**
   - in which we would like you to implement them,
     - in case you do not have the time to finish them all
        (which is fine, as long as you can describe how you would implement them if you had the time).
     - It is important to design the application in such a way that
       - adding new commands is simple and does not require to change the existing code much, than implementing all the commands listed here
       - (thus they are provided in priority).  
  
   
 - A command is executed if the user fills in the name of the command.  
 - `X` and `Y` are **vertex id’s**

#### Command:
  - Name:  `ListEdges`  
  - Behaviour:  
     - **Display** all edges to the user in a **list of pairs** separated by commas.  
     - Example:  
       - Output: `(1,2),(4,2),(10,11)`  

#### Command:
  - Name:  `DeleteEdge X,Y`  
  - Behaviour:  
    - **Delete** the edge **between** X and Y.
    - **If** the edge **doesn’t exist**,
      - please **inform** the user.
    - **If** deleting the edge **produces** an **invalid graph**,
      - then **don’t delete** the edge and **inform** the user  

#### Command:
  - Name:  `GetNeighbours X`  
  - Behaviour:  
    - List all **vertex ids** that have **edges with** vertex **X**.  

#### Command:
  - Name:  `AddEdge X,Y`  
  - Behaviour:  
    - **Add** the **edge between** X and Y
    - **If** the edge **exists** already, please
      - **inform** the user.  

#### Command:
  - Name:  `IsCompleteGraph`  
  - Behaviour:  
    - Return **true or false** depending whether the graph **is fully connected / complete**  

#### Command:
  - Name:  `DeleteVertice X`  
  - Behaviour: 
    - **Delete** the vertex with id X from the graph.
      - **If** the vertex **doesn’t exist**, please **inform** the user.  
    - **If** deleting the vertex **produces an invalid graph** (a vertex has no edges),
      - then **don’t delete** the vertex and **inform** the user.  

#### Command:
  - Name: `ListVertices`  
  - Behaviour:  
    - **Display** all vertices to the user in a list separated by commas (just like they were input).
      - (comma separated list, each edge is it’s own list => all are of size 2)

That’s it, you’ve finished the functionality of the application.

expect to
 - provide the application in a private git repo
 - the way git is handled (the commit history) will also be evaluated.