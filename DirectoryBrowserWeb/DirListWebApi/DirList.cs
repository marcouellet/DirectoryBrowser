namespace DirListWebApi;

using DirListLib;
using WinDirListLib;

public static class DirList {
    public static string GetDisplayData (string dirPath, DisplayMode? displayMode, DirListLib.SortType? sortType, 
                                DirListLib.SortOrder? sortOrder) {

        var fileInfo = new System.IO.FileInfo(dirPath);
        var content =new WinContentProvider(dirPath, sortType, sortOrder!).GetContent();

        var directory = new DirListLib.Directory(
                fileInfo.Name, 
                System.IO.Directory.GetCurrentDirectory(), 
                content);

        switch (displayMode) {
            case DisplayMode.Text:
                return ContentDisplay.Display(directory, ContentDisplayType.Text);
            case DisplayMode.Json:
                return ContentDisplay.Display(directory, ContentDisplayType.Json);
            case DisplayMode.Xml:
                return ContentDisplay.Display(directory, ContentDisplayType.Xml);
            default:
                return "No data to display";
        }
    } 
}