namespace Util.Tests;

public class StringUtil_OldPhonePadShould
{
    [Theory]
    [InlineData("33#", "E")]
    [InlineData("227*#", "B")]
    [InlineData("4433555 555666#", "HELLO")]
    [InlineData("8 88777444666*664#", "TURING")]
    public void PassExamples(string input, string expected)
    {
        var output = StringUtil.OldPhonePad(input);
        Assert.Equal(expected, output);
    }
}