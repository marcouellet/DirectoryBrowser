namespace DirListLib;

using System.Text;
public class FileDisplay: DisplayBase {

    public FileDisplay(int indent = 4) : base (indent) {}
    public string Display(IFileSystemEntry entry, int level, ContentDisplayType displayType)
    {
        var output = displayType switch {
                _ when displayType == ContentDisplayType.Text => DisplayText(entry, level),
                _ when displayType == ContentDisplayType.Json => DisplayJson(entry, level),
                _ when displayType == ContentDisplayType.Xml => DisplayXml(entry, level),
                _ => throw new Exception("Unknown display type")
        };

        return output!;
    }

    public string DisplayText(IFileSystemEntry entry, int level) {
            return $"File: {entry.Name} Size: {entry.Size}";
    } 

    public string DisplayJson(IFileSystemEntry entry, int level) {
        var builder = new StringBuilder();

        builder.AppendLine(Indent("{", level));
        builder.AppendLine(Indent("\"type\" : \"file\"", level+1));
        builder.AppendLine(Indent($"\"name\" : \"{entry.Name}\"", level+1));
        builder.AppendLine(Indent($"\"size\" : \"{entry.Size}\"", level+1));
        builder.AppendLine(Indent("}", level));

        return builder.ToString();
    }

    public string DisplayXml(IFileSystemEntry entry, int level) {
        var builder = new StringBuilder();

        builder.AppendLine(Indent("<file>", level));
        builder.AppendLine(Indent($"<name>{entry.Name}</name>", level+1));
        builder.AppendLine(Indent($"<size>{entry.Size}</size>", level+1));
        builder.AppendLine(Indent("</file>", level));

        return builder.ToString();
    } 
}