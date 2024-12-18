using System.Text;

namespace Challenges.OldPhoneKeypad;

public class OldPhoneKeypad
{
    private static readonly string[] KEY_MAP = [" ", "&'(", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"];

    public static string OldPhonePad(string input)
    {
        var output = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];
            if (char.IsDigit(currentChar))
            {
                int keyIndex = currentChar - '0';
                int charCount = 0;
                while (i < input.Length && input[i] == currentChar)
                {
                    charCount++;
                    i++;
                }
                i--;
                int charIndex = (charCount - 1) % KEY_MAP[keyIndex].Length;
                output.Append(KEY_MAP[keyIndex][charIndex]);
            }
            else if (currentChar == '*')
            {
                if (output.Length > 0)
                {
                    output.Remove(output.Length - 1, 1);
                }
            }
            else if (currentChar == '#')
            {
                break;
            }
        }
        return output.ToString();
    }
}
