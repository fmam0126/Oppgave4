public class DigimonModel
{
    public enum Properties
    {
        Index,
        Name,
        Stage,
        Type,
        Attribute,
        Memory,
        EquipSlots,
        HP,
        SP,
        Attack,
        Defence,
        Intelligence,
        Speed
    }
    public enum StatType
    {
        HP,
        SP,
        Attack,
        Defence,
        Intelligence,
        Speed
    }
    public int Index { get; }
    public string Name { get; }
    public string Stage { get; }
    public string Type { get; }
    public string Attribute { get; }
    public int Memory { get; }
    public int EquipSlots { get; }
    public int HP { get; }
    public int SP { get; }
    public int Attack { get; }
    public int Defence { get; }
    public int Intelligence { get; }
    public int Speed { get; }
/// <summary>
/// Constructor for the DigimonModel class, which initializes all properties of a digimon based on the provided parameters.
/// </summary>
/// <param name="index">The index of the digimon</param>
/// <param name="name">The name of the digimon</param>
/// <param name="stage">The stage of the digimon</param>
/// <param name="type">The type of the digimon</param>
/// <param name="attribute">The attribute of the digimon</param>
/// <param name="memory">The memory of the digimon</param>
/// <param name="equipSlots">The number of equipment slots the digimon has</param>
/// <param name="hp">The hit points of the digimon</param>
/// <param name="sp">The skill points of the digimon</param>
/// <param name="attack">The attack stat of the digimon</param>
/// <param name="defence">The defence stat of the digimon</param>
/// <param name="intelligence">The intelligence stat of the digimon</param>
/// <param name="speed">The speed stat of the digimon</param>
    public DigimonModel(int index, string name, string stage, string type, string attribute, int memory, int equipSlots, int hp, int sp, int attack, int defence, int intelligence, int speed)
    {
        Index = index;
        Name = name;
        Stage = stage;
        Type = type;
        Attribute = attribute;
        Memory = memory;
        EquipSlots = equipSlots;
        HP = hp;
        SP = sp;
        Attack = attack;
        Defence = defence;
        Intelligence = intelligence;
        Speed = speed;
    }
}