using SQLite4Unity3d;

public class sqlCharacter
{

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public string characterName { get; set; }
    public int health { get; set; }
    public int spellPoints { get; set; }
    public string alignment { get; set; }
    public string boon { get; set; }

    public string fear { get; set; }

    public string weakness { get; set; }
    public string vice { get; set; }
    public string playerName { get; set; }
  
    public override string ToString()
    {
        return string.Format("{1} \n {4} \n {5} \n {6} \n {7} \n {8} \n {9}]",
            Id, characterName, health, spellPoints, alignment, boon, fear, weakness, vice, playerName);
    }
    
}
