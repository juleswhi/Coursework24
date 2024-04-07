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
    PASSWORD_CONFIRM,
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

public enum PasswordRequirementLevel
{
    STRONG,
    MEDIUM,
    WEAK
}

internal static class Validator
{
    public static (bool, float) Validate(this string text, ValidationType type, PasswordRequirementLevel? passwordLevel = null)
    {
        passwordLevel ??= GetAdminConfig()?.PasswordRequirementLevel;

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
            case PASSWORD_CONFIRM:
                return (false, 0);
            case DOB:
                return IsValidAge(text);
            case DISPLAY:
                return (text.ValidateDisplayName(), 100);
            case GENDER:
                return (text.ValidateGender(), 100);
            case USERNAME:
                return (text.ValidateUsername(), 100);
            case PASSWORD:
                int minimumLength = passwordLevel switch
                {
                    STRONG => 12,
                    MEDIUM => 8,
                    _ => 4,
                };

                int specialCharacterCount = passwordLevel switch
                {
                    STRONG => 3,
                    MEDIUM => 1,
                    _ => 0
                };

                int upperCaseCount = passwordLevel switch
                {
                    STRONG => 1,
                    MEDIUM => 1,
                    _ => 0
                };

                int numberCount = passwordLevel switch
                {
                    STRONG => 2,
                    MEDIUM => 1,
                    _ => 0
                };

                if (text.Length >= minimumLength)
                {
                    ValidationLookup[LENGTH] = true;
                }

                if (text.Where(x => !char.IsLetterOrDigit(x)).Count() >= specialCharacterCount)
                {
                    ValidationLookup[SPECIALCHARACTERS] = true;
                }

                if (text.Where(char.IsUpper).Count() >= upperCaseCount)
                {
                    ValidationLookup[UPPERCASE] = true;
                }

                if (text.Where(char.IsDigit).Count() >= numberCount)
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
        if (Users.Any(x => x.Username?.ToLower() == text)) return false;

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

    public static (bool, float) IsValidAge(string b)
    {
        if (!DateTime.TryParse(b, out var birth)) 
            return (false, 0);

        DateTime today = DateTime.Today;
        int age = today.Year - birth.Year;

        if(birth > today.AddYears(-age))
        {
            age--;
        }

        bool isRightAge = age > 14 && age < 120;
        int percentage = 50;

        if (isRightAge) percentage = 100;

        return (isRightAge, percentage);
    }
}
