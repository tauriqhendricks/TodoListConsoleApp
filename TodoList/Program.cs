Console.WriteLine("Hello!");

string? userChoice;
var todoList = new List<string>();

do
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    userChoice = Console.ReadLine();

    switch (userChoice!.ToLower())
    {
        case "s":
            PrintSelectedOption("See all TODOs");
            HandleSOption(todoList);
            break;

        case "a":
            PrintSelectedOption("Add a TODO");
            HandleAOption(todoList);
            break;

        case "r":
            PrintSelectedOption("Remove a TODO");
            HandleROption(todoList);
            break;

        case "e":
            PrintSelectedOption("Exit");
            break;

        default:
            Console.WriteLine("Invalid input");
            Console.WriteLine();
            break;
    }
} while (userChoice.ToLower() != "e");

Console.ReadKey();


static void HandleSOption(List<string> todoList)
{
    if (todoList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
    }
    else
    {
        var counter = 1;
        foreach (var item in todoList)
        {
            Console.WriteLine($"{counter}. {item}");
            counter++;
        }
    }
}

static void HandleAOption(List<string> todoList)
{
    string? description;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        description = Console.ReadLine();

        if (string.IsNullOrEmpty(description))
        {
            Console.WriteLine("The description cannot be empty.");
            continue;
        }

        if (todoList.Contains(description))
        {
            description = "";
            Console.WriteLine("The description must be unique.");
            continue;
        }

        todoList.Add(description!);
        Console.WriteLine($"TODO successfully added: {description}");
    } while (string.IsNullOrEmpty(description));
}

static void HandleROption(List<string> todoList)
{
    bool success;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove:");
        HandleSOption(todoList);

        if (todoList.Count == 0)
        {
            return;
        }

        success = int.TryParse(Console.ReadLine()!, out int index);
        if (success)
        {
            if (index < 1 || index > todoList.Count)
            {
                Console.WriteLine("Invalid index.");
                success = false;
                continue;
            }

            Console.WriteLine("TODO removed:" + todoList[index - 1]);
            todoList.RemoveAt(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    } while (!success);
}

static void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}

