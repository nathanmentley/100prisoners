namespace OneHundredSolver.Models;

/// <summary>
/// A POCO that contains information about a simulated person.
/// </summary>
public class Person {
    private readonly int _value;
    private bool _isAlive = true;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value">
    /// The number assigned to the person.
    /// </param>
    public Person(int value) => _value = value;

    /// <summary>
    /// Fetches the assigned value of the person.
    /// </summary>
    public int GetValue() => _value;

    /// <summary>
    /// Checks if the person is alive.
    /// </summary>
    public bool IsAlive() => _isAlive;

    /// <summary>
    /// Marks a person as dead.
    /// </summary>
    public void Kill() => _isAlive = false;
}