namespace ChessMasterQuiz.Chess;

public record PGN(
    string Event,
    string Site,
    DateTime Date,
    int Round,
    string White,
    string Black,
    string Result,
    string? Annotator,
    int? PlyCount,
    string? TimeControl,
    DateTime? Time,
    string? Termination,
    string? Mode,
    );

internal class PgnReader
{





    public void FromFile(string path)
    {

    }

    public void FromString(params string[] str)
    {

    }

    enum TokenType
    {
        KEY,
        VALUE,
        LEFT_BRACKET,
        RIGHT_BRACKET,
    }


    private void Lex()
    {
        int _current = 0;

    }

    private void Parse()
    {

    }





}
