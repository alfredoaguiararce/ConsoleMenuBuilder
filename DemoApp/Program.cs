
// See https://aka.ms/new-console-template for more information
using MenuBuilder.Builders.MenuBuilder;


Console.WriteLine("Hello, World!");

/* This code is creating a console menu builder that prompts the user to enter a number for variable
'a' between 1 and 3. It creates a menu with three options (1, 2, and 3) and sets it to loop until a
valid input is received. It also sets the prompt message and hides the options after the user makes
a selection. Finally, it clears the console screen after the user makes a selection. */
var firstvaluepicker = new ConsoleMenuReadBuilder<int>()
           .AddOption("1", () => 1)
           .AddOption("2", () => 2)
           .AddOption("3", () => 3)
           .AsLoop()
           .ShowAllOptions(false)
           .ClearAfterSelection(null)
           .SetPrompt("Please enter a number for 'a' [1 - 3]: ");

/* This code is creating a console menu builder that prompts the user to enter a number for variable
'b' between 1 and 3. It creates a menu with three options (1, 2, and 3) and sets it to loop until a
valid input is received. It also sets the prompt message and clears the console screen after the
user makes a selection. Additionally, it prints the message "This is printed after clear screen."
after the screen is cleared. */
var secondvaluepicker = new ConsoleMenuReadBuilder<int>()
           .AddOption("1", () => 1)
           .AddOption("2", () => 2)
           .AddOption("3", () => 3)
           .AsLoop()
           .ClearAfterSelection(() => Console.WriteLine("This is printed after clear screen."))
           .SetPrompt("Please enter a number for 'b': ");


/* These lines of code are reading user input from two separate console menus created using the
ConsoleMenuReadBuilder class. The first menu prompts the user to enter a number for variable 'a'
between 1 and 3, and the second menu prompts the user to enter a number for variable 'b' between 1
and 3. The ReadInput() method is used to read the user's selection from each menu and assign it to
the corresponding variable 'a' and 'b'. */
int a = firstvaluepicker.ReadInput();
int b = secondvaluepicker.ReadInput();

Thread.Sleep(1000);

/* This code is creating a console menu builder that displays a menu with three options for performing
arithmetic operations on two variables 'a' and 'b'. The options are addition, subtraction, and
multiplication. The user's selection is used to perform the corresponding operation and print the
result to the console. The menu is set to loop until a valid input is received, and the console
screen is cleared after each loop iteration. Additionally, a message is printed to the console after
the user has made a selection, prompting them to press any key to continue. */
new ConsoleMenuBuilder()
    .SetFirstPrompt("Select an option :")
    .AddOption("1", "Addition", () => Console.WriteLine($"{a} + {b} = {a + b}"))
    .AddOption("2", "Subtraction", () => Console.WriteLine($"{a} - {b} = {a - b}"))
    .AddOption("3", "Multiplication", () => Console.WriteLine($"{a} x {b} = {a * b}"))
    .AsLoop()
    .setClearInEveryLoop()
    .ClearAfterSelectionEnds(() => 
    { 
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();                  
     })
    .Build();


Thread.Sleep(1000);

/* This code is creating a console menu builder that displays a simple yes/no menu with two options:
"Option yes" and "Option no". The user is prompted to select either 'y' or 'n' and the corresponding
action is executed based on their selection. The menu is set to loop until a valid input is
received, and an error message is displayed if the user enters an invalid option. The menu is then
built and executed. */
new ConsoleMenuBuilder()
    .SetFirstPrompt("Select (y/n)")
    .CreateSimpleYesNoMenu(() => Console.WriteLine("Option yes"),
                           () => Console.WriteLine("Option no")
                            )
    .SetIncorrectOptionSelectedMessage("Please select 'y' or 'n'")
    .AsLoop()
    .Build();
