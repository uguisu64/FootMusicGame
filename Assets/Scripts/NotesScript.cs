using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScript : MonoBehaviour
{
    public float speed;

    public GameObject nomalNote;
    public GameObject guideLine;

    private List<NoteData> notes = new();

    private CsvRead chartData;

    void Start()
    {
        speed = 3.0f;
        chartData = new CsvRead("CsvFiles/Charts/test");
        GenerateAllNotes();
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
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

    public int MissCheck(float time)
    {
        int count = 0;
        foreach(NoteData note in notes)
        {
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
            GenerateNote(int.Parse(note[0]), int.Parse(note[1]), float.Parse(note[2]));
        }
    }

    private void GenerateNote(int noteType, int rane, float timing)
    {
        float mergin = 2.0f;
        float positionY = speed * (mergin + timing) + guideLine.transform.position.y;
        float positionX = -3 + rane * 2;
        switch (noteType)
        {
            case 0:
                GameObject note = Instantiate(nomalNote, new Vector3(positionX, positionY, 0), Quaternion.identity, transform);
                NoteData nd = note.GetComponent<NoteData>();
                nd.Timing = timing;
                nd.NoteType = NOTE_TYPE.NomalNote;
                nd.Rane = rane;
                notes.Add(nd);
                break;
        }
    }
}
