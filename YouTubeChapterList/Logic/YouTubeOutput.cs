namespace YouTubeChapterList.Logic;

public class YouTubeOutput
{
    //public static string GetFormattedTimeCode(string timecode)
    //{
    //    var timeData = GetTimeDataArray(timecode);
        
    //    if (!timeData[0].StartsWith('0'))
    //    {
    //        return GetTimeDataString(timeData);
    //    }

    //    timeData = RemoveLeadingZeroFromTimeData(timeData);
    //    return GetTimeDataString(timeData);
    //}

    //private static string[] RemoveLeadingZeroFromTimeData(string[] timeData)
    //{
    //    timeData[0] = timeData[0][1..];
    //    return timeData;
    //}

    //private static string GetTimeDataString(string[] timeData) =>
    //    string.Join(":", timeData);

    //private static string[] GetTimeDataArray(string timecode)
    //{
    //    var data = timecode.Split(':');
    //    if(data.Length < 3) { return []; }
    //    return data.Skip(1).Take(2).ToArray();
    //}
}
