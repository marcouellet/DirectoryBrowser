
namespace DirListLib;

public class FileSystemEntryType : Enumeration
{
    public static FileSystemEntryType File = new(1, nameof(File));
    public static FileSystemEntryType Directory = new(2, nameof(Directory));
    public static FileSystemEntryType Symlink = new(3, nameof(Symlink));

    protected FileSystemEntryType(int id, string name)
        : base(id, name)
    {
    }
}