namespace MenuBuilder.Builders.MenuBuilder
{
    public class ConsoleMenuReadBuilder<T>
    {
        // List of options available for the user to select
        private List<MenuTypeOption<T>> options = new List<MenuTypeOption<T>>();

        // Indicates whether the menu should continue to display after an option has been selected
        private bool loop = false;

        // Prompt displayed to the user before the list of options
        private string prompt = "";

        // Function that clears the console after an option has been selected
        private Func<string> clearAction = null;

        // Method for reading user input and returning the selected option
        public T ReadInput()
        {
            while (true)
            {
                Console.Write(prompt);
                foreach (var option in options)
                {
                    Console.Write(option.Key + " ");
                }
                Console.Write(": ");
                var input = Console.ReadLine();
                foreach (var option in options)
                {
                    if (option.Key.ToLower() == input.ToLower())
                    {
                        if (clearAction != null)
                        {
                            Console.Clear();
                            clearAction();
                        }
                        return option.Action();
                    }
                }
                Console.WriteLine("Invalid input. Please try again.");
                if (!loop)
                {
                    return default(T);
                }
            }
        }

        // Method for adding a new option to the list
        public ConsoleMenuReadBuilder<T> AddOption(string key, Func<T> action)
        {
            options.Add(new MenuTypeOption<T>(key, action));
            return this;
        }

        // Method for setting the menu to loop
        public ConsoleMenuReadBuilder<T> AsLoop()
        {
            loop = true;
            return this;
        }

        // Method for setting the prompt
        public ConsoleMenuReadBuilder<T> SetPrompt(string prompt)
        {
            this.prompt = prompt;
            return this;
        }

        // Method for setting the clear action
        public ConsoleMenuReadBuilder<T> ClearAfterSelection(Func<string> action)
        {
            this.clearAction = action;
            return this;
        }

        public ConsoleMenuReadBuilder<T> AddIntegerOption(string key, Func<int, T> action)
        {
            options.Add(new MenuTypeOption<T>(key, () =>
            {
                while (true)
                {
                    Console.Write(prompt);
                    foreach (var option in options)
                    {
                        Console.Write(option.Key + " ");
                    }
                    Console.Write(": ");
                    var input = Console.ReadLine();

                    if (int.TryParse(input, out int intValue))
                    {
                        return action(intValue);
                    }

                    Console.WriteLine("Invalid input. Please enter an integer value.");
                    if (!loop)
                    {
                        return default(T);
                    }
                }
            }));
            return this;
        }

    }
}