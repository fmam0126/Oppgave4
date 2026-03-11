using System.Security.Cryptography.X509Certificates;
using Spectre.Console;
namespace Oppgave4;

class Program
{
    public static string DigmimonCSVPath { get; set; } = "DigiDB_digimonlist.csv";
    static void Main(string[] args)
    {
        AnsiConsole.Clear();

        DigimonReader reader = new DigimonReader();

        List<DigimonModel> digimons = new List<DigimonModel>();
        digimons = reader.ReadCSV(DigmimonCSVPath);
        // foreach (var digimon in digimons)
        // {
        //     Console.WriteLine($"Index: {digimon.Index}, Name: {digimon.Name}, Stage: {digimon.Stage}, Type: {digimon.Type}, Attribute: {digimon.Attribute}, Memory: {digimon.Memory}, Equip Slots: {digimon.EquipSlots}, HP: {digimon.HP}, SP: {digimon.SP}, Attack: {digimon.Attack}, Defence: {digimon.Defence}, Intelligence: {digimon.Intelligence}, Speed: {digimon.Speed}");
        // }

        /// Sort by Attack
        // Ui.ShowSortedByAttack(digimons);

        /// select all digimons with Higher Attack than 200
        // Console.WriteLine("\nDigimons with Attack higher than 200:");
        // digimons.Where(digimon => digimon.Attack > 200)
        //                                 .ToList()
        //                                 .ForEach(digimon => Console.WriteLine($"Name: {digimon.Name}, Attack: {digimon.Attack}"));


        // digimons.Select(digimon => new { digimon.Name, digimon.Stage, digimon.Type, digimon.Attribute })
        //                                 .ToList()
        //                                 .ForEach(digimon => Console.WriteLine($"Name: {digimon.Name}, Stage: {digimon.Stage}, Type: {digimon.Type}, Attribute: {digimon.Attribute}"));

        // Ui.ShowDigimonsWithStatHigherThanThreshold(digimons, 1000, DigimonModel.StatType.HP);
        while (true)
        {
            var selectedOption = Ui.ShowMenu();
            switch (selectedOption)
            {
                case "show_all_digimons":
                    Ui.ShowDigimons(digimons);
                    break;
                case "show_sorted_by_Certain_Stat":
                    Ui.ChooseStatSorting(digimons);
                    break;
                case "show_stat_higher_than_threshold":
                    Ui.ChooseStatTypeAndThreshold(digimons);
                    break;
                case "exit":
                    AnsiConsole.MarkupLine("[bold red]Exiting the program. Goodbye![/]");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
                case "show_single_property_of_all_digimons":
                    Ui.ChooseSinglePropertyOfAllDigimons(digimons);
                    break;
                default:
                    AnsiConsole.MarkupLine("[bold red]Invalid option selected. Please try again.[/]");
                    break;
            }
        }
    }
}
