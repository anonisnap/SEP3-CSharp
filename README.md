# SEP3-CSharp

### This is the C# parts of SEP 3
<p>
  This solution contains projects for Tier 1 and Tier 3 in the 3rd SEP
  <br>
  The overall solution was a 3 Tier Architecture, with C# and Java being used as the programming languages. And using gRPC and REST as networking technologies.
  <br>
 	The project itself was a Warehouse Management System. Allowing users to create Internal Locations in a warehouse, and store Objects / Items on those locations. This also has a partial Order system added. With Orders being possible to create and fulfill to some extent.
</p>
  
<hr>

## Tier 1
***Web Client / User Interaction***

<p>
  Tier 1 was written in <a href="https://dotnet.microsoft.com/en-us/languages/csharp">C# / .NET</a>, using <a href="https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor">Blazor</a> to operate as an interactive Web Application. Users can look through the different pages created, and interact with objects stored in the 3rd Tier of the system.

  <br>
  <br>

  The communication from this tier to <a href="https://github.com/anonisnap/SEP3_Middle_Server" target="_blank">Tier 2</a> (Business Tier written in Java), was done using <a href="https://grpc.io/">gRPC</a>. gRPC is a tool, helping with creating network connections between different processes, using Remote Procedure Calls. 
</p>


## Tier 3
***Database Server***

<p>
  Tier 3 was designed with Microsoft Entity Framework as the central functionality. It was designed with a connection made to an <a href="https://www.elephantsql.com/">ElephantSQL</a> Database Server. The ElephantSQL Connection was made to interact with a remote PostgreSQL Database, used to store the locations and items we would be testing with.
  <br>
  Connections to Tier 3 happened as REST calls. With Tier 3 having a REST API, allowing HTTP/HTTPs requests to be made, for interacting with the server.
</p>
