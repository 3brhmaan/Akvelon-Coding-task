using System.Text;

namespace src;

/// <summary>
/// Holds the result of a FizzBuzz transformation: the transformed string and
/// the count of words that were replaced with Fizz, Buzz, or FizzBuzz.
/// </summary>
public class FizzBuzzResult
{
    /// <summary>The input string with qualifying words replaced.</summary>
    public string OutputString { get; }
    /// <summary>The number of words replaced (Fizz, Buzz, and FizzBuzz each count once).</summary>
    public int Count { get; }
    public FizzBuzzResult(string outputString , int count)
    {
        OutputString = outputString;
        Count = count;
    }
}

/// <summary>
/// Detects and replaces every 3rd, 5th, and 15th alphanumeric word in a string
/// with "Fizz", "Buzz", and "FizzBuzz" respectively.
/// </summary>
public class FizzBuzzDetector
{
    /// <summary>
    /// Flushes the currently-accumulated word buffer into the result, replacing it
    /// with "Fizz"/"Buzz"/"FizzBuzz" if its position warrants it.
    /// </summary>
    private void ProcessWord(StringBuilder currentWord, StringBuilder result, ref int validWords, ref int replacedWordsCount)
    {
        if(currentWord.Length == 0)
            return;

        var word = currentWord.ToString().Trim('\'' , '-');

        if (word.Length > 0)
        {
            validWords++;
            bool isReplaced = false;

            // replace each 3rd word with Fizz
            if (validWords % 3 == 0)
            {
                result.Append("Fizz");
                isReplaced = true;
            }

            // replace each 5th word with Buzz
            if (validWords % 5 == 0)
            {
                result.Append("Buzz");
                isReplaced = true;
            }


            if (isReplaced)
            {
                replacedWordsCount++;
            }

            // if it's not 3rd or 5th word then add it as it's
            if (validWords % 3 != 0 && validWords % 5 != 0)
            {
                result.Append(word);
            }
        }
        else
        {
            result.Append(currentWord.ToString());
        }

        currentWord.Clear();
    }

    /// <summary>
    /// Replaces qualifying words in <paramref name="input"/> and returns the
    /// transformed string along with the count of replaced words.
    /// </summary>
    /// <param name="input">The source string to process. Must be 7–100 characters and non-null.</param>
    /// <returns>A <see cref="FizzBuzzResult"/> containing the output string and replacement count.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when input length is outside the 7–100 range.</exception>
    public object getOverlappings(string input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input) , "Input string cannot be null.");

        if (input.Length < 7 || input.Length > 100)
            throw new ArgumentException(
                $"Input length must be between 7 and 100 characters. Actual length: {input.Length}." ,
                nameof(input));

        StringBuilder result = new();
        StringBuilder currentWord = new();

        int validWords = 0; // count valid words
        int replacedWordsCount = 0; // count words that replaced with Fizz, Buzz, FizzBuzz

        foreach(char c in input)
        {
            // words like it's or well-known is a valid word
            if(char.IsLetterOrDigit(c) || c == '\'' || c == '-')
            {
                currentWord.Append(c);
            }
            else
            {
                ProcessWord(currentWord, result, ref validWords, ref replacedWordsCount);
                result.Append(c);
            }
        }

        if (currentWord.Length > 0)
        {
            ProcessWord(currentWord, result, ref validWords, ref replacedWordsCount);
        }

        return new FizzBuzzResult (result.ToString(), replacedWordsCount);
    }
}
