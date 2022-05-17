# OneHundredSolver

A simple app written in c# to test strategies to solve the [100 prisoners problem](https://en.wikipedia.org/wiki/100_prisoners_problem).

The `main` branch  contains the shell for someone to try to implement their own solution. The `solution` branch has the solution implemented.

## Running

Execute
```
dotnet run
```

## How to create a new strategy to test

1. Create a new IGuessingStrategy (Optionally, you can inherit from BaseGuessingStrategy)
2. Add a new instance of your IGuessingStrategy to Program->STRATEGIES