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


    public static readonly Dictionary<char, KeyCount> CHAR_KEY_COUNT = new Func<Dictionary<char, KeyCount>>(
        () =>
        {
            var map = new Dictionary<char, KeyCount>();
            for (int keyIndex = 0; keyIndex < KEY_MAP.Length; keyIndex++)
            {
                for (int charIndex = 0; charIndex < KEY_MAP[keyIndex].Length; charIndex++)
                {
                    char character = KEY_MAP[keyIndex][charIndex];
                    var keyCount = new KeyCount { Key = (char)(keyIndex + '0'), Count = charIndex + 1 };
                    map.Add(character, keyCount);
                }
            }
            return map;
        }
    )();

    public static string ToOldPhonePad(string input)
    {
        var output = new StringBuilder();
        char? lastKey = null;
        foreach (char ch in input)
        {
            char currentChar = char.ToUpper(ch);
            if (!CHAR_KEY_COUNT.ContainsKey(currentChar))
            {
                throw new ArgumentException($"Contains invalid character '{currentChar}'");
            }
            var keyCount = CHAR_KEY_COUNT[currentChar];
            if (lastKey == keyCount.Key)
            {
                output.Append(' ');
            }
            output.Append(keyCount.Key, keyCount.Count);
            lastKey = keyCount.Key;
        }
        return output.ToString();
    }
}

public record struct KeyCount
{
    public char Key { get; set; }
    public int Count { get; set; }
}