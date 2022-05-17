using OneHundredSolver.Strategies.Common;

using OneHundredSolver.Strategies;

namespace OneHundredSolver;

/// <summary>
/// Entrypoint class
/// </summary>
public static class Program {
    /// <summary>
    /// The number of prisoners.
    /// </summary>
    private readonly static int NUMBER_OF = 100;

    /// <summary>
    /// How many runs to simulate for each strategy.
    /// </summary>
    private readonly static int TOTAL_RUNS = 10_000;

    /// <summary>
    /// A collection of all the IGuessingStrategies to process.
    /// </summary>
    private readonly static IEnumerable<Func<int, int, IGuessingStrategy>> STRATEGIES =
        new List<Func<int, int, IGuessingStrategy>>()
        {
            (index, id) => new OneThroughFiftyGuessingStrategy(NUMBER_OF, index, id),
            (index, id) => new RandomGuessingStrategy(NUMBER_OF, index, id),
            (index, id) => new GuessStartingAtStrategy(NUMBER_OF, index, id),
            (index, id) => new FollowTheNumbersStrategy(NUMBER_OF, index, id)
        };

    /// <summary>
    /// Entrypoint Method
    /// </summary>
    public static void Main() {
        Dictionary<string, IReadOnlyList<int>> results = new Dictionary<string, IReadOnlyList<int>>();

        foreach(Func<int, int, IGuessingStrategy> stratFactory in STRATEGIES)
        {
            results[stratFactory(0, 0).Name] = 
                Enumerable
                    .Range(1, TOTAL_RUNS)
                    .Select(_ => new Simulation(NUMBER_OF).Run(stratFactory))
                    .ToList();
        }

        PrintResults(results);
    }

    /// <summary>
    /// Printes the results to the console. 
    /// </summary>
    /// <param name="results">
    /// The results of all the strategy runs.
    /// </param>
    private static void PrintResults(IReadOnlyDictionary<string, IReadOnlyList<int>> results)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{"Strategy Name",-44} {"Avg % Find Number",-17} {"Avg % Of Survival",-17}");
        Console.ResetColor();

        foreach((string name, IReadOnlyList<int> result) in results)
        {
            PrintResult(name, result);
        }
    }

    /// <summary>
    /// Printes the results of a single strategy to the console. 
    /// </summary>
    /// <param name="name">
    /// The name of the <see cref="IGuessingStrategy"/>.
    /// </param>
    /// <param name="result">
    /// The total number of survivors from each run.
    /// </param>
    private static void PrintResult(string name, IReadOnlyList<int> result)
    {
        double average = result.Average();
        double percentOfTimeAllSurvive = Convert.ToDouble(result.Count(x => x == NUMBER_OF)) / NUMBER_OF;

        if (percentOfTimeAllSurvive > 15)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        Console.WriteLine($"{name,-44} {average,-17} {percentOfTimeAllSurvive,-16}");
        Console.ResetColor();
    }
}