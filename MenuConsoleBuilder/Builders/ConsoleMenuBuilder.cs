namespace MenuBuilder.Builders.MenuBuilder
{
    public class ConsoleMenuBuilder
    {
        private List<MenuOption> mOptions = new List<MenuOption>();
        private bool mIsLoop = false;
        private bool mIsClearInLoop = false;
        private bool mClearAfterSelection = false;
        private Action mAfterClearAction = null;
        private string mMenuPrompt = "Please select an option:";
        private string mWrongOptionPrompt = "Please select a correct option";
        private int mDelayTime = 500; // 500ms
        private bool mWriteAllOptions = true;
        public ConsoleMenuBuilder() { }
        public ConsoleMenuBuilder setClearInEveryLoop()
        {
            mIsClearInLoop = true;
            return this;
        }
        public ConsoleMenuBuilder setNotPrintAllOptions()
        {
            mWriteAllOptions = false;
            return this;
        }

        public ConsoleMenuBuilder setTimeDelay(int delay_ms)
        {
            mDelayTime = delay_ms;
            return this;
        }

        public ConsoleMenuBuilder AddOption(string key,string info, Action action)
        {
            mOptions.Add(new MenuOption(key, info, action));
            return this;
        }

        public ConsoleMenuBuilder AsLoop()
        {
            mIsLoop = true;
            return this;
        }

        public ConsoleMenuBuilder ClearAfterSelectionEnds(Action afterClearAction = null)
        {
            mClearAfterSelection = true;
            mAfterClearAction = afterClearAction;
            return this;
        }

        public ConsoleMenuBuilder SetFirstPrompt(string PromptMenu)
        {
            this.mMenuPrompt = PromptMenu;
            return this;
        }
        public ConsoleMenuBuilder SetIncorrectOptionSelectedMessage(string Prompt)
        {
            this.mWrongOptionPrompt = Prompt;
            return this;
        }

        public ConsoleMenuBuilder CreateSimpleYesNoMenu(Action YesAction, Action NoAction)
        {
            
            mOptions.Add(new MenuOption("y", null, YesAction));
            mOptions.Add(new MenuOption("n", null, NoAction));
            mWriteAllOptions = false;
            return this;
        }

        public void Build()
        {
            bool executed = false;
            do
            {
                Console.WriteLine(mMenuPrompt);

                PrintOptionsMenu(this.mWriteAllOptions);

                Console.WriteLine();
                string? selection = Console.ReadLine()?.Trim().ToLower();

                foreach (var option in mOptions)
                {
                    if (selection == option.Key.ToLower())
                    {
                        option.Action();

                        Thread.Sleep(mDelayTime);

                        if (mClearAfterSelection)
                        {
                            Console.Clear();
                            mAfterClearAction?.Invoke();
                        }

                        executed = true;
                        break;
                    }
                }

                if(!mOptions.Any(x => x.Key == selection))
                {
                    Console.WriteLine(this.mWrongOptionPrompt);
                    Thread.Sleep(mDelayTime);
                }


                if (!mIsLoop)
                {
                    break;
                }

                if (mIsClearInLoop)
                {
                    Console.Clear();
                }

            } while (!executed);
        }

        private void PrintOptionsMenu(bool isMenuOptionsVisible)
        {
            if (isMenuOptionsVisible)
            {
                foreach (var option in mOptions)
                {
                    Console.WriteLine($"[{option.Key}] - {option.Info}");
                }
            }
        }
    }

}