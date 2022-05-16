namespace OneHundredSolver.Strategies.Common;

/// <summary>
/// An interface to wrap guessing strategy logic. 
/// </summary>
public interface IGuessingStrategy {
    /// <summary>
    /// The name of the Guessing Strategy
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Fetches the next door for the person to guess.
    /// </summary>
    int NextGuess();

    /// <summary>
    /// Records the last guess result for the strategy to use in determining the next guess.
    /// </summary>
    void RecordResult(int result);
}