namespace Oppgave4;

class Program
{
    static void Main(string[] args)
    {
        DigimonReader reader = new DigimonReader();

        List<DigimonModel> digimons = new List<DigimonModel>();
        digimons = reader.ReadCSV("DigiDB_digimonlist.csv");
        foreach (var digimon in digimons)
        {
            Console.WriteLine($"Index: {digimon.Index}, Name: {digimon.Name}, Stage: {digimon.Stage}, Type: {digimon.Type}, Attribute: {digimon.Attribute}, Memory: {digimon.Memory}, Equip Slots: {digimon.EquipSlots}, HP: {digimon.HP}, SP: {digimon.SP}, Attack: {digimon.Attack}, Defence: {digimon.Defence}, Intelligence: {digimon.Intelligence}, Speed: {digimon.Speed}");
        }

        /// Sort by Attack
        Console.WriteLine("\nDigimons sorted by Attack:");
        digimons.OrderBy(d => d.Attack).ToList().ForEach(d => Console.WriteLine($"Name: {d.Name}, Attack: {d.Attack}"));

        
    }
}
