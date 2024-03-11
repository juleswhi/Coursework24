/*

    -- GlobalUsings.cs -- 

    - Global using statements allow for a cleaner codespace as they remove the need to manually reference the important namespaces.
    - Global usings are applied to every file in the namespace

    - Static using statements allow the consumer to access the members of the class w/o the class name

    Instead of:
    Console.WriteLine();

    You could write:
    WriteLine();

    However, This could be considered an antipattern by making your code less verbose and therefor harder to read,
    so you should only use when necessary ( enum types )

*/


// Allows for use of Helper methods from Helper.cs without needing to reference Helper class. 
// Creates more seamless experience using helper ( extension ) methods ( see Helper.cs )

// Similar use to FormatDirection
global using static ChessMasterQuiz.Misc.SeverityType;

/*
 
    Allows use of important methods w/o them hanging off the type ( gross ) 
    Also makes code easier to read

    Instead of:
    string.IsNullOrWhitespace("Example");  // false

    Do:
    IsNullOrWhitespace("Example");  // false

*/

global using static ChessMasterQuiz.Helpers.ControlHelper;
global using static System.Reflection.BindingFlags;
global using UserRepresentation;
global using static ChessMasterQuiz.Misc.ContextTagType;
global using static UserRepresentation.UserHelper;
global using DCT = ChessMasterQuiz.Misc.DataContextTag;
global using static ChessMasterQuiz.Helpers.Helper;
global using static Chess.PieceType;
global using static Chess.Colour;
global using Chess;
global using static Chess.Notation;
