namespace DirListLib;

using System.Text;
public class DirectoryDisplay: DisplayBase {

    public DirectoryDisplay(int indent = 4) : base (indent) {
        (FileDisplay, SymLinkDisplay) = (new FileDisplay(IndentValue), new SymLinkDisplay(IndentValue));
    }
    private FileDisplay FileDisplay { get; }
    private SymLinkDisplay SymLinkDisplay { get; }
    public string Display(IFileSystemEntry entry, int level, ContentDisplayType displayType)
    {
        var directory = (IDirectory) entry;
        var output = displayType switch {
                _ when displayType == ContentDisplayType.Text => DisplayText(directory, level),
                _ when displayType == ContentDisplayType.Json => DisplayJson(directory, level),
                _ when displayType == ContentDisplayType.Xml => DisplayXml(directory, level),
                _ => throw new Exception("Unknown display type")
        };

        return output!;
    }
    public string DisplayText(IDirectory directory, int level) {
        
        var builder = new StringBuilder();

        builder.AppendLine($"Directory Name: {directory.Name}");

        foreach (var entry in directory.Content) {

            var output = entry.Type switch {
            _ when entry.Type == FileSystemEntryType.Directory => DisplayText((IDirectory)entry, level+2),
            _ when entry.Type == FileSystemEntryType.File => FileDisplay.DisplayText(entry, level+2),
            _ when entry.Type == FileSystemEntryType.Symlink => SymLinkDisplay.DisplayText((ISymLink)entry, level+2),
            _ => throw new Exception("Unknown file type")
            };

            builder.Append(output);
        }

        return builder.ToString();
    }

    public string DisplayJson(IDirectory directory, int level) {
        
        var builder = new StringBuilder();

        builder.AppendLine(UtilsFns.Indent("{", IndentString, level));
        builder.AppendLine(Indent("\"type\" : \"directory\"", level+1));
        builder.AppendLine(Indent($"\"name\" : \"{directory.Name}\"", level+1));
        builder.AppendLine(Indent($"\"size\" : \"{directory.Size}\"", level+1));

        builder.AppendLine(Indent("\"content\" :", level+1));
        builder.AppendLine(Indent("{", level+1));

        foreach (var entry in directory.Content) {
                builder.Append(IndentString);

                var output = entry.Type switch {
                _ when entry.Type == FileSystemEntryType.Directory => DisplayJson((IDirectory)entry, level+1),
                _ when entry.Type == FileSystemEntryType.File => FileDisplay.DisplayJson(entry, level+1),
                _ when entry.Type == FileSystemEntryType.Symlink => SymLinkDisplay.DisplayJson((ISymLink)entry, level+1),
                _ => throw new Exception("Unknown file type")
                };

                builder.Append(output);
        }

        builder.AppendLine(Indent("}", level+1));
        builder.AppendLine(Indent("}", level));

        return builder.ToString();
    }

     public string DisplayXml(IDirectory directory, int level) {
        
        var builder = new StringBuilder();

        builder.AppendLine(Indent("<directory>", level));
        builder.AppendLine(Indent($"<name>{directory.Name}</name>", level+1));
        builder.AppendLine(Indent($"<size>{directory.Size}</size>", level+1));

        builder.AppendLine(Indent("<content>", level+1));

        foreach (var entry in directory.Content) {

                var output = entry.Type switch {
                _ when entry.Type == FileSystemEntryType.Directory => DisplayXml((IDirectory)entry, level+2),
                _ when entry.Type == FileSystemEntryType.File => FileDisplay.DisplayXml(entry, level+2),
                _ when entry.Type == FileSystemEntryType.Symlink => SymLinkDisplay.DisplayXml((ISymLink)entry, level+2),
                _ => throw new Exception("Unknown file type")
                };

                builder.Append(output);
        }

        builder.AppendLine(Indent("</content>", level+1));
        builder.AppendLine(Indent("</directory>", level));

        return builder.ToString();
    }
}