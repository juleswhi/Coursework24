using System.Diagnostics;

namespace ChessMasterQuiz;

public record struct ELO (int Rating)
{

    public enum MatchupResult
    {
        WIN,
        LOSS
    }

    public List<int> PastRatings { get; set; } = new();

    private readonly static int s_initialRating = 1000;
    private readonly static int s_eloModifier = 32;
    private readonly static int s_expectedOutimeCModifier = 400;
    private readonly static int s_minimumPossibleElo = 100;
    private readonly static int s_bonusScore = 10;

    public ELO() : this(s_initialRating) {
        Rating = s_initialRating;
    }

    public static void Match(ref ELO elo, MatchupResult result, int opponentRating)
    {

        // ELO FORMULA 
        // R'a = Ra + K * (Sa - Ea) + Sa * V
        // WHERE Ea = Qa / ( Qa + Qb )

        int Ra = elo.Rating;
        int Rb = opponentRating;

        int K = s_eloModifier;

        int Sa = result switch
        {
            MatchupResult.WIN => 1,
            MatchupResult.LOSS => 0,
            _ => throw new NotImplementedException()
        };

        // Qa = 10 ^ (Ra / c)
        // Qb = 10^(Rb / c)
        float Qa = (int)Math.Pow(10, Ra / s_expectedOutimeCModifier);
        float Qb = (int)Math.Pow(10, Rb / s_expectedOutimeCModifier);

        float Ea = Qa / (Qa + Qb);

        // Add a constant scaling value but only if a correct answer 
        int addedBonus = Sa * s_bonusScore;

        float resultantRating = Ra + K * (Sa - Ea) + addedBonus;

        if(resultantRating < s_minimumPossibleElo)
        {
            return;
        }

        elo.PastRatings.Add(elo.Rating);

        elo.Rating = (int)resultantRating;
    }

}
