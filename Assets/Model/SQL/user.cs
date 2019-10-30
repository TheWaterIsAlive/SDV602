using SQLite4Unity3d;

public class user
{

    [PrimaryKey]
   
    public string Username { get; set; }
    public string Password { get; set; }


    public override string ToString()
    {
        return string.Format("[User: Username={0},  Password={1}]", Username, Password);
    }
}
