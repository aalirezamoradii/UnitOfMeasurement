namespace Common;

public static class ParserHelper
{
    private static bool IsNameChar(char a)
    {
        return a == 'a';
    }

    private static bool IsNum(char a)
    {
        return char.IsNumber(a);
    }

    private static bool IsLeftBracket(char a)
    {
        return a == '(';
    }

    private static bool IsRightBracket(char a)
    {
        return a == ')';
    }

    private static bool IsOperator(char a)
    {
        return "+-*/".Contains(a);
    }

    private static ParsedOperatorType FindOperator(string a)
    {
        return a switch
        {
            "+" => ParsedOperatorType.Plus,
            "-" => ParsedOperatorType.Minus,
            "/" => ParsedOperatorType.Division,
            "*" => ParsedOperatorType.Multiplication,
            _ => ParsedOperatorType.Invalid
        };
    }

    private static bool IsWhiteSpace(char a)
    {
        return char.IsWhiteSpace(a);
    }

    private static ParsedSubstringType GetTokenType(char c)
    {
        if (IsNameChar(c))
        {
            return ParsedSubstringType.Name;
        }

        if (IsNum(c))
        {
            return ParsedSubstringType.Num;
        }

        if (IsWhiteSpace(c))
        {
            return ParsedSubstringType.WhiteSpace;
        }

        if (IsLeftBracket(c) || IsRightBracket(c))
        {
            return ParsedSubstringType.Bracket;
        }

        return IsOperator(c)
            ? ParsedSubstringType.Operator
            : ParsedSubstringType.Invalid;
    }

    public static string ParseExpression(string expression)
    {
        if (expression.Count(IsNameChar) > 1)
            throw new FormatException("number of a more than one!");

        if (IsRightBracket(expression.First()))
            throw new FormatException("bracket format");

        if (IsLeftBracket(expression.Last()))
            throw new FormatException("bracket format");

        if (expression.Count(IsLeftBracket) != expression.Count(IsRightBracket))
            throw new FormatException("bracket count");

        var items = new List<char>(expression.Trim().Length);
        foreach (var token in expression)
        {
            var currentType = GetTokenType(token);
            if (currentType == ParsedSubstringType.Invalid)
                throw new FormatException(nameof(token));

            items.Add(token);
        }

        return string.Join(" ", items);
    }

    private static double Value(string expression)
    {
        var split = expression.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var operators = split
            .Select((s, i) => new
            {
                Operator = FindOperator(s),
                Index = i
            })
            .Where(w => w.Operator != ParsedOperatorType.Invalid)
            .OrderBy(o => (byte) o.Operator)
            .ToList();

        double? result = null;
        foreach (var o in operators)
        {
            var previous = result ?? double.Parse(split[o.Index - 1]);
            var next = double.Parse(split[o.Index + 1]);
            result = o.Operator switch
            {
                ParsedOperatorType.Plus => previous + next,
                ParsedOperatorType.Minus => previous - next,
                ParsedOperatorType.Multiplication => previous * next,
                ParsedOperatorType.Division => previous / next,
                _ => throw new ArgumentOutOfRangeException(nameof(expression))
            };
        }

        return result ?? 0;
    }

    private static string Recursive(string expression)
    {
        if (!expression.Contains('('))
            return expression;

        while (expression.Contains('('))
        {
            var first = -1;
            var last = -1;
            for (var i = 0; i < expression.Length; i++)
            {
                if (IsLeftBracket(expression[i]))
                    first = i;

                if (!IsRightBracket(expression[i])) continue;

                last = i;
                break;
            }

            last = (first == 0 ? last : last - first) + 1;
            var bracket = expression.Substring(first, last);

            var trim = bracket.Contains('(') || bracket.Contains(')')
                ? bracket
                    .Replace("(", "")
                    .Replace(")", "")
                : bracket;
            var value = Value(trim);
            expression = expression.Replace($"{bracket}", $"{value}");
        }

        return expression;
    }

    public static double Calculate(string expression, double value)
    {
        expression = expression.Replace("a", $"{value}");

        expression = Recursive(expression);

        var result = Value(expression);

        return result;
    }
}