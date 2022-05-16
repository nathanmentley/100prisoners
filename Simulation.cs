using OneHundredSolver.Models;
using OneHundredSolver.Strategies.Common;

namespace OneHundredSolver;

/// <summary>
/// A class that runs a simulation for an <see cref="IGuessingStrategy"/>.
/// </summary>
public class Simulation {
    private readonly int _numberOf;
    private readonly IList<Person> _people = new List<Person>();
    private readonly Drawers _drawers;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="numberOf">
    /// The number of people in the simulation.
    /// </param>
    public Simulation(int numberOf) {
        _numberOf = numberOf;
        _drawers = new Drawers(_numberOf);

        for(int i = 1; i <= _numberOf; i++)
        {
            _people.Add(new Person(i));
        }
    }

    /// <summary>
    /// Runs the simulation.
    /// </summary>
    /// <param name="guessingStrategyFactory">
    /// A <see cref="Func{int, int, IGuessingStrategy}"/> that generates a <see cref="IGuessingStrategy"/> to simulate.
    /// </param>
    /// <returns>
    /// The number of survivors 
    /// </returns>
    public int Run(Func<int, int, IGuessingStrategy> guessingStrategyFactory) {
        int count = 1;

        foreach(Person person in _people)
        {
            bool guessed = false;
            IGuessingStrategy strategy = guessingStrategyFactory(count++, person.GetValue());

            for(int i = 1; i <= _numberOf / 2; i++)
            {
                int guess = strategy.NextGuess();
                int result = _drawers.Fetch(guess);

                strategy.RecordResult(result);

                if (result == person.GetValue())
                {
                    guessed = true;

                    break;
                }
            }

            if (!guessed)
            {
                person.Kill();
            }
        }

        return _people.Count(person => person.IsAlive());
    }
}