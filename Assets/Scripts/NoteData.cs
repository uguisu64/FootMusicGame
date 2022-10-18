using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteData : MonoBehaviour
{
    private float timing;
    private int rane;
    private NOTE_TYPE noteType = NOTE_TYPE.NomalNote;

    public float Timing
    {
        get { return timing; }
        set { timing = value; }
    }
    public NOTE_TYPE NoteType
    {
        get { return noteType; }
        set { noteType = value; }
    }
    public int Rane
    {
        get { return rane; }
        set { rane = value; }
    }

    public void DestroyThisNote()
    {
        Destroy(gameObject);
    }
}
