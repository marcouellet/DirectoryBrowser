namespace DirListWebApi.Controllers;

using Microsoft.AspNetCore.Mvc;

using DirListLib;
using System.Text;

[ApiController]
[Route("dirlist")]
public class DirListController : ControllerBase
{
    private readonly ILogger<DirListController> _logger;

    private DisplayMode? DisplayMode {get; set; }
    private SortType? SortType {get; set; }
    private SortOrder? SortOrder {get; set; }

    public DirListController(ILogger<DirListController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "dirlist")]
    public string GetDirList(string path, string displayMode, string sortType, string sortOrder)
    {
        var message = "";

        (DisplayMode, SortType, SortOrder, message) = ValidateGetDirListParams(path, displayMode, sortType, sortOrder);

        if (message.Length > 0) {
            return message;
        }

        return DirList.GetDisplayData(path, DisplayMode, SortType, SortOrder);
    }

    private (DisplayMode?, SortType?, SortOrder?, string) ValidateGetDirListParams(string path, string displayMode, string sortType, string sortOrder) {

        var sb = new StringBuilder();           

        if (String.IsNullOrEmpty(path)) {
            sb.AppendLine("path option is required");
        }

        if (String.IsNullOrEmpty(displayMode)) {
            sb.AppendLine("displayMode option is required");
        }

        if (String.IsNullOrEmpty(sortType)) {
            sb.AppendLine("sortType option is required");
        }

        if (String.IsNullOrEmpty(sortOrder)) {
            sb.AppendLine("sortOrder option is required");
        }

        if (!System.IO.Directory.Exists(path)) {
             sb.AppendLine("Path does not exist");
        }

       DisplayMode? displayModeEnum = displayMode switch {
            "Text" => DirListWebApi.DisplayMode.Text,
            "Json" => DirListWebApi.DisplayMode.Json,
            "Xml" => DirListWebApi.DisplayMode.Xml,
            _ => null
        };

        if (displayModeEnum is null) {
            sb.AppendLine("displayMode has invalid value");
        }

        DirListLib.SortType? sortTypeEnum = sortType switch {
            "size" => DirListLib.SortType.Size,
            "name" => DirListLib.SortType.Name,
            _ => null
        };

        if (sortTypeEnum is null) {
            sb.AppendLine("sortType has invalid value");
        }

        DirListLib.SortOrder? sortOrderEnum = sortOrder switch {
            "asc" => DirListLib.SortOrder.Asc,
            "desc" => DirListLib.SortOrder.Desc,
            _ => null
        };

        if (sortOrderEnum is null) {
            sb.AppendLine("sortOrder has invalid value");
        }


        return (displayModeEnum!, sortTypeEnum!, sortOrderEnum!, sb.ToString());
    }
    
}
