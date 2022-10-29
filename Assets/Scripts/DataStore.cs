using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataStore : MonoBehaviour
{
    public static bool isObject = false;

    private int index;

    private CsvRead musicData;

    private int[] result;
    public int[] Result { get { return result; } set { result = value; } }
    
    void Awake()
    {
        if (isObject)
        {
            isObject = true;
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        index = 0;

        musicData = new CsvRead("CsvFiles/musicData");
    }

    public MusicData ChangeIndexReturnMusicData(int i)
    {
        changeIndex(i);
        string[] line = musicData.csvData[index];
        return new MusicData(line[0], line[2], line[1]);
    }

    public MusicData SelectedMusicData()
    {
        changeIndex(0);
        string[] line = musicData.csvData[index];
        return new MusicData(line[0], line[2], line[1], line[3], line[4]);
    }

    private void changeIndex(int i)
    {
        index += i;

        if(index >= musicData.csvData.Count)
        {
            index = 0;
        }
        if(index < 0)
        {
            index = musicData.csvData.Count - 1;
        }
    }
}
