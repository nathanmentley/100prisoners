using OneHundredSolver.Models;

namespace OneHundredSolver.Strategies.Common;

/// <summary>
/// An abstract class for building an <see cref="IGuessingStrategy"/> for a <see cref="Person"/> to use when guessing.
/// </summary>
public abstract class BaseGuessingStrategy: IGuessingStrategy {
    private readonly int _max;
    private readonly int _index;
    private readonly int _number;
    private readonly List<int> _previousGuesses = new List<int>();
    private readonly List<int> _previousResults = new List<int>();

    /// <summary>
    /// The name of the Guessing Strategy
    /// </summary>
    public abstract string Name { get; }

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
    public BaseGuessingStrategy(int max, int index, int number) {
        _max = max;
        _index = index;
        _number = number;
    }

    /// <summary>
    /// Fetches the next door for the person to guess.
    /// </summary>
    public int NextGuess()
    {
        int guess = GetNextGuess();

        _previousGuesses.Add(guess);

        return guess;
    }

    /// <summary>
    /// Records the last guess result for the strategy to use in determining the next guess.
    /// </summary>
    public void RecordResult(int result) =>
        _previousResults.Add(result);

    /// <summary>
    /// Fetches the next guess for the <see cref="Person"/>.
    /// </summary>
    protected abstract int GetNextGuess();

    /// <summary>
    /// Fetches <see cref="_max"/>.
    /// </summary>
    protected int GetMax() => _max;

    /// <summary>
    /// Fetches <see cref="_index"/>.
    /// </summary>
    protected int GetIndex() => _index;

    /// <summary>
    /// Fetches <see cref="_number"/>.
    /// </summary>
    protected int GetNumber() => _number;

    /// <summary>
    /// Gets an <see ref="IReadOnlyList{int}"/> of all the previous doors that were selected.
    /// </summary>
    protected IReadOnlyList<int> GetPreviousGuesses() => _previousGuesses;

    /// <summary>
    /// Gets an <see ref="IReadOnlyList{int}"/> of all the previous results that were guessed.
    /// </summary>
    protected IReadOnlyList<int> GetPreviousResults() => _previousResults;
}