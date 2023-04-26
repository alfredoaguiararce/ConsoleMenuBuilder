
// Class representing a single option in the menu
public class MenuTypeOption<T>
{
    public string Key { get; set; }
    public Func<T> Action { get; set; }

    public MenuTypeOption(string key, Func<T> action)
    {
        Key = key;
        Action = action;
    }
}
