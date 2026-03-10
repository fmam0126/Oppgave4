public class DigimonModel
{
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