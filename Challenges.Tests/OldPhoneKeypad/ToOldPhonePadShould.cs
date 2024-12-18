namespace Challenges.Tests.OldPhonePad;

public class ToOldPhonePadShould
{
    [Theory]
    [InlineData("", "")]
    [InlineData("CAB", "222 2 22")]
    [InlineData("HELLO", "4433555 555666")]
    [InlineData(
        "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG",
        "844330778844422255022777666966033366699058867 7777066688833777084433055529999 999036664"
    )]
    public void PassExamples(string input, string expected)
    {
        var output = OldPhoneKeypad.ToOldPhonePad(input);
        Assert.Equal(expected, output);
    }
}