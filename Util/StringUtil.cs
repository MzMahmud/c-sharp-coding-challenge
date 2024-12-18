namespace Util;

public class StringUtil
{
    private static readonly string[] KEY_MAP = [" ", "&'(", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"];

    public static string OldPhonePad(string input)
    {
        var output = new List<char>();
        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];
            if (char.IsDigit(currentChar))
            {
                int keyIndex = currentChar - '0';
                int charCount = 0;
                while (i < input.Length && input[i] == currentChar && charCount < KEY_MAP[keyIndex].Length)
                {
                    charCount++;
                    i++;
                }
                i--;
                int charIndex = charCount - 1;
                output.Add(KEY_MAP[keyIndex][charIndex]);
            }
            else if (currentChar == '*')
            {
                if (output.Count > 0)
                {
                    output.RemoveAt(output.Count - 1);
                }
            }
            else if (currentChar == '#')
            {
                break;
            }
        }
        return string.Join("", output);
    }
}
