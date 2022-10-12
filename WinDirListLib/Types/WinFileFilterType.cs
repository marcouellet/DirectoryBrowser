namespace WinDirListLib;

using DirListLib;

public class WinFileFilterType: FileFilterType {
    public static WinFileFilterType FileExtension = new(4, nameof(FileExtension));
    private WinFileFilterType(int id, string name)
        : base(id, name)
    {
    }
}