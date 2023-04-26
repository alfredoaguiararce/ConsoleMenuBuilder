# **MenuConsoleBuilder**

**`MenuConsoleBuilder`** is a .NET 6 library for building console-based menus with customizable options and actions. It provides a simple API for creating console menus with options that the user can select by typing a key. The library includes features such as prompting the user for input, clearing the console after an option has been selected, and displaying all the available options.

## **Installation**

**`MenuConsoleBuilder`** can be installed via NuGet Package Manager:

```bash
Install-Package MenuConsoleBuilder
```

## **Usage**

To use **`MenuConsoleBuilder`**, you first need to create a **`ConsoleMenuReadBuilder`** object for each value you want to read from the user. This object defines the options that the user can select and the actions that are performed when an option is selected. Once you have read all the values you need, you can create a **`ConsoleMenuBuilder`** object to create a menu with options that execute different actions based on the values that were previously read.

### **Examples**

1. Simple value picker

```csharp
// Create a menu to pick a value between 1 and 3
var valuePicker = new ConsoleMenuReadBuilder<int>()
    .AddOption("1", () => 1)
    .AddOption("2", () => 2)
    .AddOption("3", () => 3)
    .SetPrompt("Please enter a number between 1 and 3: ");

// Read the user's input and store the result
int value = valuePicker.ReadInput();

// Do something with the value (e.g. print it to the console)
Console.WriteLine($"You picked {value}.");

```

- Basic menu with options

```csharp
// Create a menu with three options
new ConsoleMenuBuilder()
    .AddOption("1", "Say hello", () => Console.WriteLine("Hello!"))
    .AddOption("2", "Say goodbye", () => Console.WriteLine("Goodbye!"))
    .AddOption("3", "Do nothing", () => {})
    .SetFirstPrompt("What would you like to do?")
    .Build();
```

- Looping menu

```csharp
// Create a menu with a looping prompt
new ConsoleMenuBuilder()
    .AddOption("1", "Say hello", () => Console.WriteLine("Hello!"))
    .AddOption("2", "Say goodbye", () => Console.WriteLine("Goodbye!"))
    .SetFirstPrompt("What would you like to do?")
    .AsLoop()
    .Build();
```

- Yes/No menu

```csharp
// Create a yes/no menu
new ConsoleMenuBuilder()
    .SetFirstPrompt("Would you like to continue?")
    .CreateSimpleYesNoMenu(
        () => Console.WriteLine("You picked 'yes'."),
        () => Console.WriteLine("You picked 'no'.")
    )
    .Build();

```

## **ConsoleMenuBuilder methods**

| Method | Description |
| --- | --- |
| AsLoop() | Sets the menu to loop. When this method is called, the menu will continue to display after an option has been selected until the user decides to exit. |
| SetPrompt(string prompt) | Sets the prompt that is displayed to the user before the list of options. |
| ClearAfterSelection(Action? action) | Sets an action to be executed after an option has been selected. The action will be executed before the menu clears the console (if enabled). The action parameter is an optional delegate that takes no parameters and returns no value. |
| ShowAllOptions(bool isShowMwnu) | Sets whether to display all the available options to the user or not. By default, only the key of the selected option is displayed to the user. The isShowMenu parameter determines whether to show all the options or not. |
| setClearInEveryLoop() | Enables clearing the console after every loop iteration. |
| ClearAfterSelectionEnds(Action? action) | Sets an action to be executed after the user exits the menu. The action will be executed before the console clears (if enabled). The action parameter is an optional delegate that takes no parameters and returns no value. |
| SetFirstPrompt(string prompt) | Sets the first prompt that is displayed to the user before the list of options. |
| AddOption(string key, string description, Action action) | Adds a new option to the menu. The key parameter is the key the user must enter to select this option, the description parameter is the text that describes the option, and the action parameter is a delegate that is executed when the option is selected. The delegate takes no parameters and returns no value. |
| CreateSimpleYesNoMenu(Action yesAction, Action noAction) | Creates a simple Yes/No menu. The yesAction parameter is a delegate that is executed when the user selects Yes, and the noAction parameter is a delegate that is executed when the user selects No. The delegates take no parameters and return no value. |
| SetIncorrectOptionSelectedMessage(string message) | Sets the message to be displayed when an invalid option is selected. |
| setClearInEveryLoop(bool clear) | Sets whether the console should be cleared before displaying the menu options in every loop. |
| AsLoop() | Sets the menu to loop until a valid option is selected. |
| ClearAfterSelectionEnds(Action? action) | Sets the action to be performed after a valid option is selected and the menu exits. |
| Build() | Builds and displays the menu. |

## **ConsoleMenuReadBuilder<T> methods**

| Method | Description |
| --- | --- |
| AddOption(string key, Action action) | Adds a new menu option with the specified key and action. |
| AsLoop() | Sets the menu to loop until a valid option is selected. |
| SetPrompt(string prompt) | Sets the prompt that will be displayed before the menu options. |
| ClearAfterSelection(Action? action) | Sets the action to be performed after a valid option is selected and the console is cleared. |
| ShowAllOptions(bool isShowMwnu) | Sets whether to display all the menu options when prompting the user. |
| ReadInput() | Reads the user input and returns the selected option. |