using OneHundredSolver.Strategies.Common;

namespace OneHundredSolver.Strategies;

/// <summary>
/// An <see cref="IGuessingStrategy"/> where the <see cref="Person"/> will guess random doors without repeats.
/// </summary>
public sealed class RandomGuessingStrategy: BaseGuessingStrategy {
    private readonly Random _random = new Random();

    /// <summary>
    /// The name of the Guessing Strategy
    /// </summary>
    public override string Name => "Random";

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="max">
    /// The max value that can be guessed.
    /// </param>
    /// <param name="index">
    /// The index of the <see cref="Person"/>, aka the number of the order in which they guessed compared to everyone else.
    /// </param>
    /// <param name="number">
    /// The assigned number to the guessing <see cref="Person"/>.
    /// </param>
    public RandomGuessingStrategy(int max, int index, int number):
        base(max, index, number) {}

    /// <summary>
    /// Fetches the next guess for the <see cref="Person"/>.
    /// </summary>
    protected override int GetNextGuess()
    {
        while(true)
        {
            int index = _random.Next(1, GetMax() + 1);

            if (!GetPreviousGuesses().Contains(index))
            {
                return index;
            } 
        }
    }
}