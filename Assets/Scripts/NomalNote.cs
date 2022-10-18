using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalNote : MonoBehaviour
{
    private float timing;
    private NOTE_TYPE noteType = NOTE_TYPE.NomalNote;

    public float Timing
    {
        get { return timing; }
        set { timing = value; }
    }
    public NOTE_TYPE NoteType
    {
        get { return noteType; }
    }
}
