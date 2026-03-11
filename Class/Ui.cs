using Spectre.Console;

public static class Ui
{
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
                $"[red]{digimon.EquipSlots}[/]",
                $"[green]{digimon.HP}[/]",
                $"[yellow]{digimon.SP}[/]",
                $"[blue]{digimon.Attack}[/]",
                $"[magenta]{digimon.Defence}[/]",
                $"[cyan]{digimon.Intelligence}[/]",
                $"[red]{digimon.Speed}[/]"
            );
        }
        AnsiConsole.Write(table);
    }

    public static void ChooseStatSorting()
    {
        var statType = AnsiConsole.Prompt(
            new SelectionPrompt<DigimonModel.StatType>()
                .Title("Select a stat type to sort by:")
                .AddChoices(Enum.GetValues<DigimonModel.StatType>())
        );

        ShowSortedByChosenStat(new DigimonReader().ReadCSV("DigiDB_digimonlist.csv"), statType);
    }
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
        AnsiConsole.Write(table);
    }


    public static void ChooseStatTypeAndThreshold()
    {
        var statType = AnsiConsole.Prompt(
            new SelectionPrompt<DigimonModel.StatType>()
                .Title("Select a stat type:")
                .AddChoices(Enum.GetValues<DigimonModel.StatType>())
        );

        var threshold = AnsiConsole.Ask<int>("Enter the threshold value:");

        ShowDigimonsWithStatHigherThanThreshold(new DigimonReader().ReadCSV("DigiDB_digimonlist.csv"), threshold, statType);
    }
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
        AnsiConsole.Write(table);
        // digimons.Where(digimon => digimon.Attack > threshold)
        //                                 .ToList()
        //                                 .ForEach(digimon => AnsiConsole.MarkupLine($"Name: [green]{digimon.Name}[/], {statType}: [red]{value}[/]"));
    }
}