namespace Util.Tests;

public class StringUtil_OldPhonePadShould
{
    [Theory]
    [InlineData("222 2 22#", "CAB")]
    [InlineData("33#", "E")]
    [InlineData("227*#", "B")]
    [InlineData("4433555 555666#", "HELLO")]
    [InlineData("8 88777444666*664#", "TURING")]
    [InlineData(
        "84433077884442225502277766696603336669905886733 3066688833777084433055529999 999036664#",
        "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG"
    )]
    public void PassExamples(string input, string expected)
    {
        var output = StringUtil.OldPhonePad(input);
        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData("#", "")]
    [InlineData("*#", "")]
    [InlineData("***#", "")]
    [InlineData("2*#", "")]
    [InlineData("2*3*#", "")]
    [InlineData("23**#", "")]
    [InlineData("2 2 22***3*#", "")]
    public void ReturnEmpty(string input, string expected)
    {
        var output = StringUtil.OldPhonePad(input);
        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData("1#", "&")]
    [InlineData("11#", "'")]
    [InlineData("111#", "(")]
    [InlineData("2 1 11 111#", "a&'(")]
    [InlineData("212211222111#", "a&b'c(")]
    public void ReturnPunctuation_InputsWith1(string input, string expected)
    {
        var output = StringUtil.OldPhonePad(input);
        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData("0#", " ")]
    [InlineData("20#", "a ")]
    [InlineData("20220222#", "a b c")]
    public void ReturnSpace_InputsWith0(string input, string expected)
    {
        var output = StringUtil.OldPhonePad(input);
        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("2", "a ")]
    [InlineData("2322 222", "adbc")]
    public void Handle_InputsWithMissingHash(string input, string expected)
    {
        var output = StringUtil.OldPhonePad(input);
        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("2#22344", "a")]
    [InlineData("2322 222#234567899", "adbc")]
    public void Handle_InputsWithHashInTheMiddle(string input, string expected)
    {
        var output = StringUtil.OldPhonePad(input);
        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData("2222#", "ca")]
    [InlineData("22222#", "cb")]
    [InlineData("222222#", "cc")]
    [InlineData("2222222#", "cca")]
    [InlineData("77777#", "sp")]
    [InlineData("777777#", "sq")]
    [InlineData("7777777#", "sr")]
    [InlineData("77777777#", "ss")]
    [InlineData("777777777#", "ssp")]
    public void Handle_InputsWithMoreThanCharCountKeyPress(string input, string expected)
    {
        var output = StringUtil.OldPhonePad(input);
        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData(" ab.-*!$%&   c  de # ", "")]
    [InlineData("2a22bc222dd3  33#", "abcde")]
    public void Handle_InputsWithNonDigitChars(string input, string expected)
    {
        var output = StringUtil.OldPhonePad(input);
        Assert.Equal(expected, output);
    }
}