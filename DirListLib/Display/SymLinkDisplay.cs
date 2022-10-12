namespace DirListLib;

using System.Text;
public class SymLinkDisplay: DisplayBase {

    public SymLinkDisplay(int indent = 4) : base (indent) {}

    public string Display(IFileSystemEntry entry, int level, ContentDisplayType displayType)
    {
        var simlink = (ISymLink) entry;
        var output = displayType switch {
                _ when displayType == ContentDisplayType.Text => DisplayText(simlink, level),
                _ when displayType == ContentDisplayType.Json => DisplayJson(simlink, level),
                _ when displayType == ContentDisplayType.Xml => DisplayXml(simlink, level),
                _ => throw new Exception("Unknown display type")
        };

        return output!;
    }

    public string DisplayText(ISymLink symlink, int level) {
        return $"SymLink: {symlink.Name} Target: {symlink.Target}";
    } 

    public string DisplayJson(ISymLink symlink, int level) {
        var builder = new StringBuilder();

        builder.AppendLine(Indent("{", level));
        builder.AppendLine(Indent("\"type\" : \"symlink\"", level+1));
        builder.AppendLine(Indent($"\"name\" : \"{symlink.Name}\"", level+1));
        builder.AppendLine(Indent($"\"target\" : \"{symlink.Target}\"", level+1));
        builder.AppendLine(Indent("}", level));

        return builder.ToString();
    } 

    public string DisplayXml(ISymLink symlink, int level) {
        var builder = new StringBuilder();

        builder.AppendLine(Indent("<symlink>", level));
        builder.AppendLine(Indent($"<name>{symlink.Name}</name>", level+1));
        builder.AppendLine(Indent($"<size>{symlink.Size}</size>", level+1));
        builder.AppendLine(Indent($"<target>{symlink.Target}</target>", level+1));
        builder.AppendLine(Indent("</symlink>", level));

        return builder.ToString();
    } 
}