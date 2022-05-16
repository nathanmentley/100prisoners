using OneHundredSolver.Strategies.Common;

namespace OneHundredSolver.Strategies;

/// <summary>
/// An <see cref="IGuessingStrategy"/> where the <see cref="Person"/> will start guessing at the door number equal to the index of which they guessed. The continue to guess the next door.
/// </summary>
public sealed class GuessStartingAtStrategy: BaseGuessingStrategy {
    /// <summary>
    /// The name of the Guessing Strategy
    /// </summary>
    public override string Name => "Guess starting at";

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
    public GuessStartingAtStrategy(int max, int index, int number):
        base(max, index, number) {}

    /// <summary>
    /// Fetches the next guess for the <see cref="Person"/>.
    /// </summary>
    protected override int GetNextGuess() =>
        (GetIndex() + GetPreviousGuesses().Count) % GetMax() + 1;
}