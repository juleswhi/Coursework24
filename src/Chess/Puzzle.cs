using ChessMasterQuiz.Misc;

namespace Chess;

public class Puzzle(IEnumerable<Piece> setup, Colour toMove, int rating, params (string, bool)[] move) : Question
{
    public static List<Puzzle> Puzzles { get; set; } = new();
    public override int Rating { get; init; } = rating;
    public Colour ToMove { get; set; } = toMove;
    public IEnumerable<Piece> Setup { get; set; } = setup;
    public List<(string, bool)> Moves { get; set; } = move.ToList();
    public static void CreatePuzzles()
    {
        Puzzles.Add(
            new Puzzle([new Piece(QUEEN, Notation.From("a1"), White),
                        new Piece(ROOK, Notation.From("c1"), White),
                        new Piece(ROOK, Notation.From("h1"), White),
                        new Piece(PAWN, Notation.From("a2"), White),
                        new Piece(BISHOP, Notation.From("b2"), White),
                        new Piece(PAWN, Notation.From("f2"), White),
                        new Piece(KING, Notation.From("g2"), White),
                        new Piece(PAWN, Notation.From("b3"), Black),
                        new Piece(PAWN, Notation.From("d3"), White),
                        new Piece(PAWN, Notation.From("g3"), White),
                        new Piece(PAWN, Notation.From("c4"), Black),
                        new Piece(PAWN, Notation.From("e4"), White),
                        new Piece(PAWN, Notation.From("b5"), Black),
                        new Piece(KNIGHT, Notation.From("g5"), White),
                        new Piece(BISHOP, Notation.From("c6"), Black),
                        new Piece(ROOK, Notation.From("e6"), Black),
                        new Piece(PAWN, Notation.From("g3"), White),
                        new Piece(QUEEN, Notation.From("b7"), Black),
                        new Piece(KNIGHT, Notation.From("d7"), Black),
                        new Piece(QUEEN, Notation.From("b7"), Black),
                        new Piece(PAWN, Notation.From("f7"), Black),
                        new Piece(PAWN, Notation.From("f7"), Black),
                        new Piece(PAWN, Notation.From("g7"), Black),
                        new Piece(ROOK, Notation.From("c8"), Black),
                        new Piece(BISHOP, Notation.From("f8"), Black),
                        new Piece(KING, Notation.From("g8"), Black)],
                        White, 1300,
                        ("f3", false), ("Rh8+", true), ("Rh7", false), ("dc", false)));

        Puzzles.Add(
            new Puzzle([
            new Piece(KING, Notation.From("b1"), Black),
            new Piece(ROOK, Notation.From("c1"), Black),
            new Piece(PAWN, Notation.From("b2"), Black),
            new Piece(PAWN, Notation.From("c2"), Black),
            new Piece(QUEEN, Notation.From("d2"), White),
            new Piece(PAWN, Notation.From("g2"), Black),
            new Piece(PAWN, Notation.From("h3"), Black),
            new Piece(PAWN, Notation.From("a4"), Black),
            new Piece(KNIGHT, Notation.From("e5"), White),
            new Piece(QUEEN, Notation.From("a7"), Black),
            new Piece(PAWN, Notation.From("b7"), White),
            new Piece(PAWN, Notation.From("f7"), White),
            new Piece(PAWN, Notation.From("g7"), White),
            new Piece(PAWN, Notation.From("h7"), White),
            new Piece(KING, Notation.From("c8"), White),
            new Piece(ROOK, Notation.From("h8"), White),
            ], Black, 1000, ("Qf4+", false), ("Qb8", false), ("Qh1+", true), ("b5", false)));

        Puzzles.Add(new Puzzle([
            new Piece(KING, Notation.From("c1"), White),
            new Piece(PAWN, Notation.From("a2"), White),
            new Piece(PAWN, Notation.From("b2"), White),
            new Piece(PAWN, Notation.From("f2"), White),
            new Piece(PAWN, Notation.From("g2"), White),
            new Piece(PAWN, Notation.From("h2"), White),
            new Piece(PAWN, Notation.From("c3"), White),
            new Piece(KNIGHT, Notation.From("d4"), Black),
            new Piece(QUEEN, Notation.From("h4"), White),
            new Piece(QUEEN, Notation.From("f5"), Black),
            new Piece(KNIGHT, Notation.From("f6"), White),
            new Piece(PAWN, Notation.From("g6"), Black),
            new Piece(PAWN, Notation.From("a7"), Black),
            new Piece(PAWN, Notation.From("b7"), Black),
            new Piece(PAWN, Notation.From("c7"), Black),
            new Piece(PAWN, Notation.From("f7"), Black),
            new Piece(KING, Notation.From("g7"), Black),
            new Piece(PAWN, Notation.From("h7"), Black),
            new Piece(ROOK, Notation.From("a8"), Black),
            new Piece(BISHOP, Notation.From("c8"), Black),
            new Piece(ROOK, Notation.From("e8"), White),
            ], White, 1200, ("Qxh7+", false), ("g4", false), ("Qe4", false), ("Rg8+", true)));

        Puzzles.Add(new Puzzle([
            new Piece(KING, Notation.From("b1"), White),
            new Piece(ROOK, Notation.From("d1"), White),
            new Piece(BISHOP, Notation.From("f1"), White),
            new Piece(ROOK, Notation.From("h1"), White),
            new Piece(PAWN, Notation.From("a2"), White),
            new Piece(PAWN, Notation.From("b2"), White),
            new Piece(PAWN, Notation.From("g2"), White),
            new Piece(BISHOP, Notation.From("e3"), White),
            new Piece(PAWN, Notation.From("h3"), White),
            new Piece(PAWN, Notation.From("c4"), Black),
            new Piece(PAWN, Notation.From("f4"), White),
            new Piece(PAWN, Notation.From("c5"), Black),
            new Piece(KNIGHT, Notation.From("d5"), White),
            new Piece(PAWN, Notation.From("e5"), White),
            new Piece(PAWN, Notation.From("c5"), Black),
            new Piece(BISHOP, Notation.From("a6"), Black),
            new Piece(PAWN, Notation.From("b6"), Black),
            new Piece(KNIGHT, Notation.From("d6"), White),
            new Piece(PAWN, Notation.From("g6"), Black),
            new Piece(ROOK, Notation.From("a7"), White),
            new Piece(KNIGHT, Notation.From("d7"), Black),
            new Piece(PAWN, Notation.From("f7"), Black),
            new Piece(BISHOP, Notation.From("g7"), Black),
            new Piece(PAWN, Notation.From("h7"), Black),
            new Piece(ROOK, Notation.From("d8"), Black),
            new Piece(KNIGHT, Notation.From("f8"), Black),
            new Piece(KING, Notation.From("g8"), Black),
            ], White, 1400, 
            ("Ne7+", true), ("Nxf7", false), ("Nf6+", false), ("g4", false)
            ));
    }
}

