namespace DirListLib;

public class FileFilterType : Enumeration
{
    public static FileFilterType FileName = new(1, nameof(FileName));
    public static FileFilterType FileSize = new(2, nameof(FileSize));
    public static FileFilterType Symlink = new(3, nameof(Symlink));

    protected FileFilterType(int id, string name)
        : base(id, name)
    {
    }
}