using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScript : MonoBehaviour
{
    public float speed;

    public GameObject nomalNote;
    public GameObject holdNote;
    public GameObject guideLine;

    private List<NoteData> notes = new();
    private List<NoteData> holdNotes = new();

    private CsvRead chartData;

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }

    public void ReadChartData(string fileName)
    {
        speed = 3.0f;
        chartData = new CsvRead("CsvFiles/Charts/" + fileName);
        GenerateAllNotes();
    }

    public JUDGE_TYPE PressRane(int rane, float time)
    {
        int index = -1;
        foreach(NoteData note in notes)
        {
            index++;
            if(Mathf.Abs(note.Timing - time) <= 0.6f && note.Rane == rane)
            {
                switch(Mathf.Abs(note.Timing - time))
                {
                    case float i when i <= 0.2f:
                        notes.RemoveAt(index);
                        note.DestroyThisNote();
                        return JUDGE_TYPE.perfect;

                    case float i when i <= 0.4f:
                        notes.RemoveAt(index);
                        note.DestroyThisNote();
                        return JUDGE_TYPE.good;

                    default:
                        notes.RemoveAt(index);
                        note.DestroyThisNote();
                        return JUDGE_TYPE.bad;
                }
            }

            if(note.Timing - time > 0.6f)
            {
                break;
            }
        }
        return JUDGE_TYPE.none;
    }

    public JUDGE_TYPE HoldCheckRane(int rane, float time, bool isKey)
    {
        int index = -1;
        foreach(NoteData note in holdNotes)
        {
            index++;
            if(note.Rane == rane)
            {
                if(note.Timing <= time && time <= note.EndTiming)
                {
                    if(!isKey)
                    {
                        holdNotes.RemoveAt(index);
                        note.DestroyThisNote();
                        return JUDGE_TYPE.miss;
                    }
                }
                else if(note.Timing >= time)
                {
                    continue;
                }
                else if(note.EndTiming <= time)
                {
                    holdNotes.RemoveAt(index);
                    note.DestroyThisNote();
                    return JUDGE_TYPE.perfect;
                }
            }
        }
        return JUDGE_TYPE.none;
    }

    public int MissCheck(float time)
    {
        int count = 0;
        foreach(NoteData note in notes)
        {
            if (note.NoteType == NOTE_TYPE.HoldNote) continue;
            if(time - note.Timing > 0.6f)
            {
                note.DestroyThisNote();
                count++;
            }
            if(note.Timing - time > 0.6f)
            {
                break;
            }
        }
        notes.RemoveRange(0, count);
        return count;
    }

    private void GenerateAllNotes()
    {
        foreach(string[] note in chartData.csvData)
        {
            GenerateNote(note);
        }
    }

    private void GenerateNote(string[] noteData)
    {
        int noteType = int.Parse(noteData[0]);
        int rane = int.Parse(noteData[1]);
        float timing = float.Parse(noteData[2]);

        float mergin = 2.0f;
        float positionY = speed * (mergin + timing) + guideLine.transform.position.y;
        float positionX = -3 + rane * 2;
        NoteData nd;
        GameObject note;
        switch (noteType)
        {
            case 0:
                note = Instantiate(nomalNote, new Vector3(positionX, positionY, 0), Quaternion.identity, transform);
                nd = note.GetComponent<NoteData>();
                nd.Timing = timing;
                nd.NoteType = NOTE_TYPE.NomalNote;
                nd.Rane = rane;
                notes.Add(nd);
                break;

            case 1:
                float endTiming = float.Parse(noteData[3]);
                float noteLength = endTiming - timing;
                note = Instantiate(nomalNote, new Vector3(positionX, positionY, 0), Quaternion.identity, transform);
                nd = note.GetComponent<NoteData>();
                nd.Timing = timing;
                nd.NoteType = NOTE_TYPE.NomalNote;
                nd.Rane = rane;
                notes.Add(nd);
                note = Instantiate(holdNote, new Vector3(positionX, positionY + noteLength / 2 * speed, 0), Quaternion.identity, transform);
                note.transform.localScale = new Vector3(20, noteLength * speed * 50, 1);
                nd = note.GetComponent<NoteData>();
                nd.Timing = timing;
                nd.NoteType = NOTE_TYPE.HoldNote;
                nd.Rane = rane;
                nd.EndTiming = endTiming;
                holdNotes.Add(nd);
                break;
        }
    }
}
