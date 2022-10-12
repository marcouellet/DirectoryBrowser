namespace WinDirListLib;

using DirListLib;

public class WinFileFilterExtension : IFileFilter {

    private string[] FilterData { get; }
    public bool Exclusive { get; }
    public WinFileFilterExtension (string[] filterData) {
        Exclusive = false;
        FilterData = filterData;
    }
    public WinFileFilterExtension (string filterData) {
        Exclusive = false;
        FilterData = new string[] { filterData };
    }
    public bool Filter(IFileSystemEntry file) {

        if (file is IWinFile winFile) {
            return FilterData.Any(value => winFile.FileNameExtension == value);
        }
        return false;
    }
}