using static ChessMasterQuiz.Misc.ValidationType;
using static ChessMasterQuiz.Misc.RequirementType;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Text;

namespace ChessMasterQuiz.Misc;

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
    public static (bool, float) Validate(this string text, ValidationType type)
    {
        Dictionary<RequirementType, bool> ValidationLookup = new()
        {
            { RequirementType.LENGTH, false },
            { RequirementType.SPECIALCHARACTERS, false },
            { RequirementType.UPPERCASE, false },
            { RequirementType.NUMBER, false },

        };

        switch (type)
        {
            case ValidationType.EMAIL:
                return (MailAddress.TryCreate(text, out _), -1);
            case DOB:
                return (DateTime.TryParse(text, out _), -1);
            case DISPLAY:
                return (text.ValidateDisplayName(), -1);
            case PASSWORD:

                if (text.Length > 8)
                {
                    ValidationLookup[LENGTH] = true;
                }

                if (text.Where(x => !char.IsLetterOrDigit(x)).Count() > 1)
                {
                    ValidationLookup[SPECIALCHARACTERS] = true;
                }

                if (text.Any(char.IsUpper))
                {
                    ValidationLookup[UPPERCASE] = true;
                }

                if (text.Any(char.IsDigit))
                {
                    ValidationLookup[RequirementType.NUMBER] = true;
                }

                if (ValidationLookup.All(x => x.Value == true))
                {
                    return (true, 100);
                }
                return (false, ValidationLookup.Count(x => x.Value == true) * 25);
        }
        var regex = new Regex(ValidationTypeRegex[type]);
        return (regex.IsMatch(text), -1);
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
        { ValidationType.EMAIL, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" },
        { PASSWORD, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" },
        { DISPLAY, @"\b([A-ZÀ-ÿ][-,a-z. ']+[ ]*)+" },
        { GENDER, @"/^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$/u" },
    };
}
