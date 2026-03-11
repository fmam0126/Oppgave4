public class DigimonReader
{
    /// <summary>
    /// Reads a CSV file containing digimon data and returns a list of DigimonModel objects representing each digimon in the file. 
    /// </summary>
    /// <param name="inputPath">The path to the CSV file</param>
    /// <returns>A list of DigimonModel objects</returns>
    public List<DigimonModel> ReadCSV(string inputPath)
    {
        // using (var reader = new StreamReader(inputPath))
        // {
        //     string headerLine = reader.ReadLine();
            
        //     while (!reader.EndOfStream)
        //     {
        //         var line = reader.ReadLine();
        //         var values = line.Split(',');

        //         int index = int.Parse(values[0]);
        //         string name = values[1];
        //         string stage = values[2];
        //         string type = values[3];
        //         string attribute = values[4];
        //         int memory = int.Parse(values[5]);
        //         int equipSlots = int.Parse(values[6]);
        //         int hp = int.Parse(values[7]);
        //         int sp = int.Parse(values[8]);
        //         int attack = int.Parse(values[9]);
        //         int defence = int.Parse(values[10]);
        //         int intelligence = int.Parse(values[11]);
        //         int speed = int.Parse(values[12]);
                
                
        //     }
        //     return (index, name, stage, type, attribute, memory, equipSlots, hp, sp, attack, defence, intelligence, speed);
        // }
        var digimonList = File.ReadAllLines(inputPath)
            .Skip(1)
            .Select(line => line.Split(','))
            .Select(values => new DigimonModel(
                index: int.Parse(values[0]),
                name: values[1],
                stage: values[2],
                type: values[3],
                attribute: values[4],
                memory: int.Parse(values[5]),
                equipSlots: int.Parse(values[6]),
                hp: int.Parse(values[7]),
                sp: int.Parse(values[8]),
                attack: int.Parse(values[9]),
                defence: int.Parse(values[10]),
                intelligence: int.Parse(values[11]),
                speed: int.Parse(values[12])
            ))
            .ToList();
        return digimonList;
    }
}