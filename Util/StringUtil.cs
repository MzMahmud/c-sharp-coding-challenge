using System.Diagnostics.CodeAnalysis;

namespace Util;

public class StringUtil
{
    private static readonly string[] KEY_MAP = { " ", "&'(", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ" };

    public static string OldPhonePad(string input)
    {
        var output = new List<char>();
        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];
            if (currentChar == '#')
            {
                break;
            }
            else if (Char.IsDigit(currentChar))
            {
                int keyIndex = currentChar - '0';
                int charCount = 0;
                while (i < input.Length && input[i] == currentChar)
                {
                    charCount++;
                    i++;
                }
                i--;
                output.Add(KEY_MAP[keyIndex][charCount - 1]);
            }
        }
        return String.Join("", output);
    }
}
