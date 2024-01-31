using static ChessMasterQuiz.ValidationType;
using static ChessMasterQuiz.RequirementType;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Text;

namespace ChessMasterQuiz;

enum ValidationType
{
    EMAIL,
    PASSWORD,
    DISPLAY,
    DOB,
    GENDER
}

enum RequirementType
{
    LENGTH,
    SPECIALCHARACTERS,
    UPPERCASE,
    NUMBER
}

internal static class Validator
{

    public static bool Validate(this string text, ValidationType type)
    {
        Dictionary<RequirementType, bool> ValidationLookup = new()
        {
            { LENGTH, false },
            { SPECIALCHARACTERS, false },
            { UPPERCASE, false },
            { NUMBER, false },

        };

        switch (type)
        {
            case EMAIL:
                return MailAddress.TryCreate(text, out _);
            case DOB:
                return DateTime.TryParse(text, out _);
            case DISPLAY:
                return ValidateDisplayName(text);
            case PASSWORD:

                if(text.Length > 8)
                {
                    ValidationLookup[LENGTH] = true;
                }

                if(text.Where(x => !char.IsLetterOrDigit(x)).Count() > 2)
                {
                    ValidationLookup[SPECIALCHARACTERS] = true;
                }

                if (text.Any(x => char.IsUpper(x)))
                {
                    ValidationLookup[UPPERCASE] = true;
                }

                if(text.Any(x => char.IsDigit(x))) {
                    ValidationLookup[NUMBER] = true;
                }

                if(ValidationLookup.All(x => x.Value == true))
                {
                    return true;
                }
                return false;
        }
        var regex = new Regex(ValidationTypeRegex[type]);
        return regex.IsMatch(text);
    }

    private static bool ValidateDisplayName(this string text)
    {
        if (text.Any(x => !char.IsLetter(x)))
        {
            return false;
        }

        return true;
    }


    public static Dictionary<ValidationType, string> ValidationTypeRegex = new()
    {
        { EMAIL, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" },
        { PASSWORD, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" },
        { DISPLAY, @"\b([A-ZÀ-ÿ][-,a-z. ']+[ ]*)+" },
        { GENDER, @"/^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$/u" },
    };
} 
