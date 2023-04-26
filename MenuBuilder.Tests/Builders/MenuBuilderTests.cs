using System.Reflection;

namespace MenuBuilder.Builders.MenuBuilder.Tests
{
    [TestFixture]
    public class MenuBuilderTests
    {
        [Test]
        public void AddOption_AddsOptionToList()
        {
            // Arrange
            var builder = new ConsoleMenuBuilder();
            var key = "1";
            var info = "Option 1";
            var action = new Action(() => Console.WriteLine("Option 1"));

            // Act
            builder.AddOption(key,info, action);

            // Assert
            var optionsField = typeof(ConsoleMenuBuilder).GetField("_options", BindingFlags.NonPublic | BindingFlags.Instance);
            var optionsList = (List<MenuOption>)optionsField.GetValue(builder);

            Assert.That(optionsList.Count, Is.EqualTo(1));
            Assert.That(optionsList[0].Key, Is.EqualTo(key));
            Assert.That(optionsList[0].Action, Is.EqualTo(action));
        }

        [Test]
        public void AsLoop_SetsLoopToTrue()
        {
            // Arrange
            var builder = new ConsoleMenuBuilder();
            // Act
            builder.AsLoop();

            // Assert
            var optionsField = typeof(ConsoleMenuBuilder).GetField("_isLoop", BindingFlags.NonPublic | BindingFlags.Instance);
            bool optionloop = (bool)optionsField.GetValue(builder);


            // Assert
            Assert.IsTrue(optionloop);
        }

        [Test]
        public void ClearAfterSelection_SetsShouldClearAfterSelectionToTrue()
        {
            // Arrange
            var builder = new ConsoleMenuBuilder();
            // Act
            builder.ClearAfterSelectionEnds();

            // Assert
            var optionsField = typeof(ConsoleMenuBuilder).GetField("_shouldClearAfterSelection", BindingFlags.NonPublic | BindingFlags.Instance);
            bool optionclear = (bool)optionsField.GetValue(builder);


            // Assert
            Assert.IsTrue(optionclear);
        }

    }
}
