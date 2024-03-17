
/*
 
   This Rating class represents an integer value, which is a relative to other players and questions.

   The rating system is based off the famous elo system created by Arpad Elo
 
 */

namespace UserRepresentation;

// Primary constructor is used to create a Rating prop
public record class ELO
{
    public int Rating { get; set; }

    // Represents either a win or a loss
    public enum MatchupResult
    {
        LOSS = 0,
        WIN = 1
    }

    // History of the ratings of the user
    public List<int> PastRatings { get; set; } = new();

    // Some readonly fields to be used for values in ELO calculations
    // NOTE: All values are subject to change
    private readonly static int s_initialRating = 1000;
    private readonly static int s_eloModifier = 32;
    private readonly static int s_expectedOutimeCModifier = 400;
    private readonly static int s_minimumPossibleElo = 100;
    private readonly static int s_bonusScore = 10;

    // Blank constructor to allow for the default initial rating
    public ELO()
    {
        Rating = s_initialRating;
    }

    public static void Match(ELO elo, MatchupResult result, int opponentRating)
    {
        // ELO FORMULA 
        // R'a = Ra + K * (Sa - Ea) + Sa * V
        // WHERE Ea = Qa / ( Qa + Qb )

        // These are the two ratings before the matchup. 
        // They are used to calculate the expected outcome.
        int Ra = elo.Rating;
        int Rb = opponentRating;

        // The standard modifier of the elo.
        // This value is the maximum elo that can be won or lost
        int K = s_eloModifier;

        // The actual outcome of the match
        // 1 for win, 0 for loss
        // Third branch will never be hit
        int Sa = result switch
        {
            MatchupResult.WIN => 1,
            MatchupResult.LOSS => 0,
            _ => default
        };

        // Qa = 10 ^ (Ra / c)
        // Qb = 10^(Rb / c)
        float Qa = (int)Math.Pow(10, Ra / s_expectedOutimeCModifier);
        float Qb = (int)Math.Pow(10, Rb / s_expectedOutimeCModifier);

        // Calculate the expected outcome using the appropriate formula
        float Ea = Qa / (Qa + Qb);

        // Add a constant scaling value but only if a correct answer 
        int addedBonus = Sa * s_bonusScore;

        // Get the result rating from the modified elo formula
        float resultantRating = Ra + K * (Sa - Ea) + addedBonus;

        // Make sure the elo isnt too low
        if (resultantRating < s_minimumPossibleElo)
        {
            return;
        }

        // Add the rating to the list of previous ratings. 
        // Used to show progression 
        elo.PastRatings.Add(elo.Rating);

        // Finally, update the rating!
        elo.Rating = (int)resultantRating;

        UpdateUser(ActiveUser!);
    }
}
