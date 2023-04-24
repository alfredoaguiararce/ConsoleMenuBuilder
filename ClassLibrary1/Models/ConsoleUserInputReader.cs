using MenuBuilder.Interfaces;

namespace MenuBuilder.Models
{
    public class ConsoleUserInputReader : IUserInputReader
    {
        public string? ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
