using  DirListCmd;

class Program {
  
    // Main Method
    static public void Main(String[] args)
    {
        var options = CommandLineParser.ParseOptions(args);

        CommandLineOption? GetOptionByName(string optionName) =>
            options.Where(option => option.Name == optionName).LastOrDefault();

        void DisplayHelpAndExit() {
            Console.WriteLine("dirListCmd -path [-displayMode] [--help]");
            Console.WriteLine("Function: List all entries in a directory");
            Console.WriteLine("Parameters:");
            Console.WriteLine("-path                 The path of the directory");
            Console.WriteLine("-sort        name     Sort the content by name");
            Console.WriteLine("-sort        size     Sort the content by size");
            Console.WriteLine("-order       asc      Sort the content in ascending order");
            Console.WriteLine("-order       desc     Sort the content in descending order");
            Console.WriteLine("-displayMode Text     Display the directory content in plain text");
            Console.WriteLine("-displayMode Json     Display the directory content in JSON");
            Console.WriteLine("-displayMode Xml      Display the directory content in XML");
            Environment.Exit(-1);      
        }

        var pathOption = GetOptionByName("path");
        Assert.True(pathOption is not null && pathOption.Value is not null, () => {
            Assert.Log("path option is required");
            DisplayHelpAndExit();     
        });

       Assert.True(System.IO.Directory.Exists(pathOption!.Value), () => {
            Assert.Log("path is not a directory");
            DisplayHelpAndExit();  
        });

        if (!System.IO.Directory.Exists(pathOption!.Value)) {
            throw new Exception("Path does not exist");
        }

        var displayOption = GetOptionByName("displayMode");
        Assert.True(displayOption is not null && displayOption.Value is not null, () => {
            Assert.Log("display option is required");
            DisplayHelpAndExit(); 
        });

        DisplayMode? displayMode = displayOption!.Value! switch {
            "Text" => DisplayMode.Text,
            "Json" => DisplayMode.Json,
            "Xml" => DisplayMode.Xml,
            _ => null
        };

        Assert.True(displayMode is not null, () => {
            Assert.Log("display option is not valid");
            DisplayHelpAndExit(); 
        });

        var sort =  GetOptionByName("sort")?.Value ?? "size";

        DirListLib.SortType? sortType = sort switch {
            "size" => DirListLib.SortType.Size,
            "name" => DirListLib.SortType.Name,
            _ => null
        };

        Assert.True(sortType is not null, () => {
        Assert.Log("sort option is not valid");
            DisplayHelpAndExit(); 
        });

        var order =  GetOptionByName("order")?.Value ?? "asc";

        DirListLib.SortOrder? sortOrder = order switch {
            "asc" => DirListLib.SortOrder.Asc,
            "desc" => DirListLib.SortOrder.Desc,
            _ => null
        };

        Assert.True(sortOrder is not null, () => {
        Assert.Log("order option is not valid");
            DisplayHelpAndExit(); 
        });


        var helpOption = GetOptionByName("help");
        if (helpOption is not null) {
            DisplayHelpAndExit();
        }

        DirList.Display(pathOption!.Value, displayMode!, sortType!, sortOrder!); 
    }
}
