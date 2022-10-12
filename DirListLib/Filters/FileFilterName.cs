namespace DirListLib;

using System.Text.RegularExpressions;

public class FileFilterName : IFileFilter {

    private string[] FilterData { get; }
    public bool Exclusive { get; }
    public FileFilterName (string[] filterData) {
        Exclusive = false;
        FilterData = filterData;
    }
    public FileFilterName (string filterData) {
        Exclusive = false;
        FilterData = new string[] { filterData };
    }

    public bool Filter(IFileSystemEntry file) {
        return FilterData.Any(regex => Regex.Match(file.Name, regex).Success);
    }
}