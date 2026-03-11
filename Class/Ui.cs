using Oppgave4;
using Spectre.Console;

public static class Ui
{
    public static void ParseWarning(string input)
    {
        AnsiConsole.MarkupLine($"[bold red]Warning:[/] Unable to parse '{input}' as an integer. Please Check the CSV file.");
    }
    /// <summary>
    /// Displays a menu to the user and prompts them to select an option using Spectre.Console's SelectionPrompt. Returns a string representing the selected option.
    /// </summary>
    /// <returns>The selected option as a string</returns>
    public static string ShowMenu()
    {
        AnsiConsole.MarkupLine("[bold cyan]Welcome to the Digimon Database![/]");
        // AnsiConsole.MarkupLine("Please select an option:");
        // AnsiConsole.MarkupLine("[green]1.[/] Show all Digimons");
        // AnsiConsole.MarkupLine("[green]2.[/] Show Digimons sorted by Attack");
        // AnsiConsole.MarkupLine("[green]3.[/] Show Digimons with a specific stat higher than a threshold");
        // AnsiConsole.MarkupLine("[green]4.[/] Exit");

        var userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please select an option:")
                .AddChoices(new[] { "[green]1.[/] Show all Digimons", "[green]2.[/] Show Digimons sorted by a chosen stat", "[green]3.[/] Show Digimons with a specific stat higher than a threshold", "[green]4.[/] Exit" })
        );

