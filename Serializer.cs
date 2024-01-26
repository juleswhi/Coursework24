using static System.String;
using static System.Char;
using static QonSerializer.TokenType;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace QonSerializer;

/// <summary>
/// Qon ( Question Object Notation ) Converter.
/// </summary>

internal static class QonConvert
{
    public static string SerializeQuestion(Question question)
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append($"Type:{question.Type},");
        stringBuilder.Append($"Name:{question.Name},");
        stringBuilder.Append($"Difficulty:{question.Difficulty},");

        if(question is TextQuestion)
        {
            stringBuilder.Append("{");
            TextQuestion tq = (question as TextQuestion)!;
            stringBuilder.Append($"Question:{tq.Q},");
            for(int i = 0; i < tq.A.Answers.Count; i++)
            {
                stringBuilder.Append($"Answer{i+1}:{tq.A.Answers[i]},");
            }
            stringBuilder.Append($"Index:{tq.A.index}");
            stringBuilder.Append("}");
        }

        return stringBuilder.ToString();
    }

    public static string SerializeQuestion(List<Question> questions)
    {
        StringBuilder stringBuilder = new();

        foreach(var q in questions)
        {
            stringBuilder.Append(SerializeQuestion(q));
            stringBuilder.Append("\n");
        }

        return stringBuilder.ToString();
    }

    public static List<Question> DeserializeQuestion(params string[] strs)
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

    private static void Next() => _current++;
    private static char Peek(ReadOnlySpan<char> str) => str[_current + 1];
    private static char Previus(ReadOnlySpan<char> str) => str[_current - 1];
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
                default:
                    {
                        StringBuilder sb = new();
                        while (IsLetterOrDigit(Peek(str)))
                        {
                            Next();
                            sb.Append(Current(str));
                        }

                        if(!_tokens.Any())
                        {
                            Consume(new Token(IDENTIFIER, sb.ToString()));
                        }
                        else if (_tokens.Last().Type == COLON)
                        {
                            Consume(new Token(DATA, sb.ToString()));
                        }
                        else
                        {
                            Consume(new Token(IDENTIFIER, sb.ToString()));
                        }

                        break;
                    }
            }
        }

        return _tokens;

    }
}

public static class Parser
{
    private static int _current;
    private static List<Token> _tokens = new();

    private static void Next() => _current++;
    private static Token Peek() => _tokens[_current < _tokens.Count ? _current + 1 : _current];
    private static Token Current() => _tokens[_current];
    private static Token Previous() => _tokens[_current > 0 ? _current - 1 : _current];

    public static Question Parse(List<Token> tokens)
    {

        foreach(var token in tokens)
        {
            Debug.Print(token.Type.ToString());
        }

        _current = 0;
        _tokens = tokens;

        TextQuestion question = new(); 

        // Grab the type of Question 
        Type questionType = typeof(Question);
        var questionFieldNames = questionType.GetFields(); 

        // false for left, true for right
        bool insideQuestions = false;

        FieldInfo? currentField = null;

        Answer currentAnswer = new(null, 0);

        for(; _current < _tokens.Count;)
        {
            // Cond XOR 
            // if (token.Type == COLON) side ^= true;

            if (Current().Type == LEFT_BRACKET) insideQuestions ^= true;

            switch(Current().Type)
            {
                case IDENTIFIER:
                    if (!insideQuestions)
                    {
                        var field = questionFieldNames.FirstOrDefault(x => x.Name == (string)Current().Data!);
                        if (field is null) break;
                        currentField = field;
                    }
                    else
                    {
                        if((string)Current().Data! == "Question")
                        {
                            Next();
                            Next();
                            // Onto the data
                            if(Current().Type != DATA)
                            {
                                throw new Exception("Current Type was not DATA, Could not parse");
                            }
                            question.Q = (string)Current().Data!;
                        }
                        else if(((string)Current().Data!).Contains("Answer"))
                        {
                            Next();
                            Next();
                            currentAnswer.Answers.Add((string)Current().Data!);
                        }
                        else if((string)Current().Data! == "Index")
                        {
                            Next();
                            Next();
                            currentAnswer = new(currentAnswer.Answers, (uint)Current().Data!);
                        }
                    }
                    break;
                case DATA:
                    if (currentField is null) break;
                    currentField!.SetValue(question, Current().Data);
                    break;
                default:
                    break;
            }
            Next();
        }

        question.A = currentAnswer;
        return question;
    }
    
}
