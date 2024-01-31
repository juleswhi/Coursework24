
/*

-- GlobalUsings.cs -- 

- Global using statements allow for a cleaner codespace as they remove the need to manually reference the important namespaces.
- Global usings are applied to every file in the namespace

- Static using statements allow the consumer to access the members of the class w/o the class name

Instead of:
Console.WriteLine();

You could write:
WriteLine();

However, This is an antipattern by making your code less verbose and therefor harder to read,
so you should only use when necessary ( enum types )
*/


// Allows for use of Helper methods from Helper.cs without needing to reference Helper class. 
// Creates more seamless experience using helper ( extension ) methods ( see Helper.cs )

global using static ChessMasterQuiz.Helper;

/*
 
Improves experience of using Helper methods on Control types. 

Instead of: 
button.Center(FormatDirection.X);

Do: 
button.Center(X);

*/

global using static ChessMasterQuiz.FormatDirection;

// Similar use to FormatDirection
global using static ChessMasterQuiz.SeverityType;

/*
 
Allows use of important methods w/o them hanging off the type ( gross ) 
Also makes code easier to read

Instead of:
string.IsNullOrWhitespace("Example");  // false

Do:
IsNullOrWhitespace("Example");  // false

*/

using static System.String;
using static System.Char;


// Useful in context of LonSerializer
using static ChessMasterObjectNotation.TokenType;
