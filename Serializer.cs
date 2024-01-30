using static System.String;
using static System.Char;
using static LonSerializer.TokenType;
using System.Text;
using System.Reflection;
using System.Diagnostics;


namespace LonSerializer;

/// <summary>
/// Lon ( Lake Object Notation ) Converter.
/// </summary>

internal static class LonConvert
{
    public static string Serialize(Question question)
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append($"Type:\"{(int)question.Type}\",");
        stringBuilder.Append($"Name:\"{question.Name}\",");
        stringBuilder.Append($"Difficulty:\"{(int)question.Difficulty}\",");

        if(question is TextQuestion)
        {
            stringBuilder.Append("{");
            TextQuestion tq = (question as TextQuestion)!;
            stringBuilder.Append($"Q:\"{tq.Q}\",");
            for(int i = 0; i < tq.A.Answers.Count; i++)
            {
                stringBuilder.Append($"Answer{i+1}:\"{tq.A.Answers[i]}\",");
            }
            stringBuilder.Append($"Index:\"{tq.A.Index}\"");
            stringBuilder.Append("}");
        }

        return stringBuilder.ToString();
    }

    public static string Serialize(List<Question> questions)
    {
        StringBuilder stringBuilder = new();

        foreach(var q in questions)
        {
            stringBuilder.Append(Serialize(q));
            stringBuilder.Append("\n");
        }

        return stringBuilder.ToString();
    }

    public static List<Question> Deserialize(params string[] strs)
    {
        List<Question> questions = new(); 
        foreach(var str in strs)
        {
            if (IsNullOrWhiteSpace(str)) continue;
            List<Token> tokens = Lexer.Lex(str);
            Question question = Parser.Parse(tokens);
            questions.Add(question);
        }
        return questions;
    }
}

public enum TokenType
{
    COLON,
    LEFT_BRACKET,
    RIGHT_BRACKET,
    IDENTIFIER,
    DATA
}

public class Token
{
    public TokenType Type { get; init; }
    public object? Data { get; init; }

    public void Deconstruct(out TokenType type, out object? data)
    {
        type = Type;
        data = Data;
    }

    public Token(TokenType type, object data)
    {
        Type = type;
        Data = data;
    }

    public Token(TokenType type)
    {
        if (type == DATA || type == IDENTIFIER) throw new Exception();

        Type = type;
        Data = null;
    }
}

public static class Lexer
{

    private static int _current;
    private static List<Token> _tokens;

    private static void Next(int step = 1) => _current += step;
    private static char Peek(ReadOnlySpan<char> str) => str[_current + 1];
    private static char Current(ReadOnlySpan<char> str) => str[_current];
    private static void Consume(Token token)
    {
        _tokens.Add(token);
        _current++;
    }

    // Spaggethu code
    public static List<Token> Lex(string input)
    {
        ReadOnlySpan<char> str = input.AsSpan();

        _current = 0;
        _tokens = new();

        for (; _current < str.Length;)
        {
            switch (Current(str))
            {
                case ':':
                    Consume(new Token(COLON));
                    break;
                case ',':
                    Next();
                    break;
                case '{':
                    Consume(new Token(LEFT_BRACKET));
                    break;
                case '}':
                    Consume(new Token(RIGHT_BRACKET));
                    break;
                case '"':
                    {
                        Next();
                        StringBuilder sb = new();
                        while (Current(str) != '"')
                        {
                            sb.Append(Current(str));
                            Next();
                        }

                        Consume(new Token(DATA, sb.ToString()));

                        break;
                    }

                default:
                    {
                        StringBuilder sb = new();
                        while(IsLetterOrDigit(Current(str)))
                        {
                            sb.Append(Current(str));
                            Next();
                        }

                        Consume(new Token(IDENTIFIER, sb.ToString()));
                        break;
                    }
            }
        }

        return _tokens;

    }
}

public static class Parser
{

    private static List<Type> ValidTypes = new()
    {
        typeof(Question),
        typeof(TextQuestion),
        typeof(Answer)
    };

    private static int _current;
    private static List<Token> _tokens = new();

    private static void Next(int step = 1) => _current += step;
    private static Token Peek() => _tokens[_current < _tokens.Count ? _current + 1 : _current];
    private static Token Current() => _tokens[_current];
    private static Token Previous() => _tokens[_current > 0 ? _current - 1 : _current];

    public static Question Parse(List<Token> tokens)
    {
        var inBrackets = false;

        _current = 0;
        _tokens = tokens;

        List<string> answers = new();
        int index = 0;

        TextQuestion question = new(); 

        for(; _current < _tokens.Count;)
        {
            switch(Current().Type)
            {
                case LEFT_BRACKET:
                    inBrackets = true;
                    break;

                case IDENTIFIER:
                    {
                        var name = Current().Data as string;


                        PropertyInfo? property = null;

                        void GetProps(Type type)
                        {
                            if (!ValidTypes.Contains(type))
                            {
                                return;
                            }
                            // Debug.Print($"Looking at type {type.Name}, for name: {name}");

                            var props = type.GetProperties();

                            property = props.FirstOrDefault(
                                x => x.Name == name);

                            if(property is not null)
                            {
                                return;
                            }

                            foreach(var prop in props)
                            {
                                GetProps(prop.PropertyType);
                            }
                        }

                        if(name!.ToLower().Contains("answer"))
                        {
                            Next();
                            answers.Add((string)Current().Data!);
                            // Debug.Print($"Added Answer: {Current().Data}");
                            break;
                        }
                        else if(name.ToLower().Contains("index"))
                        {
                            Next();
                            index = int.Parse((string)Current().Data!);
                            // Debug.Print($"Added Index: {Current().Data}");
                            break;
                        }
                        else
                        {
                            GetProps(question.GetType());
                        }

                        if(property is null)
                        {
                            // Debug.Print($"Could not find prop for {name}");
                            break;
                        }


                        // Debug.Print($"Found Type: {property.Name}");

                        // If null, then identifier must be in the Answers 
                        if (property is null)
                        {
                            // Get type of the question ( TextQuestion etc... ) 
                            // Look up properties recursively

                            if(question.Type == QuestionType.TEXT)
                            {
                                property = CheckForProperties(typeof(Answer), name);
                            }

                            if(property is null)
                            {
                                Debug.Print($"Could not find property called: {name} in {question.GetType().Name}");
                                break;
                            }

                        }

                        Next();

                        // If the property is an enum, then a explicit conversion from stirng -> enum Type is needed
                        if (property!.PropertyType.IsEnum)
                        {
                            Enum.TryParse(property.PropertyType, (string)Current().Data!, out var output);
                            property.SetValue(question, output);
                        }
                        else
                        {
                            property.SetValue(question, Convert.ChangeType(Current().Data, property.PropertyType));
                        }


                        // If its not a 
                        // else
                        // {
                        // property.SetValue(question, Current().Data);
                        // }




                        break;
                    }
            }
            Next();
        }

        // question.A = new(null,);
        question.A = new(answers, (uint)index);
        return question;
    }

    
    private static PropertyInfo? CheckForProperties(Type type, string name)
    {
        var props = type.GetProperties();

        var prop = props.FirstOrDefault(
            x => x.Name == name);

        return prop;
    }



}