        switch (userInput)
        {
            case "[green]1.[/] Show all Digimons":
                return "show_all_digimons";
            case "[green]2.[/] Show Digimons sorted by a chosen stat":
                return "show_sorted_by_Certain_Stat";
            case "[green]3.[/] Show Digimons with a specific stat higher than a threshold":
                return "show_stat_higher_than_threshold";
            case "[green]4.[/] Exit":
                return "exit";
            default:
                return string.Empty;
        }
    }
    /// <summary>
    /// Displays a table of all digimons with their attributes and stats, using Spectre.Console for formatting.
    /// </summary>
    /// <param name="digimons">List of digimons to display</param>
    public static void ShowDigimons(List<DigimonModel> digimons)
    {
        var table = new Table();
        table.AddColumn("Name");
        table.AddColumn("Stage");
        table.AddColumn("Type");
        table.AddColumn("Attribute");
        table.AddColumn("Memory");
        table.AddColumn("Equip Slots");
        table.AddColumn("HP");
        table.AddColumn("SP");
        table.AddColumn("Attack");
        table.AddColumn("Defence");
        table.AddColumn("Intelligence");
        table.AddColumn("Speed");

        foreach (var digimon in digimons)
        {
            table.AddRow(
                $"[green]{digimon.Name}[/]",
                $"[yellow]{digimon.Stage}[/]",
                $"[blue]{digimon.Type}[/]",
                $"[magenta]{digimon.Attribute}[/]",
                $"[cyan]{digimon.Memory}[/]",
                $"[LightSalmon1]{digimon.EquipSlots}[/]",
                $"[red]{digimon.HP}[/]",
                $"[yellow]{digimon.SP}[/]",
                $"[red]{digimon.Attack}[/]",
                $"[magenta]{digimon.Defence}[/]",
                $"[cyan]{digimon.Intelligence}[/]",
                $"[blue]{digimon.Speed}[/]"
            );
        }
        table.Columns[0].Footer("name");
        table.Columns[1].Footer("stage");
        table.Columns[2].Footer("type");
        table.Columns[3].Footer("attribute");
        table.Columns[4].Footer("memory");
        table.Columns[5].Footer("equip slots");
        table.Columns[6].Footer("hp");
        table.Columns[7].Footer("sp");
        table.Columns[8].Footer("attack");
        table.Columns[9].Footer("defence");
        table.Columns[10].Footer("intelligence");
        table.Columns[11].Footer("speed");
        AnsiConsole.Write(table);
    }

    public static void ChooseStatSorting(List<DigimonModel> digimons)
    {
        var statType = AnsiConsole.Prompt(
            new SelectionPrompt<DigimonModel.StatType>()
                .Title("Select a stat type to sort by:")
                .AddChoices(Enum.GetValues<DigimonModel.StatType>())
        );

        ShowSortedByChosenStat(digimons, statType);
    }

    /// <summary>
    /// Shows digimons sorted by a chosen stat in ascending order.
    /// </summary>
    /// <param name="digimons">The list of digimons to sort</param>
    /// <param name="statType">The stat type to sort by</param>
    public static void ShowSortedByChosenStat(List<DigimonModel> digimons, DigimonModel.StatType statType)
    {
        AnsiConsole.MarkupLine($"\nDigimons sorted by {statType}:");
        var filteredDigimons = digimons.OrderBy(digimon => statType switch
        {
            DigimonModel.StatType.HP => digimon.HP,
            DigimonModel.StatType.SP => digimon.SP,
            DigimonModel.StatType.Attack => digimon.Attack,
            DigimonModel.StatType.Defence => digimon.Defence,
            DigimonModel.StatType.Intelligence => digimon.Intelligence,
            DigimonModel.StatType.Speed => digimon.Speed,
            _ => 0
        })
        .ToList();
        var table = new Table();
        table.AddColumn("Name");
        table.AddColumn($"{statType}");
        foreach (var digimon in filteredDigimons)
        {
            int value = statType switch
            {
                DigimonModel.StatType.HP => digimon.HP,
                DigimonModel.StatType.SP => digimon.SP,
                DigimonModel.StatType.Attack => digimon.Attack,
                DigimonModel.StatType.Defence => digimon.Defence,
                DigimonModel.StatType.Intelligence => digimon.Intelligence,
                DigimonModel.StatType.Speed => digimon.Speed,
                _ => 0
            };
            table.AddRow($"[green]{digimon.Name}[/]", $"[red]{value}[/]");
        }
        table.Columns[0].Footer("name");
        table.Columns[1].Footer($"{statType}");
        AnsiConsole.Write(table);
    }

    /// <summary>
    /// Prompts the user to select a stat type and enter a threshold value, then uses ShowDigimonsWithStatHigherThanThreshold method to display digimons what that stat and sorts them in ascending order.
    /// </summary>
    public static void ChooseStatTypeAndThreshold(List<DigimonModel> digimons)
    {
        var statType = AnsiConsole.Prompt(
            new SelectionPrompt<DigimonModel.StatType>()
                .Title("Select a stat type:")
                .AddChoices(Enum.GetValues<DigimonModel.StatType>())
        );

        var threshold = AnsiConsole.Ask<int>("Enter the threshold value:");

        ShowDigimonsWithStatHigherThanThreshold(digimons, threshold, statType);
    }
    /// <summary>
    /// Shows digimons with a specific stat higher than a threshold, and sorts them by that stat in ascending order.
    /// </summary>
    /// <param name="digimons">Digimons List to Filter and Display</param>
    /// <param name="threshold">The minimum value for the selected stat</param>
    /// <param name="statType">The stat type to filter and sort by</param>
    public static void ShowDigimonsWithStatHigherThanThreshold(List<DigimonModel> digimons, int threshold, DigimonModel.StatType statType)
    {
        AnsiConsole.MarkupLine($"\nDigimons with {statType} higher than {threshold}:");

        var filteredDigimons = digimons.Where(digimon => statType switch
        {
            DigimonModel.StatType.HP => digimon.HP > threshold,
            DigimonModel.StatType.SP => digimon.SP > threshold,
            DigimonModel.StatType.Attack => digimon.Attack > threshold,
            DigimonModel.StatType.Defence => digimon.Defence > threshold,
            DigimonModel.StatType.Intelligence => digimon.Intelligence > threshold,
            DigimonModel.StatType.Speed => digimon.Speed > threshold,
            _ => false
        })
        .OrderBy(digimon => statType switch
        {
            DigimonModel.StatType.HP => digimon.HP,
            DigimonModel.StatType.SP => digimon.SP,
            DigimonModel.StatType.Attack => digimon.Attack,
            DigimonModel.StatType.Defence => digimon.Defence,
            DigimonModel.StatType.Intelligence => digimon.Intelligence,
            DigimonModel.StatType.Speed => digimon.Speed,
            _ => 0
        })
        .ToList();
        if (filteredDigimons.Count == 0)
        {
            AnsiConsole.MarkupLine("[bold red]No Digimons found with the specified criteria.[/]");
            return;
        }

        var table = new Table();
        table.AddColumn("Name");
        table.AddColumn($"{statType}");

        foreach (var digimon in filteredDigimons)
        {

            int value = statType switch
            {
                DigimonModel.StatType.HP => digimon.HP,
                DigimonModel.StatType.SP => digimon.SP,
                DigimonModel.StatType.Attack => digimon.Attack,
                DigimonModel.StatType.Defence => digimon.Defence,
                DigimonModel.StatType.Intelligence => digimon.Intelligence,
                DigimonModel.StatType.Speed => digimon.Speed,
                _ => 0
            };

            table.AddRow($"[green]{digimon.Name}[/]", $"[red]{value}[/]");

        }
        table.Columns[0].Footer("name");
        table.Columns[1].Footer($"{statType}");
        AnsiConsole.Write(table);
        // digimons.Where(digimon => digimon.Attack > threshold)
        //                                 .ToList()
        //                                 .ForEach(digimon => AnsiConsole.MarkupLine($"Name: [green]{digimon.Name}[/], {statType}: [red]{value}[/]"));
    }
}