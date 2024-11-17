using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using YouTubeChapterList.Logic.Interfaces;

namespace YouTubeChapterList.Logic;

public class DavinciResolveParser: IParser
{
    public string Parse(FluentInputFileEventArgs[] files)
    {
        try
        {
            if (files.Length > 0)
            {
                return ParseDavinciResolveEditIndexFile(files[0]);
            }
            return string.Empty;
        }
        catch (Exception _)
        {
            // invalid format
            return string.Empty;
        }
    }

    private string ParseDavinciResolveEditIndexFile(FluentInputFileEventArgs file)
    {
        TextFieldParser reader = GetDavinciResolveEditIndexReader(file);
        var dataRow = Array.Empty<string>();

        dataRow = reader.ReadFields();
        if (dataRow is not null)
        {
            var timeIndex = GetFieldIndex("Source In", dataRow);
            var nameIndex = GetFieldIndex("Notes", dataRow);
            return GetTimecodeTableString(reader, timeIndex, nameIndex);
        }
        return string.Empty;
    }

    private string GetTimecodeTableString(TextFieldParser reader, int timeIndex, int nameIndex)
    {
        var dataRow = Array.Empty<string>();
        var timecodes = new StringBuilder();
        timecodes.AppendLine("-- TIMESTAMPS --");
        while (!reader.EndOfData)
        {
            dataRow = reader.ReadFields();
            if ((dataRow is not null) && dataRow.Length > 1)
            {
                timecodes.AppendLine($"{YouTubeOutput.GetFormattedTimeCode(dataRow[timeIndex])} {dataRow[nameIndex]}");
            }
        }

        return timecodes.ToString();
    }

    private int GetFieldIndex(string fieldName, string[] dataRow) =>
        dataRow.Index().FirstOrDefault(x => x.Item == fieldName).Index;

    private TextFieldParser GetDavinciResolveEditIndexReader(FluentInputFileEventArgs file)
    {
        MemoryStream csvStream = new(file.Buffer.Data);
        TextFieldParser reader = new(csvStream)
        {
            TextFieldType = FieldType.Delimited,
            HasFieldsEnclosedInQuotes = true
        };
        reader.SetDelimiters(",");
        return reader;
    }
}
