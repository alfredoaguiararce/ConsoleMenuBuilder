public class MenuOption
{
    public string Key { get; }
    public string? Info { get; }
    public Action Action { get; }

    public MenuOption(string key,string? info, Action action)
    {
        Key = key;
        Info = info;
        Action = action;
    }
}