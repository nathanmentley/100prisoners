namespace OneHundredSolver.Models;

public class Drawers {
    private readonly IReadOnlyList<int> _data;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="count">
    /// How many doors on the drawers.
    /// </param>
    public Drawers(int count) {
        List<int> data = new List<int>();

        IList<int> previousGuesses = new List<int>();
        Random random = new Random();

        for(int i = 0; i < count; i++) {
            int index = GetNextValue(random, previousGuesses, count);
            previousGuesses.Add(index);

            data.Add(index);
        }

       _data = data; 
    }

    /// <summary>
    /// Fetches the number assigned to the door at an index.
    /// </summary>
    /// <param name="index">
    /// The index of the door to open.
    /// </param>
    /// <returns>
    /// The value assigned to the door at <paramref name="index"/>.
    /// </returns>
    public int Fetch(int index) => _data[index - 1];

    /// <summary>
    /// Fetches a random value, but won't reuse an existing value.
    /// </summary>
    private static int GetNextValue(Random random, IList<int> previous, int max)
    {
        while(true)
        {
            int index = random.Next(1, max + 1);

            if (!previous.Contains(index))
            {
                return index;
            } 
        }
    }
}