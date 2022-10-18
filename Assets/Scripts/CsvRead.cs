using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CsvRead
{
    public List<string[]> csvData = new();
    public CsvRead(string pass)
    {
        TextAsset csvFile = Resources.Load(pass) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvData.Add(line.Split(","));
        }
    }
}
