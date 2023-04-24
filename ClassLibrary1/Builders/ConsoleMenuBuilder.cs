using MenuBuilder.Interfaces;

namespace MenuBuilder.Builders.MenuBuilder
{
    public class ConsoleMenuBuilder
    {
        private List<MenuOption> _options = new List<MenuOption>();
        private bool _isLoop = false;
        private bool _shouldClearAfterSelection = false;
        private Action _afterClearAction = null;
        private readonly IUserInputReader _inputReader;
        private int _delaytime = 500; // 500ms

        public ConsoleMenuBuilder(IUserInputReader inputReader)
        {
            _inputReader = inputReader;
        }
        public ConsoleMenuBuilder setTimeDelay(int delay_ms)
        {
            _delaytime = delay_ms;
            return this;
        }

        public ConsoleMenuBuilder AddOption(string key,string info, Action action)
        {
            _options.Add(new MenuOption(key, info, action));
            return this;
        }

        public ConsoleMenuBuilder AsLoop()
        {
            _isLoop = true;
            return this;
        }

        public ConsoleMenuBuilder ClearAfterSelection(Action afterClearAction = null)
        {
            _shouldClearAfterSelection = true;
            _afterClearAction = afterClearAction;
            return this;
        }

        public void Build()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Please select an option:");

                foreach (var option in _options)
                {
                    Console.WriteLine($"[{option.Key}] - {option.Info}");
                }

                Console.WriteLine();
                string selection = _inputReader.ReadLine().Trim().ToLower();

                foreach (var option in _options)
                {
                    if (selection == option.Key.ToLower())
                    {
                        option.Action();
                        Thread.Sleep(_delaytime);
                        if (_shouldClearAfterSelection)
                        {
                            Console.Clear();
                            _afterClearAction?.Invoke();
                        }
                        break;
                    }
                }

                if (!_isLoop)
                {
                    break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            } while (true);
        }
    }

}