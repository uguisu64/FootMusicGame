public struct MusicData
{
    public MusicData(string title, string level, string difficulty)
    {
        Title = title;
        Level = level;
        Difficulty = difficulty;
        MusicName = string.Empty;
        ChartName = string.Empty;
    }

    public MusicData(string title, string level, string difficulty, string musicName, string chartName)
    {
        Title = title;
        Level = level;
        Difficulty = difficulty;
        MusicName = musicName;
        ChartName = chartName;
    }

    public string Title { get; }
    public string Level { get; }
    public string Difficulty { get; }
    public string MusicName { get; }
    public string ChartName { get; }
}