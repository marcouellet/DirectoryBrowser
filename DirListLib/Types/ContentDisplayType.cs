namespace DirListLib;

public class ContentDisplayType : Enumeration {
    public static ContentDisplayType Text = new(1, nameof(Text));
    public static ContentDisplayType Json = new(2, nameof(Json));
    public static ContentDisplayType Xml = new(3, nameof(Xml));
    protected ContentDisplayType(int id, string name)
        : base(id, name)
    {
    }
}
