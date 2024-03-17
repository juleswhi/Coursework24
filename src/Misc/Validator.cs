using System.Net.Mail;
using System.Text.RegularExpressions;
using static ChessMasterQuiz.Misc.RequirementType;
using static ChessMasterQuiz.Misc.ValidationType;

namespace ChessMasterQuiz.Misc;

enum ValidationType
{
    EMAIL,
    USERNAME,
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
            { LENGTH, false },
            { SPECIALCHARACTERS, false },
            { UPPERCASE, false },
            { RequirementType.NUMBER, false },

        };

        switch (type)
        {
            case ValidationType.EMAIL:
                return (MailAddress.TryCreate(text, out _), 100);
            case DOB:
                return (DateTime.TryParse(text, out _), 100);
            case DISPLAY:
                return (text.ValidateDisplayName(), 100);
            case GENDER:
                return (text.ValidateGender(), 100);
            case USERNAME:
                return (text.ValidateUsername(), 100);
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
        if (string.IsNullOrWhiteSpace(text))
        {
            return false;
        }

        if (text.Length < 4)
        {
            return false;
        }

        if (text.Length > 16)
        {
            return false;
        }

        if (text.Any(x => !char.IsLetterOrDigit(x)))
        {
            return false;
        }

        return true;
    }

    private static bool ValidateUsername(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return false;
        }

        if (text.Length < 4)
        {
            return false;
        }

        if (text.Length > 16)
        {
            return false;
        }

        if (text.Any(x => !char.IsLetterOrDigit(x)))
        {
            return false;
        }
        // if (Users.Any(x => x.Username?.ToLower() == text)) return false;

        return true;

    }

    private static bool ValidateGender(this string text)
    {
        if (text.Length > 15)
        {
            return false;
        }

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
