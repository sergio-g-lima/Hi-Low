namespace Hi_Low
{
    internal class Program
    {
        internal const int minimum = 0;
        internal const int maximum = 100;

        internal enum EGuess_Result
        {
            no_guess,
            not_valid_number,
            lower,
            higher,
            equal
        }

        public static void Main(string[] args)
        {
            int number_of_guesses = run_game();

            Console.WriteLine($"User needed {number_of_guesses} to guess number");
            Console.ReadLine();

        }

        private static int run_game()
        {
            int try_count = 0;
            EGuess_Result guess_result = EGuess_Result.no_guess;
            Random rand = new();

            int target_number = rand.Next(minimum, maximum);

            do
            {
                if (guess_result != EGuess_Result.not_valid_number)
                {
                    try_count++;
                }

                Console.WriteLine($"Please enter a number between {minimum} and {maximum}");
                string number = Console.ReadLine() ?? "";

                guess_result = check_guess(number, target_number);

                switch (guess_result)
                {
                    case EGuess_Result.not_valid_number:
                        Console.WriteLine("Not a valid number");
                        break;
                    case EGuess_Result.lower:
                    case EGuess_Result.higher:
                        Console.WriteLine($"Number is {guess_result} than target");
                        break;
                }

            } while (guess_result != EGuess_Result.equal);
            
            return try_count;
        }

        public static EGuess_Result check_guess(string str_number, int target_number)
        {
            if (!int.TryParse(str_number, out int number))
            {
                return EGuess_Result.not_valid_number;
            }

            if (number < minimum || number > maximum)
            {
                return EGuess_Result.not_valid_number;
            }

            if (number > target_number)
            {
                return EGuess_Result.higher;
            }

            if (number < target_number)
            {
                return EGuess_Result.lower;
            }

            return EGuess_Result.equal;
        }
    }
}