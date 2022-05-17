using OneHundredSolver.Strategies.Common;

namespace OneHundredSolver.Strategies;

/// <summary>
/// An <see cref="IGuessingStrategy"/> where the <see cref="Person"/> will start to guess the door number equal to their assigned number.
///     Then, they'll keep guessing the door number equal to the result of their last guess.
/// </summary>
public sealed class FollowTheNumbersStrategy: BaseGuessingStrategy {
    /// <summary>
    /// The name of the Guessing Strategy
    /// </summary>
    public override string Name => "Something";

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
    public FollowTheNumbersStrategy(int max, int index, int number):
        base(max, index, number) {}

    /// <summary>
    /// Fetches the next guess for the <see cref="Person"/>.
    /// </summary>
    protected override int GetNextGuess() =>
        GetPreviousGuesses().Count == 0 ?
            GetNumber():
            GetPreviousResults().Last();
}