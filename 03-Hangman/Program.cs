namespace _03_Hangman;
class Program
{
    static void Main(string[] args)
    {
        const int MAX_WRONG_GUESSES = 6;
        const char UI_PLACEHOLDER = '_';

        List<string> secretWords = new List<string>()
        {
            "hangman",
            "mentoring",
            "csharp",
            "microsoft",
            "apple"
        };

        int listLeigh = secretWords.Count();
        Random random = new Random();
        string secretWord = secretWords[random.Next(secretWords.Count)]; // Randomly select a word from the list of randonm words

        Console.WriteLine("Welcome to the Hangman Game!");

        char[] guessedWordArray = new char[secretWord.Length];
        for (int i = 0; i < secretWord.Length; i++)
        {
            guessedWordArray[i] = UI_PLACEHOLDER;
        }

        int remainingTries = MAX_WRONG_GUESSES;
        while (remainingTries > 0)
        {
            ClearConsoleAndPrintGuessedWord(guessedWordArray);
            char guess = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (!char.IsLetter(guess))
            {
                Console.WriteLine("Please try again and enter a valid letter.");
                continue;
            }

            HashSet<char> guessedLetters = new HashSet<char>();
            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("You already guessed this letter '{0}'. Try a different letter.", guess);
                continue;
            }

            guessedLetters.Add(guess);

            bool found = false;
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] == guess)
                {
                    guessedWordArray[i] = guess;
                    found = true;
                }
            }

            if (!found)
            {
                remainingTries--;
                Console.WriteLine("Incorrect! Try to guess again.");
            }
            else
            {
                Console.WriteLine("Good guess! what's your next letter?");
            }

            if (!SecretWordContainsPlaceholderCharacter(guessedWordArray))
            {
                ClearConsoleAndPrintGuessedWord(guessedWordArray);
                Console.WriteLine("\nYou WIN! You guessed the word: " + secretWord);
                break;
            }
        }

        if (remainingTries == 0)
        {
            ClearConsoleAndPrintGuessedWord(guessedWordArray);
            Console.WriteLine("\nGame Over! The secret word was: " + secretWord);
        }

        static void ClearConsoleAndPrintGuessedWord(char[] guessedWordArray)
        {
            Console.Clear();
            foreach (char c in guessedWordArray)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }

        static bool SecretWordContainsPlaceholderCharacter(char[] guessedWordArray)
        {
            foreach (char c in guessedWordArray)
            {
                if (c == '_')
                {
                    return true;
                }
            }
            return false;
        }
    }
}