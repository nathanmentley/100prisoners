using OneHundredSolver.Strategies.Common;

namespace OneHundredSolver.Strategies;

/// <summary>
/// An <see cref="IGuessingStrategy"/> where the <see cref="Person"/> will start to guess the door number equal to their assigned number.
///     Then, they'll keep guessing the door number equal to the result of their last guess.
/// </summary>
/// <remarks>
/// The goal of this strategy is to find a loop of doors that will eventually lead to the person's number. (The only question is if that loop is less than 50 doors deep or not).
/// <list type="number">
///     <item>We start by guessing the door equal to the number of the person.</item>
///     <item>We'll then take the number in the door, and guess that door.</item>
///     <item>We'll repeat that process until the person's number is found.</item>
/// </list>
/// </remarks>
public sealed class FollowTheNumbersStrategy: BaseGuessingStrategy {
    /// <summary>
    /// The name of the Guessing Strategy
    /// </summary>
    public override string Name => "Follow The Numbers";

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
        GetPreviousGuesses().Count == 0 ?   // If this is the first guess.
            GetNumber():                    //  Guess the person's number.
            GetPreviousResults().Last();    // Else guess the number we last picked.
}