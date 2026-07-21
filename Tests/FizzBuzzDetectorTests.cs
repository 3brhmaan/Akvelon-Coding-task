using src;

namespace Tests;
public class FizzBuzzDetectorTests
{
    private readonly FizzBuzzDetector _detector = new FizzBuzzDetector();

    [Fact]
    public void GetOverlappings_ExampleFromSpec_ProducesExpectedOutputAndCount()
    {
        string input = "Mary had a little lamb\nLittle lamb, little lamb\n" +
                        "Mary had a little lamb\nIt's fleece was white as snow";

        var result = _detector.getOverlappings(input) as FizzBuzzResult;

        string expected = "Mary had Fizz little Buzz\nFizz lamb, little Fizz\n" +
                           "Buzz had Fizz little lamb\nFizzBuzz fleece was Fizz as Buzz";

        Assert.Equal(expected , result.OutputString);
        Assert.Equal(9 , result.Count);
    }

    [Fact]
    public void GetOverlappings_FifteenthWord_BecomesFizzBuzz_CountedOnce()
    {
        string input = "a b c d e f g h i j k l m n o";

        var result = _detector.getOverlappings(input) as FizzBuzzResult;

        Assert.EndsWith("FizzBuzz" , result.OutputString);

        Assert.Equal(7 , result.Count);
    }

    [Fact]
    public void GetOverlappings_PunctuationAndApostrophes_PreservedCorrectly()
    {
        string input = "It's a nice-day, isn't it?";
        var result = _detector.getOverlappings(input) as FizzBuzzResult;

        Assert.Contains("," , result.OutputString);
        Assert.Contains("?" , result.OutputString);
    }

    [Fact]
    public void GetOverlappings_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _detector.getOverlappings(null));
    }

    [Fact]
    public void GetOverlappings_InputTooShort_ThrowsArgumentException()
    {
        string tooShort = "ab"; // length 2, min is 7
        Assert.Throws<ArgumentException>(() => _detector.getOverlappings(tooShort));
    }

    [Fact]
    public void GetOverlappings_InputTooLong_ThrowsArgumentException()
    {
        string tooLong = new string('a' , 101); // length 101, max is 100
        Assert.Throws<ArgumentException>(() => _detector.getOverlappings(tooLong));
    }

    [Fact]
    public void GetOverlappings_AlphanumericWords_AreCountedCorrectly()
    {
        // digits should count as part of words, not break them
        string input = "line1 line2 line3 line4 line5";
        var result = _detector.getOverlappings(input) as FizzBuzzResult;

        // word3 -> Fizz, word5 -> Buzz
        Assert.Equal("line1 line2 Fizz line4 Buzz" , result.OutputString);
        Assert.Equal(2 , result.Count);
    }
}
