using Microsoft.FluentUI.AspNetCore.Components;

namespace YouTubeChapterList.Logic.Interfaces;

interface IParser
{
    abstract string Parse(FluentInputFileEventArgs[] files);
}
