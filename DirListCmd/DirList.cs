namespace DirListCmd;

using DirListLib;
using WinDirListLib;

public static class DirList {
    public static void Display (string dirPath, DisplayMode? displayMode, DirListLib.SortType? sortType, 
                                DirListLib.SortOrder? sortOrder) {

        var fileInfo = new System.IO.FileInfo(dirPath);
        var content =new WinContentProvider(dirPath, sortType, sortOrder!).GetContent();

        var directory = new DirListLib.Directory(
                fileInfo.Name, 
                System.IO.Directory.GetCurrentDirectory(), 
                content);

        switch (displayMode) {
            case DisplayMode.Text:
                Console.Write(ContentDisplay.Display(directory, ContentDisplayType.Text));
                break;
            case DisplayMode.Json:
                Console.Write(ContentDisplay.Display(directory, ContentDisplayType.Json));
                break;
            case DisplayMode.Xml:
                Console.Write(ContentDisplay.Display(directory, ContentDisplayType.Xml));
                break;
        }
    } 
}