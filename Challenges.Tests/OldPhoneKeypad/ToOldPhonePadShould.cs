using System.Diagnostics.CodeAnalysis;

namespace Challenges.Tests.OldPhoneKeypad;

using Challenges.OldPhoneKeypad;


[ExcludeFromCodeCoverage]
public class ToOldPhonePadShould
{
    [Theory]
    [InlineData("", "")]
    [InlineData("CAB", "222 2 22")]
    [InlineData("HELLO", "4433555 555666")]
    public void Handle_ValuesWithNoSpace(string input, string expected)
    {
        var output = OldPhoneKeypad.ToOldPhonePad(input);
        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData("&", "1")]
    [InlineData("'", "11")]
    [InlineData("(", "111")]
    [InlineData("'&(", "11 1 111")]
    public void Handle_ValuesWithPunctuation(string input, string expected)
    {
        var output = OldPhoneKeypad.ToOldPhonePad(input);
        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData(" ", "0")]
    [InlineData("  ", "0 0")]
    [InlineData("A B  C", "20220 0222")]
    [InlineData(
        "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG",
        "844330778844422255022777666966033366699058867 7777066688833777084433055529999 999036664"
    )]
    public void Handle_ValuesWithSpace(string input, string expected)
    {
        var output = OldPhoneKeypad.ToOldPhonePad(input);
        Assert.Equal(expected, output);
    }

    public static IEnumerable<object[]> GetInvalidChar()
    {
        var invalidChars = "0123456789!@#$%^*){}[].<>/?\"";
        foreach (var invalidChar in invalidChars)
        {
            yield return new object[] { $"{invalidChar}" };
        }
    }

    [Theory]
    [MemberData(nameof(GetInvalidChar))]
    public void Handle_ValuesWithInvalidChar(string input)
    {
        var exception = Assert.Throws<ArgumentException>(() => OldPhoneKeypad.ToOldPhonePad(input));
        Assert.Equal($"Contains invalid character '{input}'", exception.Message);
    }
}