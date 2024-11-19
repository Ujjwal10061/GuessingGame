using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int targetNumber = random.Next(1, 101);    // Generate random number
        List<Guess> guesses = new List<Guess>();  // List to hold
        int userGuess;

        Console.WriteLine("Welcome to the Guessing Game! Try to guess the number between 1 and 100.");

        do
        {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine() ?? string.Empty; // null

            if (!int.TryParse(input, out userGuess)) // Validate 
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                continue;
            }

            if (guesses.Exists(g => g.UserGuess == userGuess)) // Check for repeated guesses
            {
                int previousIndex = guesses.FindIndex(g => g.UserGuess == userGuess);
                Console.WriteLine($"You guessed this number {guesses.Count - previousIndex} turns ago!");
                continue;
            }

            guesses.Add(new Guess(userGuess)); // Add the guess to the list

            if (userGuess < targetNumber)
                Console.WriteLine("Too low! Try again.");
            else if (userGuess > targetNumber)
                Console.WriteLine("Too high! Try again.");
        } while (userGuess != targetNumber);

        Console.WriteLine($"You won! The answer was {targetNumber}.");
    }
}
